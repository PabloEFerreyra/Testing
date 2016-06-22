using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ProyectoDeTest_ConPatron.Enumerados;
using System;

namespace ProyectoDeTest_ConPatron.Paginas
{
    public abstract class BasePage
    {
        /// <summary>
        /// Url de la pagina a ingresar.
        /// </summary>
        public virtual string UrlPage { get { return ""; } }

        /// <summary>
        /// Determina si existe el titulo de la pagina ingresada.
        /// </summary>
        public virtual bool ExisteTitulo() { return (Titulo != null); }

        internal IWebElement titulo = null;

        /// <summary>
        /// Titulo de la pagina ingresada.
        /// </summary>
        public virtual IWebElement Titulo { get { return titulo; } }

        /// <summary>
        /// Retorna el texto contenido en el control Titulo.
        /// </summary>
        public virtual string TextoTitulo { get { return Titulo.Text; } }

        private IWebDriver webDriver;

        /// <summary>
        /// Driver que maneja las peticiones de operaciones sobre el navegador.
        /// </summary>    
        internal IWebDriver WebDriver
        {
            get
            {
                if (webDriver == null)
                    webDriver = new FirefoxDriver();

                return webDriver;
            }

            set { webDriver = value; }
        }

        /// <summary>
        /// Retorna el nombre del Tab que tiene foco.
        /// </summary>
        public string NombreTab { get { return WebDriver.Title; } }

        /// <summary>
        /// Permite navegar hacia una determinada url.
        /// </summary>
        public void NavegarAUrl(string urlANavegar)
        {
            WebDriver.Navigate().GoToUrl(urlANavegar);
        }

        /// <summary>
        /// Envia texto, al control indicado.
        /// </summary>
        public void IngresarTexto(string nombreControl, string xPathControl, string texto)
        {
            IWebElement control = null;

            if (!string.IsNullOrEmpty(nombreControl) && !string.IsNullOrWhiteSpace(nombreControl))
                control = BuscarControlPorNombre(nombreControl);

            if (!string.IsNullOrEmpty(xPathControl) && !string.IsNullOrWhiteSpace(xPathControl))
                control = BuscarControlPorXPath(xPathControl);

            if (control != null)
                control.SendKeys(texto);
        }
        
        /// <summary>
        /// Cierra el browser y todas las instancias relacionadas a el.
        /// </summary>
        public void CerrarBrowser() { WebDriver.Quit(); }

        /// <summary>
        /// Busca el control, segun el tipo de busqueda y valor a buscar definido. Si no consigue valores, se retorna valor null.
        /// </summary>
        public IWebElement BuscarControl(TiposDeBusqueda tipoBusqueda, string valorABuscar)
        {
            IWebElement control = null;

            switch (tipoBusqueda)
            {
                case TiposDeBusqueda.Nombre:
                    control = BuscarControlPorNombre(valorABuscar);
                    break;
                case TiposDeBusqueda.Css:
                    control = BuscarControlPorClass(valorABuscar);
                    break;
                case TiposDeBusqueda.Id:
                    control = BuscarControlPorID(valorABuscar);
                    break;
                case TiposDeBusqueda.XPath:
                    control = BuscarControlPorXPath(valorABuscar);
                    break;
                default:
                    break;
            }

            return control;
        }

        /// <summary>
        /// Retorna un control de la pagina, a partir de su nombre.
        /// </summary>
        private IWebElement BuscarControlPorNombre(string nombreControl)
        {
            //Defino el tiempo maximo a esperar.
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //Recupero el control, cuyo nombre fue pasado por parametro.
            return wait.Until<IWebElement>(d => d.FindElement(By.Name(nombreControl)));
        }

        /// <summary>
        /// Retorna un control de la pagina, a partir de su nombre de clase css.
        /// </summary>
        private IWebElement BuscarControlPorClass(string nombreClass)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //Recupero el control, cuyo nombre de clase, fue pasado por parametro.
            return wait.Until<IWebElement>(d => d.FindElement(By.ClassName(nombreClass)));
        }

        /// <summary>
        /// Retorna un control de la pagina, a partir de su ID.
        /// </summary>
        private IWebElement BuscarControlPorID(string id)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //Recupero el control cuyo ID, fue pasado por parametro.
            return wait.Until<IWebElement>(d => d.FindElement(By.Id(id)));
        }

        /// <summary>
        /// Retorna un control de la pagina, a partir de su ID.
        /// </summary>
        private IWebElement BuscarControlPorXPath(string xPath)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //Recupero el control cuyo XPath, fue pasado por parametro.
            return wait.Until<IWebElement>(d => d.FindElement(By.XPath(xPath)));
        }

        /// <summary>
        /// Realiza un click sobre el control indicado.
        /// </summary>
        public virtual void RealizarClick(IWebElement botonAClickear)
        {
            botonAClickear.Click();
        }
    }
}
