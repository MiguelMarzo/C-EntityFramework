using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Respuesta> devolverRespuestas(int idPregunta)
        {
            var respuestas = from resp in contexto.Respuestas
                             where resp.IDPREGUNTA == idPregunta
                             select resp;
            return respuestas.ToList();
        }

    }
}
