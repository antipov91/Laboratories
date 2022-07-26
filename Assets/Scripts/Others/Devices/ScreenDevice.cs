using System;
using UnityEngine;

namespace Laboratories.Devices
{
    public class ScreenDevice : MonoDevice, IActivePlacementAddedListener
    {

        public SpriteRenderer SpriteRenderer { get { return spriteRenderer; } }

        public float MinDistance { get { return minDistance; } }
        public float MaxDistance { get { return maxDistance; } }

        private float distance;
        public float Distance
        {
            get { return distance; }
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

        public Action<float> OnDistanceChanged;

        [SerializeField] private Vector3 minOffset;
        [SerializeField] private Vector3 maxOffset;

        [SerializeField] private float initDistance;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;

        [SerializeField] private BoxCollider colliderBox;
        [SerializeField] private Transform screenTransform;
        [SerializeField] private Transform sourceTransform;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private Vector3 initColliderCenter;

        public override void Initialize()
        {
            initColliderCenter = colliderBox.center;

            Distance = initDistance;

            entity.AddActivePlacementAddedListener(this);
        }

        public void OnActivePlacementAdded(GameEntity entity, bool value)
        {
            if (value == false)
                Distance = initDistance;
        }

        protected override void OnRelease()
        {
            entity.RemoveActivePlacementAddedListener(this);
        }
    }
}