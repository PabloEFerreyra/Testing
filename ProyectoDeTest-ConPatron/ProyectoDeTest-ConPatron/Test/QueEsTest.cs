using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ProyectoDeTest_ConPatron.Paginas;
using ProyectoDeTest_ConPatron.Enumerados;

namespace ProyectoDeTest_ConPatron.Test
{
    /// <summary>
    /// Summary description for HomeTest
    /// </summary>
    [TestClass]
    public class QueEsTest
    {

        public QueEsTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private QueEsPage homePageTest;

        /// <summary>
        /// Objeto utilizado para acceder a las acciones sobre la pagina Home.
        /// </summary>
        private QueEsPage HomePageTest
        {
            get
            {
                if (homePageTest == null)
                    homePageTest = new QueEsPage();

                return homePageTest;
            }

            set { homePageTest = value; }
        }

        private void InicializarPagina() { }

        #region Additional test attributes
        ////
        //// You can use the following additional attributes as you write your tests:
        ////
        //// Use ClassInitialize to run code before running the first test in the class
        //// [ClassInitialize()]
        //// public static void MyClassInitialize(TestContext testContext) { }
        ////
        //// Use ClassCleanup to run code after all tests in a class have run
        //// [ClassCleanup()]
        //// public static void MyClassCleanup() { }
        ////

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            HomePageTest.NavegarAUrl(HomePageTest.UrlPage);
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            HomePageTest.CerrarBrowser();
        }

        #endregion

        [TestMethod]
        public void IngresarAPaginaQueEs()
        {
            //Inicializa el menu donde se encuentra la opcion Que Es.
            HomePageTest.InstanciarMenu();

            //Verifica que exista el menu y el boton Que Es...
            Assert.IsTrue(HomePageTest.ExisteMenu(), "No se encontro el Control Menu, buscado por XPath.");
            Assert.IsTrue(HomePageTest.RetornarTextoItemMenu((int)OpcionesMenuPrincipal.QueEs).Equals("Que es..."), "No coincide el texto del menu con el texto de comparacion.");

            //Presiona el boton Que Es... del menu.
            HomePageTest.RealizarClickSobreBotonQueEs();
                        
            //Inicializa nuevamente el menu, luego de ingresar a la pagina.
            HomePageTest.InstanciarMenu();

            //Inicializa nuevamente el menu, luego de ingresar a la pagina.
            HomePageTest.InstanciarTitulo();

            //Inicializa el logo, luego de ingresar a la pagina.
            HomePageTest.InstanciarLogo();

            //Inicializa el menu login, luego de ingresar a la pagina.
            HomePageTest.InstanciarMenuLogin();

            //Verifica que el tab del browser contenca el nombre correcto.
            Assert.IsTrue(HomePageTest.NombreTab.Contains("Que es... - Hexacta Labs"), "El título de la página NO ES CORRECTO.");

            //Verifica la existencia del logo.
            Assert.IsTrue(HomePageTest.ExisteLogo(), "No se encontro el Control Logo, buscado por Css.");

            //Verifica la existencia del menu y chequea la existencia de todas las opciones del mismo.
            Assert.IsTrue(HomePageTest.ExisteMenu(), "No se encontro el Control Menu, buscado por XPath.");
            Assert.IsTrue(HomePageTest.RetornarTextoItemMenu((int)OpcionesMenuPrincipal.Home).Equals("Home"), "No coincide el texto del menu con el texto de comparacion.");
            Assert.IsTrue(HomePageTest.RetornarTextoItemMenu((int)OpcionesMenuPrincipal.QueEs).Equals("Que es..."), "No coincide el texto del menu con el texto de comparacion.");
            Assert.IsTrue(HomePageTest.RetornarTextoItemMenu((int)OpcionesMenuPrincipal.Contacto).Equals("Contacto"), "No coincide el texto del menu con el texto de comparacion.");

            //Verifica la existencia del menu login y chequea la existencia de todas las opciones del mismo.
            Assert.IsTrue(HomePageTest.ExisteMenuLogin(), "No se encontro el Control Menu Login, buscado por XPath.");
            Assert.IsTrue(HomePageTest.RetornarTextoItemMenuLogin((int)OpcionesMenuLogin.Registro).Equals("Registro"), "No coincide el texto del menu con el texto de comparacion.");
            Assert.IsTrue(HomePageTest.RetornarTextoItemMenuLogin((int)OpcionesMenuLogin.LogIn).Equals("Log in"), "No coincide el texto del menu con el texto de comparacion.");

            //Verifica que se presente el titulo de la pagina.
            Assert.IsTrue(HomePageTest.ExisteTitulo(), "No se encontro el Control Titulo, buscado por Css.");
            Assert.IsTrue(HomePageTest.TextoTitulo.Equals("... Hexacta Labs?"), "No coincide el texto del titulo con el texto de comparacion.");
        }        
    }
}
