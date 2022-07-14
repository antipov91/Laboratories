using UnityEngine;

namespace UnityPlot
{
    public class SpriteAxes : Axes
    {
        [SerializeField] private Vector2 size = new Vector2(1, 1);
        [SerializeField] private float pixelsPerUnit = 100;

        protected void Awake()
        {
            textureResolution = size * pixelsPerUnit;
            var image = transform.Find("Sprite").GetComponent<SpriteRenderer>();
            image.sprite = GetSprite();
        }
    }
}