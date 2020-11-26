using System;
using System.Numerics;
using System.Windows.Forms;
using Mandelbrot;
using Reverse;

namespace GuiForTasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var container = new FlowLayoutPanel();
            var reverseButton = new Button();
            reverseButton.Click += OnReverseClick;
            reverseButton.Text = "Task 1";
            var mandelbrotButton = new Button();
            mandelbrotButton.Click += OnMandelbrotClick;
            mandelbrotButton.Text = "Task 3";
            container.Controls.Add(reverseButton);
            container.Controls.Add(mandelbrotButton);
            this.Controls.Add(container);
        }

        private void OnReverseClick(object sender, EventArgs e)
        {
            var c = new Complex(0, 0);
            var runner = new ReverseRunner(c);
        }

        private void OnMandelbrotClick(object sender, EventArgs e)
        {
            var runner = new MandelbrotRunner();
            var form = runner.GetForm();
        }
    }
}