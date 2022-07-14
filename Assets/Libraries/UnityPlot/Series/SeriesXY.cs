using UnityEngine;
using UnityPlot.Core;

namespace UnityPlot
{
    public class SeriesXY : Series
    {
        public SeriesXY(string name, Color color, int thinkness = 1) : base(name, color, thinkness) { }

        public void AddPoint(Vector2 point)
        {
            points.Add(point);
        }
    }
}