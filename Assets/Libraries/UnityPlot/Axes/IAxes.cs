using UnityEngine;

namespace UnityPlot.Core
{
    public interface IAxes
    {
        Vector2 GetSize();
        void DrawGrid(Vector2 gridStep, Vector2 gridOffset, Vector2 axisScale);
        void DrawSeries(Series series, Vector2 axisScale, Vector2 axisOffset);
        void Redraw();
        void Clear();
    }
}