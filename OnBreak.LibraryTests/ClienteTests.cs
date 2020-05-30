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
        // VALIDA QUE ENTREGA FALSE AL FALTAR CAMPOS OBLIGATORIOS
        [TestMethod()]
        public void CreateTest_MissingValues_ReturnsFalse()
        {
            // Arrange
            Cliente cliente = new Cliente()
            {
                RutCliente = "156845268",
                Direccion = "av",
                NombreContacto = "J",
                Telefono = "555"
            };
            // Act
            bool actual = cliente.Create(cliente);

            // Assert
            Assert.IsFalse(actual);
        }

        // ENTREGA TRUE AL CREAR CLIENTE EN DB
        [TestMethod()]
        public void CreateTest_Correct_ReturnsTrue()
        {
            // Arrange
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
            // Act
            bool actual = cliente.Create(cliente);

            // Assert
            Assert.IsTrue(actual);
        }

        // ENTREGA FALSE AL REGISTRAR UN RUT QUE YA EXISTE EN LA DB
        [TestMethod()]
        public void CreateTest_ExistingRut_ReturnsFalse()
        {
            // Arrange
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
            // Act
            bool actual = cliente.Create(cliente);

            // Assert
            Assert.IsFalse(actual);
        }

        // BUSCAR RUT NO ENCONTRADO, RETORNA NULL
        [TestMethod()]
        public void ReadTest_NotFound_ReturnsNull()
        {
            // Arrange
            Cliente cliente = new Cliente();
            string rut = "184565845";

            // Act
            Cliente actual = cliente.Read(rut);

            // Assert
            Assert.IsNull(actual);
        }

        // BUSCAR RUT ENCONTRADO, ENTREGA CLIENTE
        [TestMethod()]
        public void ReadTest_Correct_ReturnsNotNull()
        {
            // Arrange
            Cliente cliente = new Cliente();
            string rut = "190040399";

            // Act
            Cliente actual = cliente.Read(rut);

            // Assert
            Assert.IsNotNull(actual);
        }

        // ACTUALIZAR CLIENTE, NO SE ENCUENTRA CLIENTE, ENTREGA FALSE
        [TestMethod()]
        public void UpdateTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Cliente cliente = new Cliente()
            {
                RutCliente = "184565845",
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
            // Act
            bool actual = cliente.Update(cliente);

            // Assert
            Assert.IsFalse(actual);
        }

        // ACTUALIZAR CLIENTE, CORRECTO ENTREGA TRUE
        [TestMethod()]
        public void UpdateTest_Correct_ReturnsTrue()
        {
            // Arrange
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

            // Act
            bool actual = cliente.Update(cliente);

            // Assert
            Assert.IsTrue(actual);
        }

        // ACTUALIZAR CLIENTE ENTREGA FALSE AL FALTAR CAMPOS OBLIGATORIOS
        [TestMethod()]
        public void UpdateTest_MissingValues_ReturnsFalse()
        {
            // Arrange
            Cliente cliente = new Cliente()
            {
                RutCliente = "125684585",
                Direccion = "av",
                NombreContacto = "J",
                Telefono = "555"
            };

            // Act
            bool actual = cliente.Update(cliente);

            // Assert
            Assert.IsFalse(actual);
        }

        // BUSCAR POR RUT, ENCONTRADO ENTREGA TRUE
        [TestMethod()]
        public void ReadAllByRutTest_Found_ReturnsTrue()
        {
            // Arrange
            Cliente cliente = new Cliente();
            string rut = "190040399";

            // Act
            bool actual;
            if (cliente.ReadAllByRut(rut).Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            // Asert
            Assert.IsTrue(actual);
        }

        // BUSCAR POR RUT, NO ENCONTRADO ENTREGA FALSE
        [TestMethod()]
        public void ReadAllByRutTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Cliente cliente = new Cliente();
            string rut = "186652356";

            // Act
            bool actual;
            if (cliente.ReadAllByRut(rut).Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Asert
            Assert.IsFalse(actual);
        }

        // BUSCAR POR TIPO DE EMPRESA, ENCONTRADO ENTREGA TRUE
        [TestMethod()]
        public void ReadAllByTipoEmpresaTest_Found_ReturnsTrue()
        {
            // Arrange
            Cliente cliente = new Cliente();
            int tipo = 10;

            // Act
            bool actual;
            if (cliente.ReadAllByTipoEmpresa(tipo).Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }
            // Asert
            Assert.IsNotNull(actual);
        }

        // BUSCAR POR TIPO DE EMPRESA, NO ENCONTRADO ENTREGA FALSE
        [TestMethod()]
        public void ReadAllByTipoEmpresaTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Cliente cliente = new Cliente();
            int tipo = 30;

            // Act
            bool actual;
            if (cliente.ReadAllByTipoEmpresa(tipo).Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Asert
            Assert.IsFalse(actual);
        }

        // BUSCAR POR ACT DE EMPRESA, ENCONTRADO ENTREGA TRUE
        [TestMethod()]
        public void ReadAllByActividadEmpresaTest_Found_ReturnsTrue()
        {
            // Arrange
            Cliente cliente = new Cliente();
            int act = 1;

            // Act
            bool actual;
            if (cliente.ReadAllByActividadEmpresa(act).Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            // Asert
            Assert.IsNotNull(actual);
        }

        // BUSCAR POR ACT DE EMPRESA, NO ENCONTRADO ENTREGA FALSE
        [TestMethod()]
        public void ReadAllByActividadEmpresaTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Cliente cliente = new Cliente();
            int act = 3;

            // Act
            bool actual;
            if (cliente.ReadAllByActividadEmpresa(act).Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Asert
            Assert.IsFalse(actual);
        }

        // ELIMINAR CLIENTE, RUT NO ENCONTRADO ENTREGA FALSE
        [TestMethod()]
        public void DeleteTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Cliente cliente = new Cliente();
            string rut = "184565845";

            // Act
            bool actual = cliente.Delete(rut);

            // Assert
            Assert.IsFalse(actual);
        }

        // ELIMINAR CLIENTE, RUT ENCONTRADO Y ELIMINADO, ENTREGA TRUE
        [TestMethod()]
        public void DeleteTest_Correct_ReturnsTrue()
        {

            // Arrange
            Contrato contrato = new Contrato();
            Cliente cliente = new Cliente();
            string rut = "156845268";

            // Act
            bool actual = cliente.Delete(rut);

            // Assert
            Assert.IsTrue(actual);
        }

        // ELIMINAR CLIENTE, RUT TIENE CONTRATOS ASOCIADOS, NO SE ELIMINA, ENTREGA FALSE
        [TestMethod()]
        public void DeleteTest_ContratosAsociados_ReturnsFalse()
        {
            // Arrange
            Contrato contrato = new Contrato();
            Cliente cliente = new Cliente();
            string rut = "190040399";

            // Act
            bool actual;
            if (contrato.ContratosAsociados(rut))
            {
                actual = false;
            }
            else
            {
                actual = cliente.Delete(rut);
            }
            
            // Assert
            Assert.IsFalse(actual);
        }
    }
}