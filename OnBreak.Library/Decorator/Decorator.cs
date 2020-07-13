using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Decorator
{
    public abstract class Decorator : Valorizador
    {
        protected Valorizador _valorizador;
        public Decorator(Valorizador valorizador)
        {
            this._valorizador = valorizador;
        }

        public override double CalcularValorEvento()
        {
            return _valorizador.CalcularValorEvento();
        }
    }
}
