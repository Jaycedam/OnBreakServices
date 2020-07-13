using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Decorator
{
    public class CocktailDecorator : Decorator
    {
        public int Ambientacion { get; set; }
        public bool MusicaAmbiental { get; set; }

        private double _montoAdicional;

        public CocktailDecorator(Valorizador valorizador)
            :base(valorizador)
        {
            
        }

        private double GetAmmount()
        {
            _montoAdicional = 0;
            // Ambientacion
            if (Ambientacion == 10)
            {
                _montoAdicional += 2;
            }
            else if (Ambientacion == 20)
            {
                _montoAdicional += 5;
            }
            // Musica Ambiental
            if (MusicaAmbiental)
            {
                _montoAdicional += 1;
            }

            return _montoAdicional;
        }

        public override double CalcularValorEvento()
        {
            return base.CalcularValorEvento() + GetAmmount();
        }
    }
}
