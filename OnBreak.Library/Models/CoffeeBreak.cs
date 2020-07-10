using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Models
{
    [Serializable]
    public class CoffeeBreak : Valorizador
    {
        public bool Vegetariana { get; set; }

        public override double CalcularValorEvento()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            var m = (from a in db.ModalidadServicio
                     where a.IdModalidad == Contrato.ModalidadServicio.IdModalidad
                     select a).FirstOrDefault();

            double total = m.ValorBase;

            if (Contrato.Asistentes >= 1 && Contrato.Asistentes <= 20)
            {
                total += 3;
            }
            else if (Contrato.Asistentes >= 21 && Contrato.Asistentes <= 50)
            {
                total += 5;
            }
            else if (Contrato.Asistentes > 50)
            {
                total += 5 + ((Contrato.Asistentes - 50) / 20) * 2;
            }

            if (Contrato.PersonalAdicional == 2)
            {
                total += 2;
            }
            else if (Contrato.PersonalAdicional == 3)
            {
                total += 3;
            }
            else if (Contrato.PersonalAdicional == 4)
            {
                total += 3.5;
            }
            else if (Contrato.PersonalAdicional > 4)
            {
                total += 3.5 + (Contrato.PersonalAdicional - 4) * 0.5;
            }

            return total;
        }

        public CoffeeBreak Read(string numContrato)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            CoffeeBreak coffeeBreak = (from c in db.CoffeeBreak
                                 where c.Numero == numContrato
                                 select new CoffeeBreak
                                 {
                                     Contrato = new Contrato()
                                     {
                                         Numero = c.Numero
                                     },
                                     Vegetariana = c.Vegetariana        
                                 }).FirstOrDefault();
            return coffeeBreak;
        }

        public bool Create(CoffeeBreak coffeeBreak)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            CoffeeBreak coffee = new CoffeeBreak();
            try
            {
                Datos.CoffeeBreak c = new Datos.CoffeeBreak();
                c.Numero = coffeeBreak.Contrato.Numero;
                c.Vegetariana = coffeeBreak.Vegetariana;

                db.CoffeeBreak.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CoffeeBreak coffeeBreak)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            try
            {
                Datos.CoffeeBreak c = (from cb in db.CoffeeBreak
                                    where cb.Numero == coffeeBreak.Contrato.Numero
                                    select cb).FirstOrDefault();

                c.Vegetariana = coffeeBreak.Vegetariana;

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
