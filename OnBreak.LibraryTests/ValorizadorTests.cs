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
    public class ValorizadorTests
    {
        [TestMethod()]
        public void CalcularValorEventoTest_CB001_0A0P()
        {
            // Arrange
            Valorizador valorizador = new Valorizador();
            Contrato contrato = new Contrato()
            {
                Asistentes = 0,
                PersonalAdicional = 0,
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CB001",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                }
            };

            double expected = 3;
            // Act
            double actual = valorizador.CalcularValorEvento(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalcularValorEventoTest_CB001_5A2P()
        {
            // Arrange
            Valorizador valorizador = new Valorizador();
            Contrato contrato = new Contrato()
            {
                Asistentes = 5,
                PersonalAdicional = 2,
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CB001",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                }
            };

            double expected = 8;
            // Act
            double actual = valorizador.CalcularValorEvento(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalcularValorEventoTest_CB002_15A3P()
        {
            // Arrange
            Valorizador valorizador = new Valorizador();
            Contrato contrato = new Contrato()
            {
                Asistentes = 15,
                PersonalAdicional = 3,
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CB002",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                }
            };

            double expected = 14;
            // Act
            double actual = valorizador.CalcularValorEvento(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalcularValorEventoTest_CB003_25A4P()
        {
            // Arrange
            Valorizador valorizador = new Valorizador();
            Contrato contrato = new Contrato()
            {
                Asistentes = 25,
                PersonalAdicional = 4,
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CB003",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 10
                    }
                }
            };

            double expected = 20.5;
            // Act
            double actual = valorizador.CalcularValorEvento(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalcularValorEventoTest_CE002_55A10P()
        {
            // Arrange
            Valorizador valorizador = new Valorizador();
            Contrato contrato = new Contrato()
            {
                Asistentes = 55,
                PersonalAdicional = 10,
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = "CE002",
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = 30
                    }
                }
            };

            double expected = 46.5;
            // Act
            double actual = valorizador.CalcularValorEvento(contrato);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}