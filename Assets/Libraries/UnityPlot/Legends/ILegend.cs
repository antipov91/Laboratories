namespace UnityPlot.Core
{
    public interface ILegend
    {
        void AddSeries(Series series);
        void RemoveSeries(Series series);
    }
}