using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoDeTest_ConPatron.Enumerados;
using ProyectoDeTest_ConPatron.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDeTest_ConPatron.Test
{
    [TestClass]
    public class RegistroTest
    {

        public RegistroTest()
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
        private RegistroPage registroPage
        {
            get
            {
                if (registroPage == null)
                    registroPage = new RegistroPage();

                return registroPage;
            }

            set { registroPage = value; }
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
        public void RealizarRegistro()
        {
            //Inicializa el menu donde se encuentra las opciones de login.
            HomePage.InstanciarMenuLogin();

            //Realiza click sobre el boton Log In.
            HomePage.RealizarClickSobreBotonRegistro();

            //Inicializa el menu donde se encuentra las opciones de login, tras la entrada a la pantalla de log in.
            registroPage.InstanciarMenuLogin(HomePage.WebDriver);

            //Inicializa el control contenedor del titulo.
            registroPage.InstanciarTitulo();

            //Inicializa el control contenedor de los controles del cuerpo
            registroPage.InstanciarCuerpo();

            //verifica la existencia del menu.
            Assert.IsTrue(registroPage.ExisteMenuLogin(), "No se encontro el Control Menu Login, buscado por XPath.");

            //Verifica la existencia del boton Registro.
            Assert.IsTrue(registroPage.RetornarTextoItemMenuLogin((int)OpcionesMenuLogin.Registro).Equals("Registro"), "No coincide el texto del menu con el texto de comparacion.");

            //Verifica la existencia del boton Log in.
            Assert.IsTrue(registroPage.RetornarTextoItemMenuLogin((int)OpcionesMenuLogin.LogIn).Equals("Log in"), "No coincide el texto del menu con el texto de comparacion.");

            //Verifica la existencia del titulo y su correcto texto.
            Assert.IsTrue(registroPage.ExisteTitulo(), "Se encontro el Control Titulo, buscado por Css.");
            Assert.IsTrue(registroPage.TextoTitulo == "Ingrese usuario.", "El titulo recuperado no coincide con el definido.");

            //Ingresa texto sobre el control Texbox de Username.
            registroPage.IngresarTexto(null, "/html/body/div[2]/form/div[2]/div/input", "juan@hola.com");

            //Ingresa texto sobre el control Texbox de Password.
            registroPage.IngresarTexto(null, "/html/body/div[2]/form/div[3]/div/input", "Juan1'");
            
            //Ingresa texto sobre el control Texbox de ConfirmPassword.
            registroPage.IngresarTexto(null, "/html/body/div[2]/form/div[4]/div/input", "Juan1'");

            //Presiona el boton Registrar.
            registroPage.RealizarClickSobreBotonRegistrar();

            //Instancia las nuevas opciones disponibles para el menu login.
            registroPage.InstanciarMenuLoginConUsuarioLogueado();

            //Verifica la existencia del menu login.
            Assert.IsTrue(registroPage.ExisteMenuLogin(), "No se encontro el Control Menu Login, buscado por XPath.");

            //Verifica que se presente correctamente el nombre del usuario logueado.
            Assert.IsTrue(registroPage.RetornarTextoItemMenuLogin((int)OpcionesMenuLogin.Registro).Equals("Hello dnagali@hexacta.com!"), "No coincide el texto del menu con el texto de comparacion.");
        }
    }
}
