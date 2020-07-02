using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Models
{
    [Serializable]
    public class Cocktail
    {
        public Contrato Contrato { get; set; }
        public TipoAmbientacion TipoAmbientacion { get; set; }
        public bool Ambientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool MusicaCliente { get; set; }
    }
}
