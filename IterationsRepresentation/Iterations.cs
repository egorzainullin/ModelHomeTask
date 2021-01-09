using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using Iterations;
using FSharp;
using Microsoft.FSharp.Collections;

namespace IterationsRepresentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            var str = textBox1.Text;
            var flag = Double.TryParse(str, out double parameter);
            if (!flag)
            {
                MessageBox.Show(@"Incorrect input");
                
            }
            else
            {
                var vector2S = new List<Vector2>
                {
                    new Vector2(0, 0),
                    new Vector2(5, 5)
                };
                var line = ListModule.OfSeq(vector2S);
                var c = (float) parameter;
                float h = (float) 0.01;
                var func = Core.genCSharpFunction(c);
                
                var runner1 = new IterRunner(line, func, h);
                var runner2 = runner1.Process();
                runner2.Show();
            }
        }
    }
}