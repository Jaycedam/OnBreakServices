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
        public void ReadTest_NumberFound_ReturnsNotNull()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string numContrato = "202005080508";
            // Act
            Contrato actual = contrato.Read(numContrato);

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void ReadTest_NumberNotFound_ReturnsNull()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string numContrato = "2020050855";

            // Act
            Contrato actual = contrato.Read(numContrato);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod()]
        public void CreateTest_MissingValues_ReturnsFalse()
        {
            // Arrange
            Contrato contrato = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                Creacion = DateTime.Now,
                Cliente = new Cliente()
                {
                    RutCliente = "190040399"
                }
            };
            // Act
            bool actual = contrato.Create(contrato);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void CreateTest_Correct_ReturnsTrue()
        {
            // Arrange
            Contrato contrato = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                Creacion = DateTime.Now,
                Termino = DateTime.Now,
                Asistentes = 10,
                PersonalAdicional = 5,
                Realizado = false,
                FechaHoraInicio = DateTime.Now,
                FechaHoraTermino = DateTime.Now,
                Observaciones = "-",
                ValorTotalContrato = 8,
                Cliente = new Cliente()
                {
                    RutCliente = "190040399"
                },
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CB001",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                },
            };
            // Act
            bool actual = contrato.Create(contrato);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void CreateTest_ClienteNotFound_ReturnsFalse()
        {
            // Arrange
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

            // Act
            bool actual = contrato.Create(contrato);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void UpdateTest_Correct_ReturnsTrue()
        {
            // Arrange
            Contrato contrato = new Contrato()
            {
                Numero = "202005080508",
                Observaciones = "",
                FechaHoraInicio = DateTime.Now,
                FechaHoraTermino = DateTime.Now,
                Asistentes = 10,
                PersonalAdicional = 5,
                Realizado = false,
                ValorTotalContrato = 10,
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CB001",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                }

            };

            // Act
            bool actual = contrato.Update(contrato);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void UpdateTest_MissingValues_ReturnsFalse()
        {
            // Arrange
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

            // Act
            bool actual = contrato.Update(contrato);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void UpdateTest_NumberNotFound_ReturnsFalse()
        {
            // Arrange
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

            // Act
            bool actual = contrato.Update(contrato);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void DeleteTest_Correct_ReturnsTrue()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string num = "202005080604";
            // Act
            bool actual = contrato.Delete(num);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void DeleteTest_NumberNotFound_ReturnsFalse()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string num = "2020050855";
            // Act
            bool actual = contrato.Delete(num);

            // Assert
            Assert.IsFalse(actual);
        }


        [TestMethod()]
        public void ReadAllByNumeroContratoTest_Found_ReturnsTrue()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string num = "2020050805";

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
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ReadAllByNumeroContratoTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string num = "2020055805";

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
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ReadAllByRutTest_Found_ReturnsTrue()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string rut = "190040399";

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
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ReadAllByRutTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string rut = "190048899";

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
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ReadAllByTipoEventoTest_Found_ReturnsTrue()
        {
            // Arrange
            Contrato contrato = new Contrato();
            int tipo = 10;

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
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ReadAllByTipoEventoTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Contrato contrato = new Contrato();
            int tipo = 30;

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
            Assert.IsFalse(actual);
        }


        [TestMethod()]
        public void ReadAllByModalidadTest_Found_ReturnsTrue()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string modalidad = "CB001";

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
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ReadAllByModalidadTest_NotFound_ReturnsFalse()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string modalidad = "CB003";

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
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ContratosVigentesTest_Yes_ReturnsTrue()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string rut = "190040399";

            // Act
            bool actual = contrato.ContratosAsociados(rut);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ContratosVigentesTest_No_ReturnsFalse()
        {
            // Arrange
            Contrato contrato = new Contrato();
            string rut = "145324262";

            // Act
            bool actual = contrato.ContratosAsociados(rut);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}