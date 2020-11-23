namespace Demo
{
    using System;
    using OxyPlot;
    using OxyPlot.Series;

    public class MainViewModel
    {
        public MainViewModel()
        {
            this.Model = new PlotModel {Title = "MyPlot"};

            // this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            var scatter = new ScatterPoint(100, 100);
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
            scatterSeries.Points.Add(scatter);
            Model.Series.Add(scatterSeries);
        }

        public PlotModel Model { get; private set; }
    }
}