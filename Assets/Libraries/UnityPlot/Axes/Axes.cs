using System;
using System.Linq;
using UnityEngine;
using UnityPlot.Core;

namespace UnityPlot
{
    public abstract class Axes : MonoBehaviour, IAxes
    {
        [SerializeField] private Color backgroundColor = Color.black;
        [SerializeField] private Color gridColor = Color.white;

        protected Vector2 textureResolution = new Vector2(400, 400);

        private Color previousBackgroundColor = new Color(1, 0, 0, 0);
        private Color[] backgroundArray;

        private Texture2D axes;
        private Rect boundaryRect;

        protected Sprite GetSprite()
        {
            UpdateBackgroundArray();
            axes = new Texture2D((int)textureResolution.x, (int)textureResolution.y);
            boundaryRect = new Rect(2, 2, axes.width - 3, axes.height - 3);
            return Sprite.Create(axes, new Rect(0, 0, (int)textureResolution.x, (int)textureResolution.y), Vector2.zero);
        }

        public Vector2 GetSize()
        {
            return textureResolution;
        }

        public void DrawSeries(Series series, Vector2 axisScale, Vector2 axisOffset)
        {
            if (series.Count() < 2)
                return;

            var points = series.GetPoints();
            var boundaryRect = new Rect(0, 0, axes.width, axes.height - series.Thinkness - 10);

            var firstPoint = points[0];
            var secondPoint = new Vector2(points[0].x * axisScale.x + axisOffset.x, points[0].y * axisScale.y + axisOffset.y);
            for (int i = 1; i < points.Count(); i++)
            {
                firstPoint = secondPoint;
                secondPoint.x = points[i].x * axisScale.x + axisOffset.x;
                secondPoint.y = points[i].y * axisScale.y + axisOffset.y;
                DrawLine(firstPoint, secondPoint, series.LineColor, series.Thinkness);
            }
        }

        public void DrawGrid(Vector2 gridStep, Vector2 gridOffset, Vector2 axisScale)
        {
            DrawVerticalLines(gridStep, axisScale, gridOffset, gridColor);
            DrawHorizontalLines(gridStep, axisScale, gridOffset, gridColor);
        }

        public void Redraw()
        {
            axes.Apply();
        }

        public void Clear()
        {
            if (backgroundColor != previousBackgroundColor)
                UpdateBackgroundArray();
            axes.SetPixels(backgroundArray);
        }

        private void DrawLine(Vector2 firstPoint, Vector2 secondPoint, Color color, int thickness = 1)
        {
            DrawLine(Vector2Int.CeilToInt(firstPoint), Vector2Int.CeilToInt(secondPoint), color, thickness);
        }

        private void DrawLine(Vector2Int firstPoint, Vector2Int secondPoint, Color color, int thickness = 1)
        {
            int dx = Mathf.Abs(secondPoint.x - firstPoint.x);
            int dy = Mathf.Abs(secondPoint.y - firstPoint.y);
            int sx = firstPoint.x < secondPoint.x ? 1 : -1;
            int sy = firstPoint.y < secondPoint.y ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;

            Action<Texture2D, int, int, Color> setPixel = Brushes.Pencil;
            if (thickness == 2)
                setPixel = Brushes.PencilSize2;

            while (true)
            {
                if (boundaryRect.Contains(firstPoint))
                    setPixel(axes, firstPoint.x, firstPoint.y, color);
                if (firstPoint.x == secondPoint.x && firstPoint.y == secondPoint.y) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; firstPoint.x += sx; }
                if (e2 < dy) { err += dx; firstPoint.y += sy; }
            }
        }

        private void DrawHorizontalLines(Vector2 step, Vector2 axisScale, Vector2 pixelOffset, Color color)
        {
            Vector2 pixelStep = step * axisScale;
            var leftPoint = new Vector2(0, pixelOffset.y);
            var rightPoint = new Vector2(textureResolution.x, pixelOffset.y);
            while (leftPoint.y < textureResolution.y)
            {
                DrawLine(leftPoint, rightPoint, color);
                leftPoint.y += pixelStep.y;
                rightPoint.y += pixelStep.y;
            }
        }

        private void DrawVerticalLines(Vector2 step, Vector2 axisScale, Vector2 pixelOffset, Color color)
        {
            Vector2 pixelStep = step * axisScale;
            var downPoint = new Vector2(pixelOffset.x, 0);
            var upPoint = new Vector2(pixelOffset.x, textureResolution.y);
            while (downPoint.x < textureResolution.x)
            {
                DrawLine(downPoint, upPoint, color);
                downPoint.x += pixelStep.x;
                upPoint.x += pixelStep.x;
            }
        }

        private void UpdateBackgroundArray()
        {
            previousBackgroundColor = backgroundColor;
            backgroundArray = Enumerable.Repeat(backgroundColor, (int)(textureResolution.x * textureResolution.y)).ToArray();
        }
    }
}