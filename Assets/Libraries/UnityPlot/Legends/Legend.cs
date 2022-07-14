using System.Collections.Generic;
using UnityEngine;
using UnityPlot.Core;

namespace UnityPlot
{
    public class Legend : MonoBehaviour, ILegend
    {
        [SerializeField] private LegendItem legendPrefab;

        private Dictionary<string, LegendItem> legendItems = new Dictionary<string, LegendItem>();

        public void AddSeries(Series series)
        {
            var item = Instantiate(legendPrefab);
            item.gameObject.transform.SetParent(transform, false);
            item.BindSeries(series);
            legendItems.Add(series.Title, item);
        }

        public void RemoveSeries(Series series)
        {
            if (!legendItems.ContainsKey(series.Title))
                return;

            var item = legendItems[series.Title];
            if (item.gameObject != null)
                Destroy(item.gameObject);
            
            legendItems.Remove(series.Title);
        }
    }
}