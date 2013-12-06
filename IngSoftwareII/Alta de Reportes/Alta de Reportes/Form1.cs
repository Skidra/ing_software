using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Alta_de_Reportes
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion = new MySqlConnection();
        String conexionString;
        
        public Form1()
        {
            InitializeComponent();
            iniciarConexion();
        }
        private void iniciarConexion()
        {
            try
            {
                conexionString = "Server=127.0.0.1; Database=incidencias; Uid=root;";
                conexion.ConnectionString = conexionString;
                conexion.Open();
                MessageBox.Show("Conexion realizada con exito", "Aceptar");
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al intentar conectarse", "Error");
            }
            conexion.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label10.Text = Form4.tabla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string escogido = "INSERT INTO " + " " + label10.Text + " " + " (Folio_Reporte,Fecha,Hora,Tipo_falla,Descripcion,Prioridad,Diagnostico,CI_Relacionado,Edo_Incidente,Cierre_Incidente) VALUES (@folio,@fecha,@hora,@tipo,@desc,@pri,@diag,@ci,@edo,@cierre)";

            MySqlCommand agregar = new MySqlCommand(escogido, conexion);
            agregar.Parameters.AddWithValue("folio", textBox4.Text);
            agregar.Parameters.AddWithValue("fecha", textBox2.Text);
            agregar.Parameters.AddWithValue("hora", textBox3.Text);
            agregar.Parameters.AddWithValue("tipo", textBox1.Text);
            agregar.Parameters.AddWithValue("desc", textBox10.Text);
            agregar.Parameters.AddWithValue("pri", textBox5.Text);
            agregar.Parameters.AddWithValue("diag", textBox6.Text);
            agregar.Parameters.AddWithValue("ci", textBox7.Text);
            agregar.Parameters.AddWithValue("edo", textBox8.Text);
            agregar.Parameters.AddWithValue("cierre", textBox9.Text);
            agregar.ExecuteNonQuery();
            MessageBox.Show("Registro Exitoso");
            conexion.Close();
            this.Hide();
            Form3 regresar = new Form3();
            regresar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 cancelar = new Form3();
            cancelar.Show();
        }
    }
}
