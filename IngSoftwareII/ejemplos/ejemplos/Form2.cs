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
using System.Net.Mail;
using System.Net;
namespace ejemplos
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;UserId=root;database=reportes;pwd=");
        //public static string objeto;

        private void Form2_Load(object sender, EventArgs e)
        {
            //me muestra id y nombre de la tabla con el nickname y pass introducidos en el form anterior
            textBox1.Text = Form1.variable;//variable guardada desde el otro form

            con.Open(); //Abrimos la conexion creada.
            string strcomando = "SELECT * FROM usuario where nickname= '" + textBox1.Text + "'";//hace la busqeda
            MySqlCommand cmd = new MySqlCommand(strcomando,con);
            DataTable tabla = new DataTable();
            MySqlDataAdapter adaptadorTabla = new MySqlDataAdapter(strcomando, con);

            adaptadorTabla.Fill(tabla);

            string id = tabla.Rows[0]["id"].ToString();//busca columna id
            string nombre = tabla.Rows[0]["nombre"].ToString();//busca columna nombre
            textBox4.Text = nombre;//muestra nombre
            textBox3.Text = id;//muestra id
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //Se establece el destinatario
            msg.To.Add("mistick_inquisidor@hotmail.com");
            //Se establece el remitente, asi como el nombre que aparecerá en la bandeja de entrada, así como el formato de codificación
            msg.From = new MailAddress("ashantireyes041291@hotmail.com", "", System.Text.Encoding.ASCII);
            //Se establece el asunto del mail
            msg.Subject = "haber si ya";
            //Formato de codificación del Asunto
            msg.SubjectEncoding = System.Text.Encoding.ASCII;
            //Se establece el cuerpo del mail
            msg.Body = "ojala ";
            //Se establece la codificación del Cuerpo
            msg.BodyEncoding = System.Text.Encoding.ASCII;
//Se indica si al cuerpo del mail, se interpretara como código HTMl o no, esto funciona cuando queremos que aparezca centrado algo
            //mediante
            msg.IsBodyHtml = false;
/*/Se establece la cadena de texto con la ubicación del archivo a adjuntar
            string file = "C:/Datos.xls";
//Se adjunta el archivo
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            msg.Attachments.Add(data);*/

            //Se prepara el envio del mail
            SmtpClient client = new SmtpClient();
            //Se establecen las credenciales para enviar el mail, muy importante autentificarse con la cuenta de correo y la contraseña
            client.Credentials = new System.Net.NetworkCredential("ashantireyes041291@hotmail.com", "areyes0816");
            //Se establece el puerto de envio
            client.Port = 25;
            //Se establece el servidor SMTP, en este caso GMAIL
            client.Host = "smtp.live.com";
            //Seguridad SSL?, si como no, prueben ettereal
            client.EnableSsl = true;

            //Se envia el Mail
            try
            {
                client.Send(msg);
                MessageBox.Show("El Mail se ha Enviado Correctamente", "Listo!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("No se pudo enviar el msj", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }
    }
}
