using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    public class Valorizador
    {
        Cliente cliente = new Cliente();
        OnBreakDBEntities db = new OnBreakDBEntities();

        public double CalcularValorEvento(Contrato contrato)
        {
            var m = (from a in db.ModalidadServicio
                     where a.IdModalidad == contrato.ModalidadServicio.IdModalidad
                     && a.IdTipoEvento == contrato.ModalidadServicio.TipoEvento.IdTipoEvento
                     select a).FirstOrDefault();

            double total = m.ValorBase;

            if (contrato.Asistentes >= 1 && contrato.Asistentes <= 20)
            {
                total = total + 3;
            }
            else if (contrato.Asistentes >= 21 && contrato.Asistentes <= 50)
            {
                total = total + 5;
            }
            else if (contrato.Asistentes > 50)
            {
                total = 5 + total + ((contrato.Asistentes - 50) / 20) * 2;
            }

            if (contrato.PersonalAdicional == 2)
            {
                total = total + 2;
            }
            else if (contrato.PersonalAdicional == 3)
            {
                total = total + 3;
            }
            else if (contrato.PersonalAdicional == 4)
            {
                total = total + 3.5;
            }
            else if (contrato.PersonalAdicional > 4)
            {
                total = 3.5 + total + (contrato.PersonalAdicional - 4) * 0.5;
            }

            return total;
        }
    }
}
