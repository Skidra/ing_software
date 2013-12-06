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

namespace ejemplos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;UserId=root;database=reportes;pwd=");
        //En donde server="nombre del servidor", user id="root" y database="Nombre de la BD a la que nos conectaremos.
        public static string variable;
                
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open(); //Abrimos la conexion creada.
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE nickname='" + textBox1.Text + "'AND pwd='" + textBox2.Text + "' ", con); //Realizamos una selecion de la tabla usuarios.
            MySqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read()) //Si el usuario es correcto nos abrira la otra ventana.
            {
                variable = textBox1.Text;
                Form3 ss = new Form3();
                ss.Show();
                this.Hide();
            }
            else //Si no lo es mostrara este mensaje.
                MessageBox.Show("Error - Ingrese sus datos correctamente");
            con.Close(); //Cerramos la conexion.
        }
    }
}
