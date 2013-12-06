using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alta_de_Reportes
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public static string tabla;
        private void button1_Click(object sender, EventArgs e)
        {
            tabla = textBox1.Text;
            Form1 ss = new Form1();
            ss.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 cancelar = new Form3();
            cancelar.Show();
        }

        public static string reportes;
        private void button3_Click(object sender, EventArgs e)
        {
            tabla = textBox1.Text;
            Form5 verTabla = new Form5();
            verTabla.Show();
            this.Hide();
        }
    }
}
