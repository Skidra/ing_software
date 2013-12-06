using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 
using MySql.Data.Types;       

namespace Alta_de_Reportes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;UserId=root;database=incidencias;pwd=");
            conn.Open();
            string nombre =textBox1.Text + "_" + textBox2.Text;
            string creando = "create table if not exists " + nombre + " (Folio_Reporte varchar(20)not null, Fecha varchar(10) not null, Hora varchar(10) not null, Tipo_falla varchar(120) not null, Descripcion varchar(120) not null, Prioridad varchar(50) not null, Diagnostico varchar(120) not null, CI_relacionado varchar(20) not null, Edo_Incidente varchar(50) not null, Cierre_Incidente varchar(20) not null, primary key (Folio_Reporte))";
            MySqlCommand cmd = new MySqlCommand(creando, conn);
            cmd.ExecuteNonQuery();

            DialogResult crear;
            crear = MessageBox.Show("CLIENTE CREADO EXITOSAMENTE, ¿DESEA CREAR UN NUEVO REPORTE?", "OPCION", MessageBoxButtons.YesNo);
            if (crear == DialogResult.Yes)
            {
                this.Hide();
                Form4 crearReporte = new Form4();
                crearReporte.Show(); 

            }
            else
            {
                this.Hide();
                Form3 sa = new Form3();
                sa.Show();
                MessageBox.Show("SELECCIONE LA ACCION QUE DESEA HACER", "ESCOGER");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 cancelar = new Form3();
            cancelar.Show();
        }
    }
}
