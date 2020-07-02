using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    [Serializable]
    public class ActividadEmpresa
    {
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }


        public List<ActividadEmpresa> ReadAll()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            List<ActividadEmpresa> actividadEmpresas = (from a in db.ActividadEmpresa
                                                        select new ActividadEmpresa
                                                        {
                                                            IdActividadEmpresa = a.IdActividadEmpresa,
                                                            Descripcion = a.Descripcion
                                                        }).ToList();
            return actividadEmpresas;
        }
    }
}
