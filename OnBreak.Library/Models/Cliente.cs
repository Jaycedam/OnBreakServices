using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    [Serializable]
    public class Cliente
    {
        public string RutCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public ActividadEmpresa ActividadEmpresa { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }

        // Listar clientes
        public List<Cliente> ReadAll()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            return (from c in db.Cliente
                    select new Cliente
                    {
                        RutCliente = c.RutCliente,
                        RazonSocial = c.RazonSocial,
                        NombreContacto = c.NombreContacto,
                        MailContacto = c.MailContacto,
                        Direccion = c.Direccion,
                        Telefono = c.Telefono,
                        ActividadEmpresa = new ActividadEmpresa()
                        {
                            IdActividadEmpresa = c.IdActividadEmpresa,
                            Descripcion = c.ActividadEmpresa.Descripcion
                        },
                        TipoEmpresa = new TipoEmpresa()
                        {
                            IdTipoEmpresa = c.IdTipoEmpresa,
                            Descripcion = c.TipoEmpresa.Descripcion
                        }
                    }).ToList();
        }

        public Cliente Read(string rut)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            Cliente cliente = (from c in db.Cliente
                               where c.RutCliente == rut
                               select new Cliente
                               {
                                   RutCliente = c.RutCliente,
                                   Direccion = c.Direccion,
                                   MailContacto = c.MailContacto,
                                   NombreContacto = c.NombreContacto,
                                   RazonSocial = c.RazonSocial,
                                   Telefono = c.Telefono,
                                   ActividadEmpresa = new ActividadEmpresa()
                                   {
                                       IdActividadEmpresa = c.IdActividadEmpresa,
                                       Descripcion = c.ActividadEmpresa.Descripcion
                                   },
                                   TipoEmpresa = new TipoEmpresa()
                                   {
                                       IdTipoEmpresa = c.IdTipoEmpresa,
                                       Descripcion = c.TipoEmpresa.Descripcion
                                   }
                               }).FirstOrDefault();
            return cliente;
        }

        public bool Create(Cliente cliente)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            if (Read(cliente.RutCliente) != null)
            {
                return false;
            }
            try
            {
                Datos.Cliente c = new Datos.Cliente();
                c.RutCliente = cliente.RutCliente;
                c.RazonSocial = cliente.RazonSocial;
                c.NombreContacto = cliente.NombreContacto;
                c.MailContacto = cliente.MailContacto;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;
                c.IdActividadEmpresa = cliente.ActividadEmpresa.IdActividadEmpresa;
                c.IdTipoEmpresa = cliente.TipoEmpresa.IdTipoEmpresa;

                db.Cliente.Add(c);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Cliente cliente)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            try
            {
                Datos.Cliente c = (from cdb in db.Cliente
                                   where cdb.RutCliente == cliente.RutCliente
                                   select cdb).FirstOrDefault();

                if (c == null)
                {
                    return false;
                }

                c.RazonSocial = cliente.RazonSocial;
                c.NombreContacto = cliente.NombreContacto;
                c.MailContacto = cliente.MailContacto;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;
                c.IdActividadEmpresa = cliente.ActividadEmpresa.IdActividadEmpresa;
                c.IdTipoEmpresa = cliente.TipoEmpresa.IdTipoEmpresa;


                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string rut)
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            Datos.Cliente cliente = (from c in db.Cliente
                                     where c.RutCliente == rut
                                     select c).FirstOrDefault();
            if (cliente == null)
            {
                return false;
            }
            try
            {
                db.Cliente.Remove(cliente);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // FILTRAR CLIENTES
        public List<Cliente> ReadAllByRut(string rut)
        {
            List<Cliente> clientes = (from c in ReadAll()
                                      where c.RutCliente.Contains(rut)
                                      select c).ToList();
            return clientes;
        }
        public List<Cliente> ReadAllByTipoEmpresa(int tipoEmpresaId)
        {
            List<Cliente> clientes = (from c in ReadAll()
                                      where c.TipoEmpresa.IdTipoEmpresa == tipoEmpresaId
                                      select c).ToList();
            return clientes;
        }
        public List<Cliente> ReadAllByActividadEmpresa(int actId)
        {
            List<Cliente> clientes = (from c in ReadAll()
                                      where c.ActividadEmpresa.IdActividadEmpresa == actId
                                      select c).ToList();
            return clientes;
        }

    }
}
