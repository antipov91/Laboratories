using UnityEngine;
using UnityEngine.UI;

namespace UnityPlot
{
    public class ImageAxes : Axes
    {
        [SerializeField] private Vector2 imageSize = new Vector2(400, 400);

        protected void Awake()
        {
            textureResolution = imageSize;
            var image = transform.Find("Image").GetComponent<Image>();
            image.sprite = GetSprite();
        }
    }
}