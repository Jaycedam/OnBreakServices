using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    [Serializable]
    public class Contrato
    {
        public string Numero { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public Cliente Cliente { get; set; }
        public ModalidadServicio ModalidadServicio { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }
        public string RealizadoStr
        {
            get
            {
                if (Realizado == true)
                {
                    return "Si";
                }
                return "No";
            }
        }

        public Contrato()
        {

        }

        // Listar contratos
        public List<Contrato> ReadAll()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            return (from c in db.Contrato
                    select new Contrato
                    {
                        Numero = c.Numero,
                        Creacion = c.Creacion,
                        Termino = c.Termino,
                        Cliente = new Cliente()
                        {
                            RutCliente = c.RutCliente
                        },
                        FechaHoraInicio = c.FechaHoraInicio,
                        FechaHoraTermino = c.FechaHoraTermino,
                        Asistentes = c.Asistentes,
                        PersonalAdicional = c.PersonalAdicional,
                        Realizado = c.Realizado,
                        ValorTotalContrato = c.ValorTotalContrato,
                        Observaciones = c.Observaciones,
                        ModalidadServicio = new ModalidadServicio()
                        {
                            IdModalidad = c.IdModalidad,
                            Nombre = c.ModalidadServicio.Nombre,
                            PersonalBase = c.ModalidadServicio.PersonalBase,
                            ValorBase = c.ModalidadServicio.ValorBase,
                            TipoEvento = new TipoEvento()
                            {
                                IdTipoEvento = c.ModalidadServicio.IdTipoEvento,
                                Descripcion = c.ModalidadServicio.TipoEvento.Descripcion
                            },
                        }
                    }).ToList();
        }

        public Contrato Read(string numContrato)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            Contrato contrato = (from c in db.Contrato
                                 where c.Numero == numContrato
                                 select new Contrato
                                 {
                                     Numero = c.Numero,
                                     Creacion = c.Creacion,
                                     Asistentes = c.Asistentes,
                                     FechaHoraInicio = c.FechaHoraInicio,
                                     FechaHoraTermino = c.FechaHoraTermino,
                                     Observaciones = c.Observaciones,
                                     PersonalAdicional = c.PersonalAdicional,
                                     Realizado = c.Realizado,
                                     Termino = c.Termino,
                                     ValorTotalContrato = c.ValorTotalContrato,
                                     Cliente = new Cliente()
                                     {
                                         RutCliente = c.RutCliente
                                     },
                                     ModalidadServicio = new ModalidadServicio()
                                     {
                                         IdModalidad = c.IdModalidad,
                                         Nombre = c.ModalidadServicio.Nombre,
                                         PersonalBase = c.ModalidadServicio.PersonalBase,
                                         ValorBase = c.ModalidadServicio.ValorBase,
                                         TipoEvento = new TipoEvento()
                                         {
                                             IdTipoEvento = c.ModalidadServicio.IdTipoEvento,
                                             Descripcion = c.ModalidadServicio.TipoEvento.Descripcion
                                         }
                                     }

                                 }).FirstOrDefault();
            return contrato;
        }

        public bool Create(Contrato contrato)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            Cliente cliente = new Cliente();
            // si no se encuentra el cliente retorna falso
            if (cliente.Read(contrato.Cliente.RutCliente) == null)
            {
                return false;
            }
            try
            {
                Datos.Contrato c = new Datos.Contrato();
                c.Numero = contrato.Numero;
                c.Creacion = contrato.Creacion;
                c.Termino = contrato.Termino;
                c.RutCliente = contrato.Cliente.RutCliente;
                c.IdModalidad = contrato.ModalidadServicio.IdModalidad;
                c.IdTipoEvento = contrato.ModalidadServicio.TipoEvento.IdTipoEvento;
                c.FechaHoraInicio = contrato.FechaHoraInicio;
                c.FechaHoraTermino = contrato.FechaHoraTermino;
                c.Asistentes = contrato.Asistentes;
                c.PersonalAdicional = contrato.PersonalAdicional;
                c.Realizado = contrato.Realizado;
                c.ValorTotalContrato = contrato.ValorTotalContrato;
                c.Observaciones = contrato.Observaciones;


                db.Contrato.Add(c);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Contrato contrato)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            try
            {
                Datos.Contrato c = (from cdb in db.Contrato
                                    where cdb.Numero == contrato.Numero
                                    select cdb).FirstOrDefault();

                if (c == null)
                {
                    return false;
                }

                c.Observaciones = contrato.Observaciones;
                c.IdTipoEvento = contrato.ModalidadServicio.TipoEvento.IdTipoEvento;
                c.IdModalidad = contrato.ModalidadServicio.IdModalidad;
                c.Asistentes = contrato.Asistentes;
                c.PersonalAdicional = contrato.PersonalAdicional;
                c.FechaHoraInicio = contrato.FechaHoraInicio;
                c.FechaHoraTermino = contrato.FechaHoraTermino;
                c.ValorTotalContrato = contrato.ValorTotalContrato;
                c.Realizado = contrato.Realizado;

                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        // Metodo que cambia Realizado==true si encuentra el contrato
        public bool Delete(string numero)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            try
            {
                Datos.Contrato c = (from cdb in db.Contrato
                                    where cdb.Numero == numero
                                    select cdb).FirstOrDefault();

                if (c == null)
                {
                    return false;
                }

                c.Termino = DateTime.Now;

                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        // metodo que retorna true si el rut tiene contratos asociados
        public bool ContratosAsociados(string rut)
        {
            List<Contrato> contratos = (from c in ReadAll()
                                        where c.Cliente.RutCliente == rut.ToUpper()
                                        select c).ToList();

            if (contratos.Count > 0)
            {
                return true;
            }
            return false;
        }

        // FILTRAR CONTRATOS
        public List<Contrato> ReadAllByNumeroContrato(string numContrato)
        {
            List<Contrato> contratos = (from c in ReadAll()
                                        where c.Numero.Contains(numContrato)
                                        select c).ToList();
            return contratos;
        }
        public List<Contrato> ReadAllByRut(string rut)
        {
            List<Contrato> contratos = (from c in ReadAll()
                                        where c.Cliente.RutCliente.Contains(rut)
                                        select c).ToList();
            return contratos;
        }
        public List<Contrato> ReadAllByTipoEvento(int tipoEventoId)
        {
            List<Contrato> contratos = (from c in ReadAll()
                                        where c.ModalidadServicio.TipoEvento.IdTipoEvento == tipoEventoId
                                        select c).ToList();
            return contratos;
        }
        public List<Contrato> ReadAllByModalidad(string modalidadId)
        {
            List<Contrato> contratos = (from c in ReadAll()
                                        where c.ModalidadServicio.IdModalidad == modalidadId
                                        select c).ToList();
            return contratos;
        }
    }
}
