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
    public partial class Form7 : Form
    {
        MySqlConnection conexion = new MySqlConnection();
        String conexionString;
        public Form7()
        {
            InitializeComponent();
            iniciarConexion();
            mostrarDatos();
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
        private void mostrarDatos()
        {
            string verTabla = "SELECT * FROM registro";
            MySqlCommand comando = new MySqlCommand(verTabla, conexion);
            conexion.Open();
            MySqlDataReader leer = comando.ExecuteReader();
            dataGridView1.Rows.Clear();
            int renglon = 0;
            while (leer.Read())
            {
                renglon = dataGridView1.Rows.Add();
                dataGridView1.Rows[renglon].Cells["id_cliente"].Value = leer.GetString(0);
                dataGridView1.Rows[renglon].Cells["tipo_falla"].Value = leer.GetString(1);
                dataGridView1.Rows[renglon].Cells["folios_relacionados"].Value = leer.GetString(2);
            }
            conexion.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 regresar = new Form3();
            regresar.Show();
        }
    }
}
