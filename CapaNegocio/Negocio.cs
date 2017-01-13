using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class Negocio
    {
        private Datos _datos = new Datos();

        public Pregunta devolverPregunta(int idPregunta)
        {
            return _datos.devolverPregunta(idPregunta);
        }

        public List<Respuesta> devolverRespuestas(int idPregunta)
        {
            return _datos.devolverRespuestas(idPregunta);
        }

        public Respuesta devolverRespuestaPorDescripcion(String descripcion)
        {
            return _datos.devolverRespuestaPorDescripcion(descripcion);
        }

        public List<Pregunta> devolverPreguntas()
        {
            return _datos.devolverPreguntas();
        }
    }
}
