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
        private string _user;
        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            { 
                if(value == string.Empty ||
                    value == "contraseña")
                {
                    throw new ArgumentException("Debes ingresar un usuario y contraseña válidos");
                }
                _password = value; 
            }
        }

        public string User
        {
            get { return _user; }
            set 
            {
                if(value == string.Empty || 
                    value.ToLower().Trim() == "usuario")
                {
                    throw new ArgumentException("Debes ingresar un usuario y contraseña válidos");
                }
                _user = value.ToLower().Trim(); 
            }
        }

        public Usuario()
        {

        }

        // Listar users
        public List<Usuario> ReadAll()
        {
            OnBreakDBEntities db = new OnBreakDBEntities();
            return (from u in db.User
                    select new Usuario
                    {
                        User = u.User1,
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
            OnBreakDBEntities db = new OnBreakDBEntities();
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
                User u = new User
                {
                    User1 = usuario.User,
                    Password = usuario.Password
                };

                db.User.Add(u);
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
