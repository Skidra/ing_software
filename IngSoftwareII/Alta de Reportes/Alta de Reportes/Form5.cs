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
    public partial class Form5 : Form
    {
        MySqlConnection conexion = new MySqlConnection();
        String conexionString;
        public Form5()
        {
            InitializeComponent();
            iniciarConexion();
            mostrarDatos();
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
                MessageBox.Show("Ocurrio un error al intentar conectarse","Error");
            }
            conexion.Close();
        }
        private void mostrarDatos()
        {
            label3.Text = Form4.tabla;
            string verTabla = "SELECT * FROM " + " " + label3.Text;
            MySqlCommand comando = new MySqlCommand(verTabla, conexion);
            conexion.Open();
            MySqlDataReader leer = comando.ExecuteReader();
            dataGridView1.Rows.Clear();
            int renglon = 0;
            while (leer.Read())
            {
                renglon = dataGridView1.Rows.Add();
                dataGridView1.Rows[renglon].Cells["Folio_Reporte"].Value = leer.GetString(0);
                dataGridView1.Rows[renglon].Cells["Fecha"].Value = leer.GetString(1);
                dataGridView1.Rows[renglon].Cells["Hora"].Value = leer.GetString(2);
                dataGridView1.Rows[renglon].Cells["Tipo_Falla"].Value = leer.GetString(3);
                dataGridView1.Rows[renglon].Cells["Descripcion"].Value = leer.GetString(4);
                dataGridView1.Rows[renglon].Cells["Prioridad"].Value = leer.GetString(5);
                dataGridView1.Rows[renglon].Cells["Diagnostico"].Value = leer.GetString(6);
                dataGridView1.Rows[renglon].Cells["Ci_Relacionado"].Value = leer.GetString(7);
                dataGridView1.Rows[renglon].Cells["Edo_Incidente"].Value = leer.GetString(8);
                dataGridView1.Rows[renglon].Cells["Cierre_Incidente"].Value = leer.GetString(9);
            }
            conexion.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            //
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 regresar = new Form4();
            regresar.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 problema = new Form6();
            problema.Show();
        }
    }
}
