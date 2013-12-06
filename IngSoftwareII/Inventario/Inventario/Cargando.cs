using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Inventario
{
    public partial class Cargando : Form
    {
        public Cargando()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 1;
            label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
            progressBar1.Style = ProgressBarStyle.Continuous;
            
            if (Convert.ToInt32(progressBar1.Value) == 100)
            {
                timer1.Stop();
                timer1.Enabled = false;
                this.Hide();
                Inicio form2 = new Inicio();
                form2.Show();
            }
        }

        private void Cargando_Load(object sender, EventArgs e)
        {
            lbCargando.Visible = false;
            progressBar1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            lbCargando.Visible = true;
            button1.Visible = false;
            progressBar1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
        
        }

        private void progressBar1_Click(object sender, EventArgs e){}
    

         
    }
    
}
