using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    [Serializable]
    public abstract class Valorizador 
    {
        public Contrato Contrato { get; set; }

        public Valorizador()
        {

        }

        public abstract double CalcularValorEvento();
    }
}
