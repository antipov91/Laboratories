using System;
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

        public double MinFirstRadius { get { return minFirstRadius; } }
        public double MaxFirstRadius { get { return maxFirstRadius; } }

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

        public double MinSecondRadius { get { return minSecondRadius; } }
        public double MaxSecondRadius { get { return maxSecondRadius; } }

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

                distance = Mathf.Clamp(value, minDistance, maxDistance);
                var normalizedValue = (distance - minDistance) / (maxDistance - minDistance);

                screenTransform.position = sourceTransform.position + Vector3.Lerp(minOffset, maxOffset, normalizedValue);
                colliderBox.center = initColliderCenter + Vector3.Lerp(minOffset, maxOffset, normalizedValue);
                OnDistanceChanged?.Invoke(distance);
            }
        }

        public float MinDistance { get { return minDistance; } }
        public float MaxDistance { get { return maxDistance; } }

        public Action<float> OnDistanceChanged;

        [SerializeField] private double coefficient = 1.57;

        [SerializeField] private double initFirstRadius;
        [SerializeField] private double minFirstRadius;
        [SerializeField] private double maxFirstRadius;

        [SerializeField] private double initSecondRadius;
        [SerializeField] private double minSecondRadius;
        [SerializeField] private double maxSecondRadius;

        [SerializeField] private float initDistance;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;

        [SerializeField] private Vector3 minOffset;
        [SerializeField] private Vector3 maxOffset;

        [SerializeField] private BoxCollider colliderBox;
        [SerializeField] private Transform screenTransform;
        [SerializeField] private Transform sourceTransform;

        private Vector3 initColliderCenter;

        public override void Initialize()
        {
            initColliderCenter = colliderBox.center;

            Distance = initDistance;
            FirstRadius = initFirstRadius;
            SecondRadius = initSecondRadius;


            lightEntity = contexts.Game.GetEntityWithName(lightEntityName);
            screenEntity = contexts.Game.GetEntityWithName(screenEntityName);
            scatteringEntity = contexts.Game.GetEntityWithName(scatteringLensEntityName);

            lightEntity.AddDeviceActiveAddedListener(this);

            lightEntity.AddActivePlacementAddedListener(this);
            scatteringEntity.AddActivePlacementAddedListener(this);
            screenEntity.AddActivePlacementAddedListener(this);
            entity.AddActivePlacementAddedListener(this);
        }

        public void OnActivePlacementAdded(GameEntity entity, bool value)
        {
            if (entity == this.entity && value)
            {
                Distance = initDistance;
                var screen = screenEntity.Device.instance as ScreenDevice;
                screen.SpriteRenderer.enabled = false;
            }
        }

        protected override void OnProcess()
        {
            if (lightEntity.DeviceActive.value && screenEntity.ActivePlacement.value && scatteringEntity.ActivePlacement.value == false)
            {
                var screen = screenEntity.Device.instance as ScreenDevice;

                screen.SpriteRenderer.enabled = true;
                screen.SpriteRenderer.transform.localScale = Vector3.Lerp(new Vector3(0.1f, 0.1f, 0.1f), Vector3.one, 25f * Mathf.Abs(GetFocus() - GetFocusFromDistance()));
                screen.SpriteRenderer.material.SetFloat("_AlphaThreshold", Mathf.Lerp(1f, 0f, 25f * Mathf.Abs(GetFocus() - GetFocusFromDistance())));
            }
            else if (scatteringEntity.ActivePlacement.value == false)
            {
                var screen = screenEntity.Device.instance as ScreenDevice;
                screen.SpriteRenderer.enabled = false;
            }
        }

        private float GetFocus()
        {
            return (float)(1.0 / ((coefficient - 1.0) * (1.0 / firstRadius - 1.0 / secondRadius)));
        }

        private float GetFocusFromDistance()
        {
            var screen = screenEntity.Device.instance as ScreenDevice;

            var d1 = screen.Distance - Distance;
            var d2 = Distance;
            return d1 * d2 / (d1 + d2);
        }

        public float GetImageDistance()
        {
            var focus = GetFocus();
            return (Distance - focus) / (Distance * focus);
        }

        protected override void OnRelease()
        {
            lightEntity.RemoveDeviceActiveAddedListener(this);

            lightEntity.RemoveActivePlacementAddedListener(this);
            scatteringEntity.RemoveActivePlacementAddedListener(this);
            screenEntity.RemoveActivePlacementAddedListener(this);
            entity.RemoveActivePlacementAddedListener(this);
        }
    }
}