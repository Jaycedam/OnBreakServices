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
    public class ClienteTests
    {
        [TestMethod()]
        public void CreateTest_MissingValues()
        {
            Cliente cliente = new Cliente()
            {
                RutCliente = "156845268",
                Direccion = "av",
                NombreContacto = "J",
                Telefono = "555"
            };
            // Arrange
            bool expected = false;

            // Act
            bool actual = cliente.Create(cliente);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateTest_Correct()
        {
            Cliente cliente = new Cliente()
            {
                RutCliente = "156845268",
                Direccion = "av",
                NombreContacto = "J",
                Telefono = "555",
                MailContacto = "mail",
                RazonSocial = "rz",
                ActividadEmpresa = new ActividadEmpresa()
                {
                    IdActividadEmpresa = 1
                },
                TipoEmpresa = new TipoEmpresa()
                {
                    IdTipoEmpresa = 10
                }
            };
            // Arrange
            bool expected = true;

            // Act
            bool actual = cliente.Create(cliente);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateTest_ExistingRut()
        {
            Cliente cliente = new Cliente()
            {
                RutCliente = "190040399",
                Direccion = "av",
                NombreContacto = "J",
                Telefono = "555",
                MailContacto = "mail",
                RazonSocial = "rz",
                ActividadEmpresa = new ActividadEmpresa()
                {
                    IdActividadEmpresa = 1
                },
                TipoEmpresa = new TipoEmpresa()
                {
                    IdTipoEmpresa = 10
                }
            };
            // Arrange
            bool expected = false;

            // Act
            bool actual = cliente.Create(cliente);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteTest_WithContract()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = false;
            string rut = "190040399";

            // Act
            bool actual = cliente.Delete(rut);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteTest_Correct()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = true;
            string rut = "145324262";

            // Act
            bool actual = cliente.Delete(rut);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReadTest_NotFound()
        {
            Cliente cliente = new Cliente();
            // Arrange
            Cliente expected = null;
            string rut = "184565845";

            // Act
            Cliente actual = cliente.Read(rut);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReadTest_Correct()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = true;
            string rut = "190040399";

            // Act
            bool actual;
            if (cliente.Read(rut) != null)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod()]
        //public void UpdateTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ReadAllByRutTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ReadAllByTipoEmpresaTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ReadAllByActividadEmpresaTest()
        //{
        //    Assert.Fail();
        //}
    }
}