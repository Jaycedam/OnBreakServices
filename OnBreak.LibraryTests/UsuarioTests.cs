using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnBreak.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Library.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        // metodo para iniciar sesión, retorna true si se valida user + pass
        [TestMethod()]
        public void LoginTest_Correct()
        {
            Usuario usuario = new Usuario()
            {
                User = "admin",
                Password = "admin"
            };
            // Arrange
            bool expected = true;

            // Act
            bool actual = usuario.Login(usuario);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // metodo para iniciar sesión, retorna false si no se valida user + pass
        [TestMethod()]
        public void LoginTest_Failed()
        {
            Usuario usuario = new Usuario()
            {
                User = "admins",
                Password = "admin"
            };
            // Arrange
            bool expected = false;

            // Act
            bool actual = usuario.Login(usuario);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // metodo para registrar usuario, retorna true si se guarda correctamente
        [TestMethod()]
        public void RegisterTest_Correct()
        {
            Usuario usuario = new Usuario()
            {
                User = "jay",
                Password = "jay"
            };
            // Arrange
            bool expected = true;

            // Act
            bool actual = usuario.Register(usuario);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // metodo para registrar usuario, retorna false si se el user ya existe
        [TestMethod()]
        public void RegisterTest_Failed()
        {
            Usuario usuario = new Usuario()
            {
                User = "admin",
                Password = "admin"
            };
            // Arrange
            bool expected = false;

            // Act
            bool actual = usuario.Register(usuario);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}