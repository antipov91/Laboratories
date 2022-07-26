using Laboratories.Devices;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class ScreenRulerResearchPanel : ResearchPanel
    {
        [SerializeField] private GridSystem gridSystem;
        [SerializeField] private Transform labelHandle;
        [SerializeField] private Text intensityLabel;
        [SerializeField] private RawImage image;

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.Device.instance is ScreenRulerDevice;
        }

        protected override void OnInvoked()
        {
            var device = gameEntity.Device.instance as ScreenRulerDevice;

            image.texture = device.Texture;

            gridSystem.OnClick += ClickHandle;
            gridSystem.CheckClickCondition = CheckClickCondition;

            gridSystem.SetPosition(labelHandle.position);
        }

        private bool CheckClickCondition(Vector2 value)
        {
            return true;
        }

        private void ClickHandle(Vector2 position)
        {
            var device = gameEntity.Device.instance as ScreenRulerDevice;

            var pixelSize = gridSystem.Size / new Vector2(image.texture.width, image.texture.height);
            var pixel = (position + gridSystem.Size / 2f) / pixelSize;

            labelHandle.transform.position = gridSystem.GetWorldPoint(position);
            intensityLabel.text = String.Format("{0:f2}", device.GetScreenValue(new Vector2Int((int)pixel.x, (int)pixel.y)));
        }

        protected override void OnClosed()
        {
            gridSystem.OnClick -= ClickHandle;
        }
    }
}