using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    public class ActividadEmpresa
    {
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }

        OnBreakDBEntities db = new OnBreakDBEntities();

        public List<ActividadEmpresa> ReadAll()
        {
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
