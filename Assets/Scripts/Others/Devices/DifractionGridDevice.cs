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
            get { return holeLength; }
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

        private double[,] intensityGrid;

        public override void Initialize()
        {
            texture = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);
            intensityGrid = new double[textureSize, textureSize];

            delta = initDelta;
            count = initCount;
            HoleLength = initHoleLength;

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

            var maxValue = float.MinValue;
            if (laserEntity.DeviceActive.value == false || screenEntity.ActivePlacement.value == false)
            {
                for (int x = 0; x < textureSize; x++)
                    for (int y = 0; y < textureSize; y++)
                        texture.SetPixel(x, y, new Color(0f, 0f, 0f, 0f));
            }
            else
            {
                var len = 4 * textureSize;
                var intensityLine = new float[len];
                var step = size.x / len;
                for (int i = 0; i < len; i++)
                {
                    var x = step * i - size.x / 2.0;
                    intensityLine[i] = (float)GetIntensity(x, screenDevice.Distance, laserDevice.WaveLength);
                }

                Convolution(ref intensityLine, CreateGaussianKernel(25));
                for (int i = 0; i < len; i++)
                    if (intensityLine[i] > maxValue)
                        maxValue = intensityLine[i];

                for (int x = 0; x < textureSize; x++)
                {
                    for (int y = 0; y < textureSize; y++)
                    {
                        intensityGrid[x, y] = intensityLine[4 * x] * Mathf.Lerp(1f, 0f, 0.1f * Mathf.Abs(y - textureSize / 2f));
                        var color = laserDevice.GetColor();
                        color.a = intensityLine[4 * x] * Mathf.Lerp(1f, 0f, 0.1f * Mathf.Abs(y - textureSize / 2f)) / maxValue;
                        texture.SetPixel(x, y, color);
                    }
                }
            }

            texture.Apply();
            screenDevice.SetTexture(texture);
            screenDevice.SetScreenValue(intensityGrid);
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public double GetIntensity(double x, float dist, double wLength)
        {
            double intensity = 0.0;

            double r = Math.Sqrt(x * x + dist * dist);

            var isource = 1.0;
            var alpha = (Math.PI / wLength) * holeLength * (x / r);
            if (alpha != 0)
                isource = Math.Pow(Math.Sin(alpha), 2) / Math.Pow(alpha, 2);

            double iinterference = count;
            var beta = (Math.PI * delta / wLength) * (x / r);
            if (Math.Sin(beta) != 0)
                iinterference = Math.Pow(Math.Sin(count * beta), 2) / Math.Pow(Math.Sin(beta), 2);

            intensity = isource * iinterference;
            return intensity;
        }

        public static void Convolution(ref float[] matrix, float[] kernel)
        {
            int radius = kernel.Length / 2;
            int width = matrix.GetLength(0);
            float res = 0f;
            int index = 0;

            for (int x = 0; x < width; x++)
            {
                res = 0f;
                for (int i = 0; i < kernel.Length; i++)
                {
                    index = PadsIndex(x + i - radius, width);
                    res += matrix[index] * kernel[i];
                }
                matrix[x] = res;
            }
        }

        public static float[] CreateGaussianKernel(int radius)
        {
            int size = 2 * radius;
            float deviation = radius / 4f;
            var kernel = new float[size];
            for (int i = 0; i < size; i++)
                kernel[i] = 1f / (Mathf.Sqrt(2f * Mathf.PI) * deviation) * Mathf.Exp(-(i - radius) * (i - radius) / (2f * deviation * deviation));

            NormalizeMatrix(ref kernel);
            return kernel;
        }

        public static void NormalizeMatrix(ref float[] array)
        {
            float sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];

            for (int i = 0; i < array.Length; i++)
                array[i] /= sum;
        }

        public static int PadsIndex(int index, int maxIndex)
        {
            if (index < 0)
                return 0;
            else if (index >= maxIndex)
                return maxIndex - 1;

            return index;
        }
    }
}