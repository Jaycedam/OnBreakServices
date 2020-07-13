using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Library
{
    [Serializable]
    public class TipoEmpresa
    {
        public int IdTipoEmpresa { get; set; }
        public string Descripcion { get; set; }

        public TipoEmpresa()
        {

        }

        // Listar tipo empresas
        public List<TipoEmpresa> ReadAll()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            List<TipoEmpresa> tipoEmpresas = (from t in db.TipoEmpresa
                                              select new TipoEmpresa
                                              {
                                                  IdTipoEmpresa = t.IdTipoEmpresa,
                                                  Descripcion = t.Descripcion
                                              }).ToList();
            return tipoEmpresas;
        }

    }
}
