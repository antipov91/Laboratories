using System;
using UnityEngine;

namespace Laboratories.Devices
{
    public class DifractionGridDevice : MonoDevice
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


        private double holeLength;
        public double HoleLength
        {
            get { return HoleLength; }
            set
            {
                if (holeLength == value)
                    return;

                holeLength = value;
                UpdateImage();
            }
        }

        public double MinHoleLength { get { return minHoleLength; } }
        public double MaxHoleLength { get { return maxHoleLength; } }


        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                if (count == value)
                    return;

                count = value;
                UpdateImage();
            }
        }

        public int MinCount { get { return minCount; } }
        public int MaxCount { get { return maxCount; } }

        [SerializeField] private string screenName;
        [SerializeField] private string laserName;
        [SerializeField] private int textureSize = 512;
        [SerializeField] private Vector2 size;

        [SerializeField] private double minDelta;
        [SerializeField] private double maxDelta;
        [SerializeField] private double initDelta;

        [SerializeField] private double minHoleLength;
        [SerializeField] private double maxHoleLength;
        [SerializeField] private double initHoleLength;

        [SerializeField] private int initCount;
        [SerializeField] private int minCount;
        [SerializeField] private int maxCount;

        private GameEntity screenEntity;
        private GameEntity laserEntity;

        private Texture2D texture;

        public override void Initialize()
        {
            texture = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);

            delta = initDelta;
            count = initCount;
            HoleLength = holeLength;

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
            var intensity = 0.0;

            var r = Math.Sqrt(point.x * point.x + point.y * point.y + dist * dist);

            var alpha = Math.PI * holeLength * (point.x / r) / wLength;
            var beta = Math.PI * delta * (point.x / r) / wLength;

            if (alpha == 0.0 && beta == 0.0)
                intensity = count;
            else if (alpha == 0.0)
                intensity = Math.Pow(Math.Sin(count * beta) / beta, 2) * count;
            else if (beta == 0.0)
                intensity = Math.Pow(Math.Sin(alpha) / alpha, 2) * count;
            else
                intensity = Math.Pow(Math.Sin(alpha) / alpha, 2) * Math.Pow(Math.Sin(count * beta) / beta, 2);

            return Math.Sqrt(intensity);
        }

        private float GetFade(Vector2 point)
        {
            return 1f;
        }
    }
}