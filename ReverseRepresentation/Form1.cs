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
            var text1 = textBox1.Text;
            var text2 = textBox2.Text;
            runner.Run(text1, text2);
        }
    }
}