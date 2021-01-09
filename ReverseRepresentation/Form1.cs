using System;
using System.Windows.Forms;
using Reverse.Chart;

namespace ReverseRepresentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnStartClick(object sender, EventArgs e)
        {
            var runner = new ReverseRunner();
            runner.Run();
        }
    }
}