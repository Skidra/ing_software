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

namespace Reportes
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion = new MySqlConnection();
        String conexionString;
        public Form1()
        {
            InitializeComponent();
            iniciarConexion();
            mostrarDatos();
        }

        private void iniciarConexion()
        {
            try
            {
                conexionString = "Server=127.0.0.1; Database=reportes; Uid=root;";
                conexion.ConnectionString = conexionString;
                conexion.Open();
                MessageBox.Show("Conexion realizada con exito", "Aceptar");
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al intentar conectarse","Error");
            }
            conexion.Close();
        }
        private void mostrarDatos()
        {

            MySqlCommand comando = new MySqlCommand("SELECT * FROM usuario", conexion);
           conexion.Open();
           MySqlDataReader leer = comando.ExecuteReader();
           dataGridView1.Rows.Clear();
            int renglon = 0;
            while (leer.Read())
            {
                renglon = dataGridView1.Rows.Add();
                dataGridView1.Rows[renglon].Cells["id"].Value = leer.GetString(0);
                dataGridView1.Rows[renglon].Cells["nombre"].Value = leer.GetString(1);
                dataGridView1.Rows[renglon].Cells["ap"].Value = leer.GetString(2);
                dataGridView1.Rows[renglon].Cells["am"].Value = leer.GetString(3);
                dataGridView1.Rows[renglon].Cells["domicilio"].Value = leer.GetString(4);
                dataGridView1.Rows[renglon].Cells["telefono"].Value = leer.GetString(5);
                dataGridView1.Rows[renglon].Cells["celular"].Value = leer.GetString(6);
                dataGridView1.Rows[renglon].Cells["email"].Value = leer.GetString(7);
                dataGridView1.Rows[renglon].Cells["nickname"].Value = leer.GetString(8);
                dataGridView1.Rows[renglon].Cells["pwd"].Value = leer.GetString(9);
            }
            conexion.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}