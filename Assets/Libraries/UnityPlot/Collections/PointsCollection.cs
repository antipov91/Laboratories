using System;
using UnityEngine;
using System.Linq;

namespace UnityPlot.Core
{
    public class PointsCollection : Collection<Vector2>
    {
        private Vector2 minValues;
        private Vector2 maxValues;
        private Rect area;

        public override void Add(Vector2 point)
        {
            base.Add(point);
            if (Count == 1)
                InitializeArea();
            else
                UpdateArea();
        }

        public Rect GetArea()
        {
            return area;
        }

        public override void RemoveLast()
        {
            base.RemoveLast();
            foreach (var point in array)
            {
                minValues.x = Mathf.Min(minValues.x, point.x);
                minValues.y = Mathf.Min(minValues.y, point.y);
                maxValues.x = Mathf.Max(maxValues.x, point.x);
                maxValues.y = Mathf.Max(maxValues.y, point.y);
            }
            area = new Rect(minValues, maxValues - minValues);
        }

        private void InitializeArea()
        {
            minValues = array[Count - 1];
            maxValues = array[Count - 1];
            area = new Rect(minValues, Vector2.zero);
        }

        private void UpdateArea()
        {
            Vector2 lastPoint = array[Count - 1];
            minValues.x = Mathf.Min(minValues.x, lastPoint.x);
            minValues.y = Mathf.Min(minValues.y, lastPoint.y);
            maxValues.x = Mathf.Max(maxValues.x, lastPoint.x);
            maxValues.y = Mathf.Max(maxValues.y, lastPoint.y);
            area = new Rect(minValues, maxValues - minValues);
        }
    }
}