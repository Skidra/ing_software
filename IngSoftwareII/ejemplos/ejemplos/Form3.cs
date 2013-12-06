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
using System.Net;
using System.Net.Mail;
using System.Net.Mime;



namespace ejemplos
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("server=127.0.0.1;UserId=root;database=reportes;pwd=");

        private void Form3_Load(object sender, EventArgs e)
        {
            //me muestra id y nombre de la tabla con el nickname y pass introducidos en el form anterior-------
            textBox1.Text = Form1.variable;//variable guardada desde el otro form
            conexion.Open();//abrimos conexion
            string strcomando = "SELECT * FROM usuario where nickname= '" + textBox1.Text + "'";//hace la busqeda
            MySqlCommand cmd = new MySqlCommand(strcomando, conexion);
            DataTable tabla = new DataTable();
            MySqlDataAdapter adaptadorTabla = new MySqlDataAdapter(strcomando, conexion);

            adaptadorTabla.Fill(tabla);

            string id = tabla.Rows[0]["id"].ToString();//busca columna id
            string nombre = tabla.Rows[0]["nombre"].ToString();//busca columna nombre
            textBox2.Text = id;//muestra id
            textBox3.Text = nombre;//muestra nombre
            textBox1.Visible = false;//oculta texbox
        //------------FIN DE BUSQEDA-------------
            //-------------INICIO ALFANUMERICO-----------------
            System.Random rnd = new Random(DateTime.Now.Millisecond);

            char[] Letras ={'0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
            'o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
            'O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            string strAlfanumericos = "";
            for (int i = 0; i < 6; i++)
            {
                strAlfanumericos += Letras[rnd.Next(0, Letras.Length) - 1].ToString();
            }
            label8.Text = strAlfanumericos;//MUESTRA EN LABEL VALOR ALFANUMERICO (FOLIO REPORTE)
            //----------FIN ALFANUMERICO------------
            this.label6.Text = this.monthCalendar1.SelectionRange.Start.ToShortDateString();//MUESTRA FECHA EN LABEL
            //----------CAPTURA HORA, , MINUTOS Y SEGUNDOS------------
            TimeSpan hora = dateTimePicker1.Value.TimeOfDay;
            DateTime dia = dateTimePicker1.Value.Date;
            DateTime horaFinal = new DateTime(dia.Year, dia.Month, dia.Day, hora.Hours, hora.Minutes, hora.Seconds);
            //--------FIN DE CAPTURA----------
            label7.Text = this.dateTimePicker1.Value.TimeOfDay.ToString();//MUESTRA EN LABEL LA HORA
         
        }

        private void button1_Click(object sender, EventArgs e)
        {//Se prepara un nuevo mensaje
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //Se establece el destinatario
            msg.To.Add("mistick_inquisidor@hotmail.com");
            //Se establece el remitente, asi como el nombre que aparecerá en la bandeja de entrada, así como el formato de codificación
            msg.From = new MailAddress("ashantireyes041291@hotmail.com", "", System.Text.Encoding.ASCII);
            //Se establece el asunto del mail
            msg.Subject = "otro mas";
            //Formato de codificación del Asunto
            msg.SubjectEncoding = System.Text.Encoding.ASCII;
            //Se establece el cuerpo del mail
            string cuerpo = textBox2.Text + "\n" + textBox3.Text + "\n" + comboBox1.Text + "\n" + textBox4.Text + "\n" + tbMsj.Text + "\n" + label8.Text + "\n" + label6.Text + "\n" + label7.Text;

            msg.Body = cuerpo;
            //Se establece la codificación del Cuerpo
            msg.BodyEncoding = System.Text.Encoding.ASCII;
            //Se indica si al cuerpo del mail, se interpretara como código HTMl o no, esto funciona cuando queremos que aparezca centrado algo
            //mediante
            msg.IsBodyHtml = false;
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


