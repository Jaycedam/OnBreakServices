using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Models
{
    [Serializable]
    public class CoffeeBreak
    {
        public Contrato Contrato { get; set; }
        public bool Vegetariana { get; set; }
    }
}
