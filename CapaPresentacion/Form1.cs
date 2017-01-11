using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        private Negocio _negocio = new Negocio();
        private Pregunta preguntaActual;
        private List<Respuesta> respuestasActuales;
        List<Respuesta> respuestasInsertadas = new List<Respuesta>();
        Random rnd = new Random();
        private List<int> usadas;
        int puntos;
        int contAcertadas;
        int contErrores;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contAcertadas = 0;
            puntos = 0;
            contErrores = 0;
            lblPuntos.Text = puntos.ToString();
            //Cargar 1
            int num = rnd.Next(1, 4);
            preguntaActual = _negocio.devolverPregunta(num);

            //Añadir id de esa pregunta a un array de usadas
            usadas = new List<int>();
            usadas.Add(num);

            //Cargar la pregunta en lblPregunta y sus respuestas en los btns
            lblPregunta.Text = preguntaActual.DESCRIPCION;

            respuestasActuales = _negocio.devolverRespuestas(preguntaActual.IDPREGUNTA);
            int max = 12;
            foreach (Control X in this.Controls)
            {
                if (X is Button & X.Text == "")
                {
                    int num2 = rnd.Next(0, max);
                    X.Text = respuestasActuales[num2].DESCRIPCION;
                    respuestasInsertadas.Add(respuestasActuales[num2]);
                    respuestasActuales.Remove(respuestasActuales[num2]);
                    max = max - 1;
                    
                }

            }
            btn1.Click += btn_Click;
            btn2.Click += btn_Click;
            btn3.Click += btn_Click;
            btn4.Click += btn_Click;
            btn5.Click += btn_Click;
            btn6.Click += btn_Click;
            btn7.Click += btn_Click;
            btn8.Click += btn_Click;
            btn9.Click += btn_Click;
            btn10.Click += btn_Click;
            btn11.Click += btn_Click;
            btn12.Click += btn_Click;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Respuesta resp = _negocio.devolverRespuestaPorDescripcion(btn.Text);
            if (resp.DESCRIPCION == btn.Text && resp.EXPLICACION == "VERDADERA")
            {
                btn.BackColor = Color.Green;
                lblExplicacion.Text = resp.EXPLICACION;
                btn.Enabled = false;
                contAcertadas++;
                puntos += 5 * contAcertadas;
                lblPuntos.Text = puntos.ToString();
                if ( contAcertadas == 8 )
                {
                    MessageBox.Show("Ya has acertado todas las respuestas");
                }

            }
            else
            {
                btn.Enabled = false;
                btn.BackColor = Color.Red;
                lblExplicacion.Text = resp.EXPLICACION;
                puntos = puntos / 2;
                lblPuntos.Text = puntos.ToString();
                contErrores++;
                if (contErrores == 4)
                {
                    MessageBox.Show("Ya has fallado todas las posibles respuestas erroneas");
                }
            }
        }
    }
}
