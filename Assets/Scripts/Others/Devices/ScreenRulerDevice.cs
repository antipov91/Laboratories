using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories.Devices
{
    public class ScreenRulerDevice : MonoDevice, IActivePlacementAddedListener
    {
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

                screenTransform.position = sourceTransform.position - Vector3.Lerp(minOffset, maxOffset, normalizedValue);
                colliderBox.center = initColliderCenter - Vector3.Lerp(minColliderOffset, maxColliderOffset, normalizedValue);
                OnDistanceChanged?.Invoke(distance);
            }
        }

        public Action<float> OnDistanceChanged;

        public Texture2D Texture { get; private set; }

        [SerializeField] private Vector3 minOffset;
        [SerializeField] private Vector3 maxOffset;

        [SerializeField] private Vector3 minColliderOffset;
        [SerializeField] private Vector3 maxColliderOffset;

        [SerializeField] private float initDistance;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;

        [SerializeField] private BoxCollider colliderBox;
        [SerializeField] private Transform screenTransform;
        [SerializeField] private Transform sourceTransform;

        [SerializeField] private SpriteRenderer preview;

        private Vector3 initColliderCenter;

        public double[,] screenValue;
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

        public void SetTexture(Texture2D texture)
        {
            Texture = texture;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            preview.sprite = sprite;
        }

        public void SetScreenValue(double[,] values)
        {
            screenValue = values;
        }

        public double GetScreenValue(Vector2Int pos)
        {
            return screenValue[pos.x, pos.y];
        }

        protected override void OnRelease()
        {
            entity.RemoveActivePlacementAddedListener(this);
        }
    }
}