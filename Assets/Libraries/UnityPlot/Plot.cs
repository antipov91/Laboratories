using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityPlot.Core;

namespace UnityPlot
{
    public class Plot : MonoBehaviour
    {
        public SeriesCollection Series { get; private set; }
        public bool AutoScale { get; set; }
        public Rect Boundary { get; set; }
        public Vector2 GridStep { get; set; }
        
        private float[] gridCoefficients = new float[] { 0.1f, 0.2f, 0.5f, 1f, 2f, 5f, 10f, 20f, 50f };
        private Vector2 axisScale = Vector2.one;
        private IAxes axes;

        private void Awake()
        {
            AutoScale = true;
            axes = transform.Find("Axes").GetComponent<Axes>();
            Series = new SeriesCollection();
        }

        private void Start()
        {
            Redraw();
        }

        public void AddSeries(Series series)
        {
            Series.Add(series);
            series.OnChange += SeriesUpdated;
        }

        public void SetGridCoefficients(float[] coefficients)
        {
            gridCoefficients = coefficients;
        }

        public void Redraw()
        {
            axes.Clear();
            var drawSeries = Series.FindAll(x => x.IsDrawable());
            if (drawSeries.Count != 0 || AutoScale == false)
            {
                var seriesBoundary = Boundary;
                var gridStep = GridStep;
                if (AutoScale || Boundary == Rect.zero)
                {
                    seriesBoundary = GetSeriesBoundary(drawSeries);
                    gridStep = GetBestGridStep(seriesBoundary);
                }

                var axisScale = ComputeAxisScale(axes.GetSize(), seriesBoundary);
                var axisOffset = GetOffset(axisScale, seriesBoundary);
                
                var gridOffset = GetGridOffset(gridStep, seriesBoundary);
                axes.DrawGrid(gridStep, gridOffset, axisScale);
                foreach (var series in drawSeries)
                    axes.DrawSeries(series, axisScale, axisOffset);
            }
            axes.Redraw();
        }

        public void ClearAllSeries()
        {
            foreach (var series in Series)
                series.Clear();
            
            Redraw();
        }
        
        private void SeriesUpdated(object sender, EventArgs e)
        {
            Redraw();
        }

        private Rect GetSeriesBoundary(List<Series> seriesPlot)
        {
            var seriesBoundary = seriesPlot.First().GetArea();
            foreach (var series in seriesPlot)
            {
                var area = series.GetArea();
                seriesBoundary.xMin = Mathf.Min(seriesBoundary.xMin, area.xMin);
                seriesBoundary.yMin = Mathf.Min(seriesBoundary.yMin, area.yMin);
                seriesBoundary.xMax = Mathf.Max(seriesBoundary.xMax, area.xMax);
                seriesBoundary.yMax = Mathf.Max(seriesBoundary.yMax, area.yMax);
            }
            return seriesBoundary;
        }
        
        private Vector2 ComputeAxisScale(Vector2 figureSize, Rect seriesBoundary)
        {
            return new Vector2(figureSize.x / seriesBoundary.width, figureSize.y / seriesBoundary.height);
        }

        private Vector2 GetOffset(Vector2 axisScale, Rect seriesBoundary)
        {
            var axesSize = axes.GetSize();
            return new Vector2(axesSize.x - axisScale.x * seriesBoundary.xMax, axesSize.y - axisScale.y * seriesBoundary.yMax);
        }

        private Vector2 GetBestGridStep(Rect seriesBoundary)
        {
            return new Vector2(GetBestStep(seriesBoundary.width), GetBestStep(seriesBoundary.height));
        }

        private float GetBestStep(float seriesBoundarySize)
        {
            float bestStep = 1.0f;
            int bestDifference = 100;
            int power = (int)Mathf.Log10(seriesBoundarySize);
            float order = Mathf.Pow(10f, power);
            foreach (var coefficient in gridCoefficients)
            {
                float step = coefficient * order;
                int lineCount = (int)(seriesBoundarySize / step);
                int difference = Mathf.Abs(lineCount - 10);
                if (difference < bestDifference)
                {
                    bestDifference = difference;
                    bestStep = step;
                }
            }
            return bestStep;
        }

        private Vector2 GetGridOffset(Vector2 gridStep, Rect seriesBoundary)
        {
            float offsetX = axisScale.x * ((float)Math.Ceiling(seriesBoundary.xMin / gridStep.x) * gridStep.x - seriesBoundary.xMin);
            float offsetY = axisScale.y * ((float)Math.Ceiling(seriesBoundary.yMin / gridStep.y) * gridStep.y - seriesBoundary.yMin);
            return new Vector2(offsetX, offsetY);
        }
    }
}