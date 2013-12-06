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
    public partial class Perfil : Form
    {
        MySqlConnection conexion = new MySqlConnection();
        String conexionString;
        
        public Perfil()
        {
            InitializeComponent(); 
            iniciarConexion();
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
                MessageBox.Show("Ocurrio un error al intentar conectarse", "Error");
            }
            conexion.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            MySqlCommand agregar = new MySqlCommand("INSERT INTO usuario (nombre,ap,am,domicilio,telefono,celular,email,nickname,pwd) VALUES (@nom,@app,@apm,@dom,@tel,@cel,@mail,@nick,@pass)", conexion);
            agregar.Parameters.AddWithValue ("nom", textNom.Text);
            agregar.Parameters.AddWithValue("app", textAp.Text);
            agregar.Parameters.AddWithValue("apm", textAm.Text);
            agregar.Parameters.AddWithValue("dom", textDom.Text);
            agregar.Parameters.AddWithValue("tel", textTel.Text);
            agregar.Parameters.AddWithValue("cel", textCel.Text);
            agregar.Parameters.AddWithValue("mail", textEmail.Text);
            agregar.Parameters.AddWithValue("nick", textNick.Text);
            agregar.Parameters.AddWithValue("pass", textPass.Text);
            agregar.ExecuteNonQuery();
            MessageBox.Show("Registro Exitoso");
            conexion.Close();
            this.Hide();
            opcion regresar = new opcion();
            regresar.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            opcion cancelar = new opcion();
            cancelar.Show();
        }
    }
}
