using UnityEngine;

namespace Laboratories.Devices
{
    public class CollectingLensDevice : MonoDevice, IDeviceActiveAddedListener, IActivePlacementAddedListener
    {
        [SerializeField] private string lightEntityName;
        [SerializeField] private string screenEntityName;
        [SerializeField] private string scatteringLensEntityName;

        private GameEntity lightEntity;
        private GameEntity screenEntity;
        private GameEntity scatteringEntity;

        private double firstRadius;
        public double FirstRadius 
        { 
            get 
            { 
                return firstRadius; 
            }
            set 
            {
                if (firstRadius == value)
                    return;

                firstRadius = value;
            } 
        }

        public double MinFirstRadius { get; set; }
        public double MaxFirstRadius { get; set; }

        private double secondRadius;
        public double SecondRadius 
        { 
            get
            {
                return secondRadius;
            }
            set
            {
                if (secondRadius == value)
                    return;

                secondRadius = value;
            }
        }

        public double MinSecondRadius { get; set; }
        public double MaxSecondRadius { get; set; }

        private float distance;
        public float Distance 
        { 
            get
            {
                return distance;
            }
            set
            {
                if (distance == value)
                    return;

                distance = value;
            }
        }

        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }

        [SerializeField] private double initFirstRadius;
        [SerializeField] private double minFirstRadius;
        [SerializeField] private double maxFirstRadius;

        [SerializeField] private double initSecondRadius;
        [SerializeField] private double minSecondRadius;
        [SerializeField] private double maxSecondRadius;

        [SerializeField] private float initDistance;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;

        public override void Initialize()
        {
            lightEntity = contexts.Game.GetEntityWithName(lightEntityName);
            screenEntity = contexts.Game.GetEntityWithName(screenEntityName);
            scatteringEntity = contexts.Game.GetEntityWithName(scatteringLensEntityName);

            lightEntity.AddDeviceActiveAddedListener(this);
            lightEntity.AddActivePlacementAddedListener(this);

            scatteringEntity.AddActivePlacementAddedListener(this);
            screenEntity.AddActivePlacementAddedListener(this);
        }

        public void OnActivePlacementAdded(GameEntity entity, bool value)
        {
            
        }

        protected override void OnRelease()
        {
            lightEntity.RemoveDeviceActiveAddedListener(this);
            lightEntity.RemoveActivePlacementAddedListener(this);

            scatteringEntity.RemoveActivePlacementAddedListener(this);
            screenEntity.RemoveActivePlacementAddedListener(this);
        }
    }
}