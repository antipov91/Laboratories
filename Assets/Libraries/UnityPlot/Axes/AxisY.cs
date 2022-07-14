using UnityEngine;
using UnityEngine.UI;

namespace UnityPlot
{
    public class AxisY : Axis
    {
        public override void UpdateLabel(Text label, float value, float relativePosition)
        {
            label.text = string.Format("{0:f1}", value);
            label.rectTransform.anchorMin = new Vector2(0, relativePosition - 0.07f);
            label.rectTransform.anchorMax = new Vector2(0, relativePosition + 0.07f);
        }
    }
}