using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Models
{
    [Serializable]
    public class Cenas
    {
        public Contrato Contrato { get; set; }
        public TipoAmbientacion TipoAmbientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool LocalOnBreak { get; set; }
        public bool OtroLocalOnBreak { get; set; }
        public float ValorArriendo { get; set; }


    }
}
