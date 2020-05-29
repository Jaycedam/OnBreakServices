using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        OnBreakDBEntities db = new OnBreakDBEntities();

        // Listar users
        public List<Usuario> ReadAll()
        {
            return (from u in db.Usuario
                    select new Usuario
                    {
                        Id = u.Id,
                        User = u.User,
                        Password = u.Password
                    }).ToList();
        }
        public bool Login(Usuario usuario)
        {
            var user = (from c in ReadAll()
                        where c.User == usuario.User
                        && c.Password == usuario.Password
                        select c).FirstOrDefault();

            // si no encuentra el usuario retorna false
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public bool Register(Usuario usuario)
        {
            var user = (from u in ReadAll()
                        where u.User == usuario.User
                        select u).FirstOrDefault();
            // si existe retorna falso
            if (user != null)
            {
                return false;
            }
            try
            {
                Datos.Usuario u = new Datos.Usuario();
                u.User = usuario.User.ToLower();
                u.Password = usuario.Password;

                db.Usuario.Add(u);
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
