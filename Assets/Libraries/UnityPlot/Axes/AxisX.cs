using UnityEngine;
using UnityEngine.UI;

namespace UnityPlot
{
    public class AxisX : Axis
    {
        public override void UpdateLabel(Text label, float value, float relativePosition)
        {
            label.text = string.Format("{0:f2}", value);
            label.rectTransform.anchorMin = new Vector2(relativePosition - 0.07f, 0);
            label.rectTransform.anchorMax = new Vector2(relativePosition + 0.07f, 0);
        }
    }
}