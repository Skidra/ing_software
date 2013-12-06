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
    public partial class Form6 : Form
    {
        MySqlConnection conexion = new MySqlConnection();
        String conexionString;
        public Form6()
        {
            InitializeComponent();
            InitializeComponent();
            iniciarConexion();
            
        }

        private void iniciarConexion()
        {
            try
            {
                conexionString = "Server=127.0.0.1; Database=problemas; Uid=root;";
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
        
        private void Form6_Load(object sender, EventArgs e)
        {
            label4.Text = Form4.tabla;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string escogido = "INSERT INTO registro (id_cliente, tipo_falla, folios_relacionados) VALUES (@id,@tipo,@folios)";
           
            MySqlCommand agregar = new MySqlCommand(escogido, conexion);
            agregar.Parameters.AddWithValue("id", label4.Text);
            agregar.Parameters.AddWithValue("tipo", textBox1.Text);
            agregar.Parameters.AddWithValue("folios", textBox2.Text);
            agregar.ExecuteNonQuery();
            MessageBox.Show("Registro Exitoso");
            conexion.Close();
            this.Hide();
            Form3 regresar = new Form3();
            regresar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 regresar = new Form3();
            regresar.Show();
        }
    }
}
