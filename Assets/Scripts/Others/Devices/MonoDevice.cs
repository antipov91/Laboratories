using Laboratories.ElectricalCircuit;
using UnityEngine;

namespace Laboratories.Devices
{
    public abstract class MonoDevice : MonoBehaviour, IDeviceActiveAddedListener
    {
        protected Contexts contexts;
        protected GameEntity entity;

        protected IJointsCollection joints;
        protected DeviceContext deviceContext;

        private bool isInitialized;

        public void Initialize(Contexts contexts, GameEntity entity)
        {
            this.contexts = contexts;
            this.entity = entity;
            joints = new JointsCollection();
            deviceContext = new DeviceContext(contexts, contexts.Circuit.CircuitSimulatorEntity.Circuit.instance);
            Initialize();
            InitializeCircuit();
            OnDeviceState(false);

            isInitialized = true;

            if (entity.HasDeviceActive)
                entity.AddDeviceActiveAddedListener(this);
        }

        public virtual void Initialize() { }
        public abstract void InitializeCircuit();
        public void Process() 
        {
            if (isInitialized == false)
                return;

            if (entity.HasDeviceActive && entity.DeviceActive.value)
                OnProcess();
            else if (entity.HasDeviceActive == false)
                OnProcess();
        }

        protected virtual void OnProcess() { }

        protected virtual void OnDeviceState(bool isActive) { }

        public void Release()
        {
            deviceContext.Release();

            if (entity.HasDeviceActive)
                entity.RemoveDeviceActiveAddedListener(this);
        }

        public IJointsCollection GetJoints()
        {
            return joints;
        }

        public void OnDeviceActiveAdded(GameEntity entity, bool value)
        {
            OnDeviceState(value);
        }
    }
}