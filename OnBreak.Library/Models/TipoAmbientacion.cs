using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Library.Models
{
    [Serializable]
    public class TipoAmbientacion
    {
        public int Id { get; set; }
        public string Desc { get; set; }

        public TipoAmbientacion()
        {

        }

        public List<TipoAmbientacion> ReadAll()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            List<TipoAmbientacion> tipoAmbientacion = (from a in db.TipoAmbientacion
                                                        select new TipoAmbientacion
                                                        {
                                                            Id = a.IdTipoAmbientacion,
                                                            Desc = a.Descripcion
                                                        }).ToList();
            return tipoAmbientacion;
        }

    }
}
