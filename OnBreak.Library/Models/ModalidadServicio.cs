using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    [Serializable]
    public class ModalidadServicio
    {
        public string IdModalidad { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }

        public ModalidadServicio()
        {

        }

        // Listar modalidad con filtro por tipo de evento
        public List<ModalidadServicio> ReadAll(int tipoId)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            return (from m in db.ModalidadServicio
                    where m.IdTipoEvento == tipoId
                    select new ModalidadServicio
                    {
                        IdModalidad = m.IdModalidad,
                        Nombre = m.Nombre
                    }).ToList();
        }

    }
}
