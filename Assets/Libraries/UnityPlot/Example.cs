using UnityEngine;

namespace UnityPlot
{
    public class Example : MonoBehaviour
    {
        private Plot plot;
        private SeriesXY seriesCos;
        private SeriesXY seriesSin;

        private float t1 = 0f;
        private float t2 = 0f;

        void Start()
        {
            plot = GetComponent<Plot>();

            seriesCos = new SeriesXY("Cosine", Color.blue);
            seriesSin = new SeriesXY("Sinus", Color.red);
            plot.AddSeries(seriesCos);
            plot.AddSeries(seriesSin);

            for (int i = 0; i < 100; i++)
                AddCosinePoint();
        }

        public void AddCosinePoint()
        {
            t1 += 0.1f;
            seriesCos.AddPoint(new Vector2(t1, Mathf.Cos(t1)));
            plot.Redraw();
            UnityEngine.Debug.Log(t1);
        }

        public void AddSinePoint()
        {
            t2 += 0.1f;
            seriesSin.AddPoint(new Vector2(t2, Mathf.Sin(t2)));
            plot.Redraw();
        }

        public void Clear()
        {
            seriesCos.Clear();
            seriesSin.Clear();
            plot.Redraw();
        }
    }
}