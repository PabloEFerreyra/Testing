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
    public class LogInTest
    {

        public LogInTest()
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

        private QueEsPage homePage;

        /// <summary>
        /// Objeto utilizado para acceder a las acciones sobre la pagina Home.
        /// </summary>
        private QueEsPage HomePage
        {
            get
            {
                if (homePage == null)
                    homePage = new QueEsPage();

                return homePage;
            }

            set { homePage = value; }
        }

        private LogInPage logInPage;

        /// <summary>
        /// Objeto utilizado para acceder a las acciones sobre la pagina LogIn.
        /// </summary>
        private LogInPage LogInPage
        {
            get
            {
                if (logInPage == null)
                    logInPage = new LogInPage();

                return logInPage;
            }

            set { logInPage = value; }
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
            HomePage.NavegarAUrl(HomePage.UrlPage);
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            HomePage.CerrarBrowser();
        }

        #endregion

        [TestMethod]
        public void RealizarLogin()
        {
            //Inicializa el menu donde se encuentra las opciones de login.
            HomePage.InstanciarMenuLogin();
            
            //Realiza click sobre el boton Log In.
            HomePage.RealizarClickSobreBotonLogIn();

            //Inicializa el menu donde se encuentra las opciones de login, tras la entrada a la pantalla de log in.
            LogInPage.InstanciarMenuLogin(HomePage.WebDriver);
            
            //Inicializa el control contenedor del titulo.
            LogInPage.InstanciarTitulo();
            
            //Inicializa el control contenedor de los controles del cuerpo
            LogInPage.InstanciarCuerpo();

            //verifica la existencia del menu.
            Assert.IsTrue(LogInPage.ExisteMenuLogin(), "No se encontro el Control Menu Login, buscado por XPath.");
            
            //Verifica la existencia del boton Registro.
            Assert.IsTrue(LogInPage.RetornarTextoItemMenuLogin((int)OpcionesMenuLogin.Registro).Equals("Registro"), "No coincide el texto del menu con el texto de comparacion.");
            
            //Verifica la existencia del boton Log in.
            Assert.IsTrue(LogInPage.RetornarTextoItemMenuLogin((int)OpcionesMenuLogin.LogIn).Equals("Log in"), "No coincide el texto del menu con el texto de comparacion.");

            //Verifica la existencia del titulo y su correcto texto.
            Assert.IsTrue(LogInPage.ExisteTitulo(), "Se encontro el Control Titulo, buscado por Css.");
            Assert.IsTrue(LogInPage.TextoTitulo == "Ingrese usuario.", "El titulo recuperado no coincide con el definido.");

            //Ingresa texto sobre el control Texbox de Username.
            LogInPage.IngresarTexto(null, "/html/body/div[2]/div/div/section/form/div[1]/div/input", "Dnagali@Hexacta.com");

            //Ingresa texto sobre el control Texbox de Password.
            LogInPage.IngresarTexto(null, "/html/body/div[2]/div/div/section/form/div[2]/div/input", "Damian1'");

            //Presiona el boton Log in.
            LogInPage.RealizarClickSobreBotonLogIn();

            //Instancia las nuevas opciones disponibles para el menu login.
            LogInPage.InstanciarMenuLoginConUsuarioLogueado();

            //Verifica la existencia del menu login.
            Assert.IsTrue(LogInPage.ExisteMenuLogin(), "No se encontro el Control Menu Login, buscado por XPath.");

            //Verifica que se presente correctamente el nombre del usuario logueado.
            Assert.IsTrue(LogInPage.RetornarTextoItemMenuLogin((int)OpcionesMenuLogin.Registro).Equals("Hello dnagali@hexacta.com!"), "No coincide el texto del menu con el texto de comparacion.");
        }
    }
}
