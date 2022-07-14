using UnityEngine;
using UnityEngine.UI;

namespace UnityPlot
{
    public abstract class Axis : MonoBehaviour
    {
        [SerializeField] private Text textPrefab;
        [SerializeField] protected uint maxCountLabels = 20;
        protected Text[] labels;

        private void Awake()
        {
            labels = new Text[maxCountLabels];
            for (int i = 0; i < maxCountLabels; i++)
            {
                var label = Instantiate<Text>(textPrefab);
                label.transform.SetParent(transform, false);
                label.gameObject.SetActive(false);
                labels[i] = label;
            }
        }

        public void UpdateValues(float axisScale, float startValue, float gridStep, float gridOffset, float axesSize)
        {
            int i = 0;
            float currentValue = startValue + gridOffset / axisScale;
            float pixelStep = gridStep * axisScale;
            float currentPos = gridOffset;
            while (currentPos < axesSize && i < maxCountLabels)
            {
                labels[i].gameObject.SetActive(true);
                UpdateLabel(labels[i], currentValue, currentPos / axesSize);
                currentValue += gridStep;
                currentPos += pixelStep;
                i += 1;
            }
            while (i < maxCountLabels)
            {
                labels[i].gameObject.SetActive(false);
                i += 1;
            }
        }

        public abstract void UpdateLabel(Text label, float value, float relativePosition);

        public void Clear()
        {
            for (int i = 0; i < maxCountLabels; i++)
                labels[i].gameObject.SetActive(false);
        }
    }
}