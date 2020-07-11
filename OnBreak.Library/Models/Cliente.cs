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
        private string _rutCliente;
        private string _nombreContacto;
        private string _razonSocial;
        private string _mailContacto;
        private string _direccion;
        private string _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set 
            {
                if(int.TryParse(value, out _) == false ||
                    value.Length < 9)
                {
                    throw new ArgumentException("El teléfono no es válido, verifica que estén todos los dígitos");
                }
                _telefono = value; 
            }
        }

        public string Direccion
        {
            get { return _direccion; }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Debes ingresar todos los campos obligatorios");
                }
                _direccion = value.ToUpper(); 
            }
        }

        public string MailContacto
        {
            get { return _mailContacto; }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Debes ingresar todos los campos obligatorios");
                }
                else if (!value.Contains("@"))
                {
                    throw new ArgumentException("El correo ingresado no es válido");
                }
                _mailContacto = value.ToUpper(); 
            }
        }

        public string RazonSocial
        {
            get { return _razonSocial; }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Debes ingresar todos los campos obligatorios");
                }
                _razonSocial = value.ToUpper(); 
            }
        }

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set 
            { 
                if(value == string.Empty)
                {
                    throw new ArgumentException("Debes ingresar todos los campos obligatorios");
                }
                _nombreContacto = value.ToUpper(); 
            }
        }

        public string RutCliente
        {
            get { return _rutCliente; }
            set 
            {
                if (value.Length == 9 && int.TryParse(value.Substring(0, 8), out _) &&
                    (int.TryParse(value.Substring(8, 1), out _) || 
                    value.Substring(8, 1).ToUpper() == "K"))
                {
                    _rutCliente = value.ToUpper();
                }
                else
                {
                    throw new ArgumentException("El rut no tiene un formato válido");
                }
            }
        }

        public ActividadEmpresa ActividadEmpresa { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }

        public Cliente()
        {

        }

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
                               where c.RutCliente == rut.ToUpper()
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
                throw new ArgumentException("Este cliente ya existe");
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
                                      where c.RutCliente.Contains(rut.ToUpper())
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
