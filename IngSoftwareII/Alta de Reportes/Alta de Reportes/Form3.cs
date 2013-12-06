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
    public partial class Form3 : Form
    {
        MySqlConnection conexion = new MySqlConnection();
        String conexionString;
        public Form3()
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
                MessageBox.Show("Base de datos encontrada", "Buen Dia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al intentar conectarse","Error");
            }
            conexion.Close();
        }
        private void mostrarDatos()
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            conexion.Open();
            DataTable dt = conexion.GetSchema("Tables");
            this.listBox1.DataSource = dt;
            this.listBox1.ValueMember = "Table_Name";
            this.listBox1.SelectedValue = "Table_Name";
            conexion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 crearReporte = new Form4();
            crearReporte.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form2 crearCliente = new Form2();
            crearCliente.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult salir;
            salir = MessageBox.Show("¿ESTA SEGURO DE QUERER SALIR DE LA APLICACION?", "IMPORTANTE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (salir == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("SELECCIONE LA ACCION QUE DESEA HACER", "ESCOGER"); 
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 verProblemas = new Form7();
            verProblemas.Show();
        }

        
    }
}
