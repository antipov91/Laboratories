using System;
using UnityEngine;

namespace Laboratories.Devices
{
    public class SlitDevice : MonoDevice
    {
        private double delta;
        public double Delta 
        {
            get { return delta; }
            set
            {
                if (delta == value)
                    return;

                delta = value;
                UpdateImage();
            }
        }
        
        public double MinDelta { get { return minDelta; } }
        public double MaxDelta { get { return maxDelta; } }

        public bool IsOpenAll { get; set; }

        [SerializeField] private string screenName;
        [SerializeField] private string laserName;
        [SerializeField] private int textureSize = 512;
        [SerializeField] private Vector2 size;

        [SerializeField] private double minDelta;
        [SerializeField] private double maxDelta;
        [SerializeField] private double initDelta;

        private GameEntity screenEntity;
        private GameEntity laserEntity;

        private Texture2D texture;

        public override void Initialize()
        {
            texture = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);

            Delta = initDelta;

            screenEntity = contexts.Game.GetEntityWithName(screenName);
            laserEntity = contexts.Game.GetEntityWithName(laserName);

            var laserDevice = laserEntity.Device.instance as LaserDevice;

            laserDevice.OnStateChanged += StateChangedHandle;
            laserDevice.OnWaveLengthChanged += WaveLengthChangedHandle;

            var screenDevice = screenEntity.Device.instance as ScreenRulerDevice;

            screenDevice.OnDistanceChanged += DistanceChangedHandle;

            UpdateImage();
        }

        protected override void OnRelease()
        {
            screenEntity = contexts.Game.GetEntityWithName(screenName);
            laserEntity = contexts.Game.GetEntityWithName(laserName);

            var laserDevice = laserEntity.Device.instance as LaserDevice;

            laserDevice.OnStateChanged -= StateChangedHandle;
            laserDevice.OnWaveLengthChanged -= WaveLengthChangedHandle;

            var screenDevice = screenEntity.Device.instance as ScreenRulerDevice;

            screenDevice.OnDistanceChanged -= DistanceChangedHandle;
        }

        private void DistanceChangedHandle(float value)
        {
            UpdateImage();
        }

        private void WaveLengthChangedHandle(double value)
        {
            UpdateImage();
        }

        private void StateChangedHandle(bool value)
        {
            UpdateImage();
        }

        private void UpdateImage()
        {
            screenEntity = contexts.Game.GetEntityWithName(screenName);
            var screenDevice = screenEntity.Device.instance as ScreenRulerDevice;

            laserEntity = contexts.Game.GetEntityWithName(laserName);
            var laserDevice = laserEntity.Device.instance as LaserDevice;


            if (laserEntity.DeviceActive.value == false || screenEntity.ActivePlacement.value == false)
            {
                for (int x = 0; x < textureSize; x++)
                    for (int y = 0; y < textureSize; y++)
                        texture.SetPixel(x, y, new Color(0f, 0f, 0f, 0f));
            }
            else
            {
                var pixelSize = size / textureSize;
                for (int x = 0; x < textureSize; x++)
                {
                    for (int y = 0; y < textureSize; y++)
                    {
                        var position = new Vector2(pixelSize.x * x - size.x / 2f, pixelSize.y * y - size.y / 2f);
                        var intensity = (float)(GetIntensity(position, screenDevice.Distance, laserDevice.WaveLength) / 4f) * GetFade(2f * position / size);
                        
                        texture.SetPixel(x, y, new Color(1f, 1f, 1f, intensity));
                    }
                }
            }

            texture.Apply();
            screenDevice.SetTexture(texture);
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public double GetIntensity(Vector2 point, float dist, double wLength)
        {
            var lx = -Delta / 2.0;
            var rx = Delta / 2.0;

            var lr = Math.Sqrt((point.x - lx) * (point.x - lx) + point.y * point.y + dist * dist);
            var rr = Math.Sqrt((point.x - rx) * (point.x - rx) + point.y * point.y + dist * dist);

            return 2.0 * (1.0 + Math.Cos((2.0 * Math.PI / wLength) * (lr - rr)));
        }

        private float GetFade(Vector2 point)
        {
            return 1f;
        }
    }
}