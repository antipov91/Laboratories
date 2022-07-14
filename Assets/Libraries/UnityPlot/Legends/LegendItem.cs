using UnityEngine;

namespace UnityPlot.Core
{
    public abstract class LegendItem : MonoBehaviour
    {
        public virtual string Title { get; set; }

        protected Series series;

        public void BindSeries(Series series)
        {
            this.series = series;
        }
    }
}