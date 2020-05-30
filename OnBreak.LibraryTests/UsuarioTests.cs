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
        public void LoginTest_Correct_ReturnsTrue()
        {
            // Arrange
            Usuario usuario = new Usuario()
            {
                User = "admin",
                Password = "admin"
            };
            // Act
            bool actual = usuario.Login(usuario);

            // Assert
            Assert.IsTrue(actual);
        }

        // metodo para iniciar sesión, retorna false si no se valida user + pass
        [TestMethod()]
        public void LoginTest_Failed_ReturnsFalse()
        {    
            // Arrange
            Usuario usuario = new Usuario()
            {
                User = "admins",
                Password = "admin"
            };
            // Act
            bool actual = usuario.Login(usuario);

            // Assert
            Assert.IsFalse(actual);
        }

        // metodo para registrar usuario, retorna true si se guarda correctamente
        [TestMethod()]
        public void RegisterTest_Correct_ReturnsTrue()
        {
            // Arrange
            Usuario usuario = new Usuario()
            {
                User = "jay",
                Password = "jay"
            };

            // Act
            bool actual = usuario.Register(usuario);

            // Assert
            Assert.IsTrue(actual);
        }

        // metodo para registrar usuario, retorna false si se el user ya existe
        [TestMethod()]
        public void RegisterTest_Failed_ReturnsFalse()
        {
            // Arrange
            Usuario usuario = new Usuario()
            {
                User = "admin",
                Password = "admin"
            };
            // Act
            bool actual = usuario.Register(usuario);

            // Assert
            Assert.IsFalse(actual);
        }

    }
}