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
        Random rnd = new Random();
        private List<int> usadas;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cargar 1
            int num = rnd.Next(1, 4);
            preguntaActual = _negocio.devolverPregunta(num);

            //Añadir id de esa pregunta a un array de usadas
            usadas = new List<int>();
            usadas.Add(num);

            //Cargar la pregunta en lblPregunta y sus respuestas en los btns
            lblPregunta.Text = preguntaActual.DESCRIPCION;

            respuestasActuales = _negocio.devolverRespuestas(preguntaActual.IDPREGUNTA);
            List<Respuesta> respuestasInsertadas = new List<Respuesta>();
            foreach (Control X in this.Controls)
            {
                if (X is Button & X.Text == "")
                {
                    foreach (Respuesta resp in respuestasActuales)
                    {
                        if (!(respuestasInsertadas.Contains(resp)))
                        {
                            X.Text = resp.DESCRIPCION;
                        }
                    }
                }

            }
        }
    }
}
