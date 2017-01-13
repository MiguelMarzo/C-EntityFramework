using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        private Negocio _negocio = new Negocio();
        private List<Pregunta> preguntas;
        private Pregunta preguntaActual;
        private List<Respuesta> respuestasActuales;
        private List<Respuesta> respuestasInsertadas = new List<Respuesta>();
        private Random rnd = new Random();
        private int puntos;
        private int contAcertadas;
        private int contErrores;
        private int maxPregunta;
        private int max;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblExplicacion.Text = "";
            preguntas = _negocio.devolverPreguntas();
            contAcertadas = 0;
            puntos = 0;
            contErrores = 0;
            lblPuntos.Text = puntos.ToString();
            lblPuntos.BackColor = Color.Gold;
            maxPregunta = 3;
            //Cargar 1
            int num = rnd.Next(0, maxPregunta);
            preguntaActual = preguntas[num];

            //Cargar la pregunta en lblPregunta y sus respuestas en los btns
            lblPregunta.Text = preguntaActual.DESCRIPCION;
            lblPregunta.BackColor = Color.Gold;

            respuestasActuales = _negocio.devolverRespuestas(preguntaActual.IDPREGUNTA);
            max = 12;
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
            btnResp1.Click += btn_Click;
            btnResp2.Click += btn_Click;
            btnResp3.Click += btn_Click;
            btnResp4.Click += btn_Click;
            btnResp5.Click += btn_Click;
            btnResp6.Click += btn_Click;
            btnResp7.Click += btn_Click;
            btnResp8.Click += btn_Click;
            btnResp9.Click += btn_Click;
            btnResp10.Click += btn_Click;
            btnResp11.Click += btn_Click;
            btnResp12.Click += btn_Click;
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
                    pasarPregunta();
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
                    pasarPregunta();
                }
            }
        }
        private void btnPasar_Click(object sender, EventArgs e)
        {
            pasarPregunta();
        }

        private void pasarPregunta()
        {
            contAcertadas = 0;
            preguntas.Remove(preguntaActual);
            maxPregunta--;
            if(preguntas.Count == 0)
            {
                MessageBox.Show("NO HAY MAS PREGUNTAS");
                return;
            }
            int num = rnd.Next(0, maxPregunta);
            preguntaActual = preguntas[num];
            foreach (Control X in this.Controls)
            {
                if (X is Button)
                {
                    X.Enabled = true;
                    X.BackColor = Color.Transparent;
                }
            }
            lblPregunta.Text = preguntaActual.DESCRIPCION;
            lblPregunta.BackColor = Color.Gold;
            respuestasActuales = _negocio.devolverRespuestas(preguntaActual.IDPREGUNTA);
            max = 12;
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Name.StartsWith("btnResp"))
                {
                    int num2 = rnd.Next(0, max);
                    X.Text = respuestasActuales[num2].DESCRIPCION;
                    respuestasInsertadas.Add(respuestasActuales[num2]);
                    respuestasActuales.Remove(respuestasActuales[num2]);
                    max = max - 1;

                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
