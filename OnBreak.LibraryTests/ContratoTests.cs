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
    public class ContratoTests
    {
        [TestMethod()]
        public void ReadTest_NumberFound()
        {
            Contrato contrato = new Contrato();
            string numContrato = "2020050805";

            // Arrange
            bool expected = true;

            // Act
            bool actual;
            if (contrato.Read(numContrato) != null)
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

        [TestMethod()]
        public void ReadTest_NumberNotFound()
        {
            Contrato contrato = new Contrato();
            string numContrato = "2020050855";

            // Arrange
            bool expected = false;

            // Act
            bool actual;
            if (contrato.Read(numContrato) == null)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateTest_MissingValues()
        {
            Contrato contrato = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                Creacion = DateTime.Now,
                Cliente = new Cliente()
                {
                    RutCliente = "190040399"
                }
            };

            // Arrange
            bool expected = false;

            // Act
            bool actual = contrato.Create(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateTest_Correct()
        {
            Contrato contrato = new Contrato()
            {
                Numero = "2020051805",
                Creacion = DateTime.Now,
                Termino = DateTime.Now,
                Asistentes = 10,
                PersonalAdicional = 5,
                Realizado = false,
                FechaHoraInicio = DateTime.Now,
                FechaHoraTermino = DateTime.Now,
                Observaciones = "-",
                ValorTotalContrato = 50,
                Cliente = new Cliente()
                {
                    RutCliente = "190040399"
                },
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CO002",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                },
            };

            // Arrange
            bool expected = true;

            // Act
            bool actual = contrato.Create(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateTest_ClienteNotFound()
        {
            Contrato contrato = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                Creacion = DateTime.Now,
                Termino = DateTime.Now.AddDays(2),
                Asistentes = 10,
                PersonalAdicional = 5,
                Realizado = false,
                FechaHoraInicio = DateTime.Now,
                FechaHoraTermino = DateTime.Now,
                Observaciones = "-",
                ValorTotalContrato = 50,
                Cliente = new Cliente()
                {
                    RutCliente = "190040398"
                },
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CO002",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                },
            };

            // Arrange
            bool expected = false;

            // Act
            bool actual = contrato.Create(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateTest_Correct()
        {
            Contrato contrato = new Contrato()
            {
                Numero = "2020050805",
                Observaciones = "",
                FechaHoraInicio = DateTime.Now,
                FechaHoraTermino = DateTime.Now,
                Asistentes = 10,
                PersonalAdicional = 5,
                Realizado = false,
                ValorTotalContrato = 10,
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CO002",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                }

            };

            // Arrange
            bool expected = true;

            // Act
            bool actual = contrato.Update(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateTest_MissingValues()
        {
            Contrato contrato = new Contrato()
            {
                Numero = "2020050805",
                Creacion = DateTime.Now,
                Realizado = false,
                FechaHoraInicio = DateTime.Now,
                FechaHoraTermino = DateTime.Now,
                ValorTotalContrato = 50,
                Cliente = new Cliente()
                {
                    RutCliente = "190040399"
                },
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CO002",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 20
                    }
                },
            };

            // Arrange
            bool expected = false;

            // Act
            bool actual = contrato.Update(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateTest_NumberNotFound()
        {
            Contrato contrato = new Contrato()
            {
                Numero = "2020050808",
                Creacion = DateTime.Now,
                Termino = DateTime.Now.AddDays(2),
                Asistentes = 10,
                PersonalAdicional = 6,
                Realizado = false,
                FechaHoraInicio = DateTime.Now,
                FechaHoraTermino = DateTime.Now,
                Observaciones = "changed",
                ValorTotalContrato = 50,
                Cliente = new Cliente()
                {
                    RutCliente = "190040399"
                },
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CO002",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                },
            };

            // Arrange
            bool expected = false;

            // Act
            bool actual = contrato.Update(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteTest_Correct()
        {
            Contrato contrato = new Contrato();
            string num = "2020050806";

            // Arrange
            bool expected = true;

            // Act
            bool actual = contrato.Delete(num);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteTest_NumberNotFound()
        {
            Contrato contrato = new Contrato();
            string num = "2020050855";

            // Arrange
            bool expected = false;

            // Act
            bool actual = contrato.Delete(num);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ContratosVigentesTest_Yes()
        {
            Contrato contrato = new Contrato();
            string rut = "190040399";

            // Arrange
            bool expected = true;

            // Act
            bool actual = contrato.ContratosVigentes(rut);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ContratosVigentesTest_No()
        {
            Contrato contrato = new Contrato();
            string rut = "145324262";

            // Arrange
            bool expected = false;

            // Act
            bool actual = contrato.ContratosVigentes(rut);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReadAllByNumeroContratoTest_Found()
        {
            Contrato contrato = new Contrato();
            string num = "2020050805";
            
            // Arrange
            bool expected = true;

            // Act
            bool actual;
            if (contrato.ReadAllByNumeroContrato(num).Count > 0)
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

        [TestMethod()]
        public void ReadAllByNumeroContratoTest_NotFound()
        {
            Contrato contrato = new Contrato();
            string num = "2020055805";

            // Arrange
            bool expected = false;

            // Act
            bool actual;
            if (contrato.ReadAllByNumeroContrato(num).Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReadAllByRutTest_Found()
        {
            Contrato contrato = new Contrato();
            string rut = "190040399";

            // Arrange
            bool expected = true;

            // Act
            bool actual;
            if (contrato.ReadAllByRut(rut).Count > 0)
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

        [TestMethod()]
        public void ReadAllByRutTest_NotFound()
        {
            Contrato contrato = new Contrato();
            string rut = "190048899";

            // Arrange
            bool expected = false;

            // Act
            bool actual;
            if (contrato.ReadAllByRut(rut).Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReadAllByTipoEventoTest_Found()
        {
            Contrato contrato = new Contrato();
            int tipo = 10;

            // Arrange
            bool expected = true;

            // Act
            bool actual;
            if (contrato.ReadAllByTipoEvento(tipo).Count > 0)
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

        [TestMethod()]
        public void ReadAllByTipoEventoTest_NotFound()
        {
            Contrato contrato = new Contrato();
            int tipo = 30;

            // Arrange
            bool expected = false;

            // Act
            bool actual;
            if (contrato.ReadAllByTipoEvento(tipo).Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void ReadAllByModalidadTest_Found()
        {
            Contrato contrato = new Contrato();
            string modalidad = "CB001";

            // Arrange
            bool expected = true;

            // Act
            bool actual;
            if (contrato.ReadAllByModalidad(modalidad).Count > 0)
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

        [TestMethod()]
        public void ReadAllByModalidadTest_NotFound()
        {
            Contrato contrato = new Contrato();
            string modalidad = "CB003";

            // Arrange
            bool expected = false;

            // Act
            bool actual;
            if (contrato.ReadAllByModalidad(modalidad).Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = true;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}