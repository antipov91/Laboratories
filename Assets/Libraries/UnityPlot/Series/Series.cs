using UnityEngine;
using System;

namespace UnityPlot.Core
{
    public abstract class Series
    {
        public event EventHandler OnChange = delegate { };

        public string Title
        {
            get { return title; }
            set { title = value; OnChange.Invoke(this, EventArgs.Empty); }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; OnChange.Invoke(this, EventArgs.Empty); }
        }

        public Color LineColor
        {
            get { return color; }
            set { color = value; OnChange.Invoke(this, EventArgs.Empty); }
        }

        public int Thinkness { get; set; }

        private string title;
        private bool isVisible;
        private Color color;

        protected PointsCollection points;

        public Series(string name, Color color, int thinkness = 1)
        {
            Thinkness = thinkness;
            points = new PointsCollection();
            Title = name;
            IsVisible = true;
            LineColor = color;
        }

        public int Count()
        {
            return points.Count;
        }

        public void Clear()
        {
            points.Clear();
        }

        public Rect GetArea()
        {
            return points.GetArea();
        }

        public void RemoveLast()
        {
            points.RemoveLast();
        }

        public PointsCollection GetPoints()
        {
            return points;
        }

        public bool IsDrawable()
        {
            return IsVisible && points.Count >= 2;
        }
    }
}