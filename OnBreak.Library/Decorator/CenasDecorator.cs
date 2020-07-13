using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Decorator
{
    public class CenasDecorator : Decorator
    {
        public int Ambientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool LocalOnBreak { get; set; }
        public double ArriendoOtroLocal { get; set; }

        private double _montoAdicional; 

        public CenasDecorator(Valorizador valorizador)
            :base(valorizador)
        {

        }

        private double GetAmmount()
        {
            _montoAdicional = 0;
            // Ambientacion
            if(Ambientacion == 10)
            {
                _montoAdicional += 3;
            }
            else if(Ambientacion == 20)
            {
                _montoAdicional += 5;
            }
            // Musica Ambiental
            if(MusicaAmbiental)
            {
                _montoAdicional += 1.5;
            }
            if(LocalOnBreak)
            {
                _montoAdicional += 9;
            }

            _montoAdicional += ArriendoOtroLocal * 1.05;

            return _montoAdicional; 
        }

        public override double CalcularValorEvento()
        {
            return base.CalcularValorEvento() + GetAmmount();
        }
    }
}
