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
    public partial class conf_cliente : Form
    {
        public conf_cliente()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;UserId=root;database=reportes;pwd=");
        //En donde server="nombre del servidor", user id="root" y database="Nombre de la BD a la que nos conectaremos.
        public static string variable;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            opcion cancelar = new opcion();
            cancelar.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open(); //Abrimos la conexion creada.
            MySqlCommand cmd = new MySqlCommand("SELECT id FROM usuario WHERE nickname='" + txt1.Text + "'AND pwd='" + txt2.Text + "' ", con); //Realizamos una selecion de la tabla usuarios.
            MySqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read()) //Si el usuario es correcto nos abrira la otra ventana.
            {
                variable = txt1.Text;
                Reporte ss = new Reporte();
                ss.Show();
                this.Hide();
            }
            else //Si no lo es mostrara este mensaje.
                MessageBox.Show("Error - Ingrese sus datos correctamente");
            con.Close(); //Cerramos la conexion.
        }
    }
}