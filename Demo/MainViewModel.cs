using System.Collections.Generic;
using System.Numerics;

namespace Demo
{
    using System;
    using OxyPlot;
    using OxyPlot.Series;
    // using Backend;

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
            GenDrawing();
        }

        private void GenDrawing()
        {
            
            

        }

        

       
        public PlotModel Model { get; private set; }
    }
}