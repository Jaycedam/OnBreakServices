using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Models
{
    [Serializable]
    public class Cocktail : Valorizador
    {
        public TipoAmbientacion TipoAmbientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool MusicaCliente { get; set; }

        public override double CalcularValorEvento()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            var m = (from a in db.ModalidadServicio
                     where a.IdModalidad == Contrato.ModalidadServicio.IdModalidad
                     && a.IdTipoEvento == 20
                     select a).FirstOrDefault();

            double total = m.ValorBase;

            if (Contrato.Asistentes >= 1 && Contrato.Asistentes <= 20)
            {
                total = total + 4;
            }
            else if (Contrato.Asistentes >= 21 && Contrato.Asistentes <= 50)
            {
                total = total + 6;
            }
            else if (Contrato.Asistentes > 50)
            {
                total = 5 + total + ((Contrato.Asistentes - 50) / 20) * 2;
            }

            if (Contrato.PersonalAdicional == 2)
            {
                total = total + 2;
            }
            else if (Contrato.PersonalAdicional == 3)
            {
                total = total + 3;
            }
            else if (Contrato.PersonalAdicional == 4)
            {
                total = total + 3.5;
            }
            else if (Contrato.PersonalAdicional > 4)
            {
                total = 3.5 + total + (Contrato.PersonalAdicional - 4) * 0.5;
            }

            return total;
        }

        public Cocktail Read(string numContrato)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            var result = (from c in db.Cocktail
                                 where c.Numero == numContrato
                                 select c).FirstOrDefault();

            if(result.IdTipoAmbientacion == null)
            {
                Cocktail cocktail = new Cocktail()
                {
                    MusicaAmbiental = result.MusicaAmbiental,
                    MusicaCliente = result.MusicaCliente
                };
                return cocktail;
            }
            else
            {
                Cocktail cocktail = new Cocktail()
                {
                    TipoAmbientacion = new TipoAmbientacion()
                    {
                        Id = result.TipoAmbientacion.IdTipoAmbientacion
                    },
                    MusicaAmbiental = result.MusicaAmbiental,
                    MusicaCliente = result.MusicaCliente
                };
                return cocktail;
            }
        }

        public bool Create(Cocktail cocktail)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            try
            {
                Datos.Cocktail c = new Datos.Cocktail();

                if (cocktail.TipoAmbientacion == null)
                {
                    c.Numero = cocktail.Contrato.Numero;
                    c.MusicaAmbiental = cocktail.MusicaAmbiental;
                    c.MusicaCliente = cocktail.MusicaCliente;
                }
                else
                {
                    c.Numero = cocktail.Contrato.Numero;
                    c.MusicaAmbiental = cocktail.MusicaAmbiental;
                    c.MusicaCliente = cocktail.MusicaCliente;
                    c.IdTipoAmbientacion = cocktail.TipoAmbientacion.Id;
                }
                
                db.Cocktail.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Cocktail cocktail)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            try
            {
                Datos.Cocktail c = (from ct in db.Cocktail
                                    where ct.Numero == cocktail.Contrato.Numero
                                    select ct).FirstOrDefault();

                if (cocktail.TipoAmbientacion == null)
                {
                    c.MusicaAmbiental = cocktail.MusicaAmbiental;
                    c.MusicaCliente = cocktail.MusicaCliente;

                    db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    c.MusicaAmbiental = cocktail.MusicaAmbiental;
                    c.MusicaCliente = cocktail.MusicaCliente;
                    c.IdTipoAmbientacion = cocktail.TipoAmbientacion.Id;

                    db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
    
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
