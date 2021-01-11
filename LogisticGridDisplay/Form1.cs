using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogisticGrid;

namespace LogisticGridDisplay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SendMessage(string message)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox1.Text, out var gn) && (Double.TryParse(textBox2.Text, out var cp)))
            {
                if (int.TryParse(textBox3.Text, out var iterNumber))
                {
                    var drawing = new global::Program.Drawing(gn, cp, iterNumber);
                    drawing.Draw();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                
            }
            else
            {
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}