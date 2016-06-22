using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ProyectoDeTest_ConPatron.Enumerados;

namespace ProyectoDeTest_ConPatron.Paginas
{
    class MasterPage : BasePage
    {
        private IWebElement logo = null;

        /// <summary>
        /// Representa el elemento correspondiente al Logo de la home.
        /// </summary>
        public IWebElement Logo
        {
            get
            {
                return logo;
            }
        }

        /// <summary>
        /// Instancia el logo de la master.
        /// </summary>
        public void InstanciarLogo()
        {
            logo = BuscarControl(TiposDeBusqueda.Css, "navbar-brand");
        }

        /// <summary>
        /// Permite determinar si el Logo existe o no.
        /// </summary>
        public bool ExisteLogo()
        {
            return ((Logo != null) && (Logo.TagName == "a"));
        }

        /// <summary>
        /// Retorna el texto contenido en el control Logo.
        /// </summary>
        public virtual string TextoLogo { get { return Logo.Text; } }

        private IList<IWebElement> menu = null;

        /// <summary>
        /// Representa el elemento correspondiente al Menu de la home.
        /// </summary>
        public IList<IWebElement> Menu
        {
            get
            {
                return menu;
            }
        }

        /// <summary>
        /// Instancia la lista de los items del menu principal.
        /// </summary>
        public void InstanciarMenu(IWebDriver webDriver) 
        {
            this.WebDriver = webDriver;
            InstanciarMenu();
        }

        /// <summary>
        /// Instancia la lista de los items del menu principal.
        /// </summary>
        public void InstanciarMenu()
        {
            IWebElement listMenu = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[1]/div/div[2]/ul");

            if (listMenu != null)
            {
                menu = new List<IWebElement>();

                foreach (var item in listMenu.FindElements(By.TagName("a")))
                {
                    menu.Add(item);
                }
            }
        }

        /// <summary>
        /// Permite determinar si el Menu existe o no.
        /// </summary>
        public bool ExisteMenu()
        {
            return ((Menu != null) && (Menu.Count > 0));
        }

        /// <summary>
        /// Retorna el item del menu, en la posicion indicada.
        /// </summary>
        public IWebElement RetornarItemMenu(int posicionItem)
        {
            IWebElement itemARetornar = null;

            if (Menu != null)
                itemARetornar = Menu.ElementAtOrDefault(posicionItem);

            return itemARetornar;
        }

        /// <summary>
        /// Retorna el texto del item del menu, en la posicion indicada.
        /// </summary>
        public string RetornarTextoItemMenu(int posicionItem)
        {
            string itemARetornar = null;

            if (Menu != null)
                itemARetornar = Menu.ElementAtOrDefault(posicionItem).Text;

            return itemARetornar;
        }

        /// <summary>
        /// Retorna la cantidad de items del menu.
        /// </summary>
        public int RetornarCantidadItemsMenu()
        {
            int cantidadItems = 0;

            if (Menu != null)
                cantidadItems = Menu.Count;

            return cantidadItems - 1;
        }
        private IList<IWebElement> menuLogin = null;

        /// <summary>
        /// Representa el elemento correspondiente al menu login de la home.
        /// </summary>
        public IList<IWebElement> MenuLogin
        {
            get
            {
                return menuLogin;
            }
        }

        /// <summary>
        /// Instancia la lista de los items del menu login.
        /// </summary>
        public void InstanciarMenuLogin(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            InstanciarMenuLogin();
        }

        /// <summary>
        /// Instancia la lista de los items del menu login.
        /// </summary>
        public void InstanciarMenuLogin()
        {
            IWebElement listItemsLogin = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[1]/div/div[2]/ul[2]");
                                                                               
            menuLogin = new List<IWebElement>();

            if (listItemsLogin != null)
            {
                foreach (var item in listItemsLogin.FindElements(By.TagName("a")))
                {
                    menuLogin.Add(item);
                }
            }
        }

        
        
        /// <summary>
        /// Instancia la lista de los items del menu login, cuando el usuario esta logueado.
        /// </summary>
        public void InstanciarMenuLoginConUsuarioLogueado()
        {
            IWebElement listItemsLogin = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[1]/div/div[2]/form/ul");
                                                                               
            menuLogin = new List<IWebElement>();

            if (listItemsLogin != null)
            {
                foreach (var item in listItemsLogin.FindElements(By.TagName("a")))
                {
                    menuLogin.Add(item);
                }
            }
        }

        /// <summary>
        /// Permite determinar si el Menu login existe o no.
        /// </summary>
        public bool ExisteMenuLogin()
        {
            return ((MenuLogin != null) && (MenuLogin.Count > 0));
        }

        /// <summary>
        /// Retorna el item del menu login, en la posicion indicada.
        /// </summary>
        public IWebElement RetornarItemMenuLogin(int posicionItem)
        {
            IWebElement itemARetornar = null;

            if (MenuLogin != null)
                itemARetornar = MenuLogin.ElementAtOrDefault(posicionItem);

            return itemARetornar;
        }

        /// <summary>
        /// Retorna el texto del item del menu login, en la posicion indicada.
        /// </summary>
        public string RetornarTextoItemMenuLogin(int posicionItem)
        {
            string itemARetornar = null;

            if (MenuLogin != null)
                itemARetornar = MenuLogin.ElementAtOrDefault(posicionItem).Text;

            return itemARetornar;
        }

        /// <summary>
        /// Realiza un click sobre el control indicado.
        /// </summary>
        public void RealizarClickSobreBotonHome()
        {
            RealizarClick(RetornarItemMenu((int)OpcionesMenuPrincipal.Home));
        }

        /// <summary>
        /// Realiza un click sobre el control indicado.
        /// </summary>
        public void RealizarClickSobreBotonQueEs()
        {
            RealizarClick(RetornarItemMenu((int)OpcionesMenuPrincipal.QueEs));
        }

        /// <summary>
        /// Realiza un click sobre el control indicado.
        /// </summary>
        public void RealizarClickSobreBotonContacto()
        {
            RealizarClick(RetornarItemMenu((int)OpcionesMenuPrincipal.Contacto));
        }

        /// <summary>
        /// Realiza un click sobre el control indicado.
        /// </summary>
        public void RealizarClickSobreBotonRegistro()
        {
            RealizarClick(RetornarItemMenuLogin((int)OpcionesMenuLogin.Registro));
        }

        /// <summary>
        /// Realiza un click sobre el control indicado.
        /// </summary>
        public void RealizarClickSobreBotonLogIn()
        {
            RealizarClick(RetornarItemMenuLogin((int)OpcionesMenuLogin.LogIn));
        }
    }
}
