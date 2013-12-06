using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplos
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

       
        private void Form4_Load(object sender, EventArgs e)
        {//-------------INICIO ALFANUMERICO-----------------
            System.Random rnd = new Random(DateTime.Now.Millisecond);

            char[] Letras ={'0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
            'o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
            'O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            string strAlfanumericos = "";
            for (int i = 0; i <6; i++)
            {
                strAlfanumericos += Letras[rnd.Next(0, Letras.Length) - 1].ToString();
            }
            //----------FIN ALFANUMERICO------------
            label1.Text=strAlfanumericos;//MUESTRA EN LABEL VALOR ALFANUMERICO (FOLIO REPORTE)
            
            this.label2.Text = this.monthCalendar1.SelectionRange.Start.ToShortDateString();//MUESTRA FECHA EN LABEL
            //----------CAPTURA HORA, , MINUTOS Y SEGUNDOS------------
            TimeSpan hora = dateTimePicker1.Value.TimeOfDay;
            DateTime dia = dateTimePicker1.Value.Date;
            DateTime horaFinal = new DateTime(dia.Year, dia.Month, dia.Day, hora.Hours, hora.Minutes, hora.Seconds);
            //--------FIN DE CAPTURA----------
            label3.Text = this.dateTimePicker1.Value.TimeOfDay.ToString();//MUESTRA EN LABEL LA HORA
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 actualizar = new Form4();
            actualizar.Show();

            }
    }
}
