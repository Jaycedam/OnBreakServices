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

        // ENTREGA TRUE AL CREAR CLIENTE EN DB
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

        // ENTREGA FALSE AL REGISTRAR UN RUT QUE YA EXISTE EN LA DB
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

        // BUSCAR RUT NO ENCONTRADO, RETORNA NULL
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

        // BUSCAR RUT ENCONTRADO, ENTREGA CLIENTE
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

        // ACTUALIZAR CLIENTE, NO SE ENCUENTRA CLIENTE, ENTREGA FALSE
        [TestMethod()]
        public void UpdateTest_NotFound()
        {
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
            // Arrange
            bool expected = false;

            // Act
            bool actual = cliente.Update(cliente);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ACTUALIZAR CLIENTE, CORRECTO ENTREGA TRUE
        [TestMethod()]
        public void UpdateTest_Correct()
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
            bool expected = true;

            // Act
            bool actual = cliente.Update(cliente);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ACTUALIZAR CLIENTE ENTREGA FALSE AL FALTAR CAMPOS OBLIGATORIOS
        [TestMethod()]
        public void UpdateTest_MissingValues()
        {
            Cliente cliente = new Cliente()
            {
                RutCliente = "125684585",
                Direccion = "av",
                NombreContacto = "J",
                Telefono = "555"
            };
            // Arrange
            bool expected = false;

            // Act
            bool actual = cliente.Update(cliente);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // BUSCAR POR RUT, ENCONTRADO ENTREGA TRUE
        [TestMethod()]
        public void ReadAllByRutTest_Found()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = true;
            string rut = "190040399";

            // Act
            bool actual;

            if(cliente.ReadAllByRut(rut).Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            // Asert
            Assert.AreEqual(expected, actual);
        }

        // BUSCAR POR RUT, NO ENCONTRADO ENTREGA FALSE
        [TestMethod()]
        public void ReadAllByRutTest_NotFound()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = false;
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
            Assert.AreEqual(expected, actual);
        }

        // BUSCAR POR TIPO DE EMPRESA, ENCONTRADO ENTREGA TRUE
        [TestMethod()]
        public void ReadAllByTipoEmpresaTest_Found()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = true;
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
            Assert.AreEqual(expected, actual);
        }

        // BUSCAR POR TIPO DE EMPRESA, NO ENCONTRADO ENTREGA FALSE
        [TestMethod()]
        public void ReadAllByTipoEmpresaTest_NotFound()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = false;
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
            Assert.AreEqual(expected, actual);
        }

        // BUSCAR POR ACT DE EMPRESA, ENCONTRADO ENTREGA TRUE
        [TestMethod()]
        public void ReadAllByActividadEmpresaTest_Found()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = true;
            int tipo = 1;

            // Act
            bool actual;

            if (cliente.ReadAllByActividadEmpresa(tipo).Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            // Asert
            Assert.AreEqual(expected, actual);
        }

        // BUSCAR POR ACT DE EMPRESA, NO ENCONTRADO ENTREGA FALSE
        [TestMethod()]
        public void ReadAllByActividadEmpresaTest_NotFound()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = false;
            int tipo = 3;

            // Act
            bool actual;

            if (cliente.ReadAllByActividadEmpresa(tipo).Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Asert
            Assert.AreEqual(expected, actual);
        }

        // ELIMINAR CLIENTE, RUT NO ENCONTRADO ENTREGA FALSE
        [TestMethod()]
        public void DeleteTest_NotFound()
        {
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = false;
            string rut = "184565845";

            // Act
            bool actual = cliente.Delete(rut);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ELIMINAR CLIENTE, RUT ENCONTRADO Y ELIMINADO, ENTREGA TRUE
        [TestMethod()]
        public void DeleteTest_Correct()
        {
            Contrato contrato = new Contrato();
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = true;
            string rut = "145324262";

            // Act
            bool actual;
            if (contrato.ContratosVigentes(rut))
            {
                actual = false;
            }
            else
            {
                actual = cliente.Delete(rut);
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ELIMINAR CLIENTE, RUT TIENE CONTRATOS ASOCIADOS, NO SE ELIMINA, ENTREGA FALSE
        [TestMethod()]
        public void DeleteTest_ContratosAsociados()
        {
            Contrato contrato = new Contrato();
            Cliente cliente = new Cliente();
            // Arrange
            bool expected = false;
            string rut = "190040399";

            // Act
            bool actual;
            if (contrato.ContratosVigentes(rut))
            {
                actual = false;
            }
            else
            {
                actual = cliente.Delete(rut);
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}