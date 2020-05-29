using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    public class TipoEvento
    {
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }

        OnBreakDBEntities db = new OnBreakDBEntities();

        // Listar tipos de evento
        public List<TipoEvento> ReadAll()
        {
            List<TipoEvento> tipoEventos = (from t in db.TipoEvento
                                            select new TipoEvento
                                            {
                                                IdTipoEvento = t.IdTipoEvento,
                                                Descripcion = t.Descripcion
                                            }).ToList();
            return tipoEventos;
        }

    }
}
