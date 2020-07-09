using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnBreak.Library.Models
{
    [Serializable]
    public class Cenas : Valorizador
    {
        public TipoAmbientacion TipoAmbientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool LocalOnBreak { get; set; }
        public bool OtroLocalOnBreak { get; set; }
        public double ValorArriendo { get; set; }

        public override double CalcularValorEvento()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            var m = (from a in db.ModalidadServicio
                     where a.IdModalidad == Contrato.ModalidadServicio.IdModalidad
                     && a.IdTipoEvento == 30
                     select a).FirstOrDefault();

            double total = m.ValorBase;

            if (Contrato.Asistentes >= 1 && Contrato.Asistentes <= 20)
            {
                total = total + 1.5;
            }
            else if (Contrato.Asistentes >= 21 && Contrato.Asistentes <= 50)
            {
                total = total + 1.2;
            }
            else if (Contrato.Asistentes > 50)
            {
                total = Contrato.Asistentes - 50;
            }

            if (Contrato.PersonalAdicional == 2)
            {
                total = total + 3;
            }
            else if (Contrato.PersonalAdicional == 3)
            {
                total = total + 4;
            }
            else if (Contrato.PersonalAdicional == 4)
            {
                total = total + 5;
            }
            else if (Contrato.PersonalAdicional > 4)
            {
                total = 5 + total + (Contrato.PersonalAdicional - 4) * 0.5;
            }

            return total;
        }

        public Cenas Read(string numContrato)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            Cenas cenas = (from c in db.Cenas
                                       where c.Numero == numContrato
                                       select new Cenas
                                       {
                                           Contrato = new Contrato()
                                           {
                                               Numero = c.Numero
                                           },
                                           MusicaAmbiental = c.MusicaAmbiental,
                                           LocalOnBreak = c.LocalOnBreak,
                                           OtroLocalOnBreak = c.OtroLocalOnBreak,
                                           ValorArriendo = c.ValorArriendo,
                                           TipoAmbientacion = new TipoAmbientacion()
                                           {
                                               Id = c.TipoAmbientacion.IdTipoAmbientacion
                                           }
                                       }).FirstOrDefault();
            return cenas;
        }

        public bool Create(Cenas cenas)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            Cenas cena = new Cenas();
            try
            {
                Datos.Cenas c = new Datos.Cenas();
                c.Numero = cenas.Contrato.Numero;
                c.LocalOnBreak = cenas.LocalOnBreak;
                c.MusicaAmbiental = cenas.MusicaAmbiental;
                c.OtroLocalOnBreak = cenas.OtroLocalOnBreak;
                c.ValorArriendo = cenas.ValorArriendo;
                c.IdTipoAmbientacion = cenas.TipoAmbientacion.Id;

                db.Cenas.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Cenas cenas)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            try
            {
                Datos.Cenas c = (from cb in db.Cenas
                                       where cb.Numero == cenas.Contrato.Numero
                                       select cb).FirstOrDefault();

                c.Numero = cenas.Contrato.Numero;
                c.LocalOnBreak = cenas.LocalOnBreak;
                c.MusicaAmbiental = cenas.MusicaAmbiental;
                c.OtroLocalOnBreak = cenas.OtroLocalOnBreak;
                c.ValorArriendo = cenas.ValorArriendo;
                c.IdTipoAmbientacion = cenas.TipoAmbientacion.Id;

                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
