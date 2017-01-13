using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CapaDatos
{
    public class Datos
    {
        private SaberNoSaberEntities contexto;

        public Datos()
        {
            contexto = new SaberNoSaberEntities();
        }

        public Pregunta devolverPregunta(int idPregunta)
        {
            var pregunta = from pre in contexto.Preguntas
                           where pre.IDPREGUNTA == idPregunta
                           select pre;

            return pregunta.ToList()[0];
        }

        public List<Pregunta> devolverPreguntas()
        {
            var preguntas = from preg in contexto.Preguntas
                            select preg;
            return preguntas.ToList();
        } 

        public List<Respuesta> devolverRespuestas(int idPregunta)
        {
            var respuestas = from resp in contexto.Respuestas
                             where resp.IDPREGUNTA == idPregunta
                             select resp;
            return respuestas.ToList();
        }
        
        public Respuesta devolverRespuestaPorDescripcion(String descripcion)
        {
            var respuesta = from resp in contexto.Respuestas
                            where resp.DESCRIPCION == descripcion
                            select resp;
            return respuesta.ToList().ElementAt(0);
        }
    }
}
