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
    class LogInPage : MasterPage
    {
        /// <summary>
        /// Url de la pagina Home.
        /// </summary>
        override public string UrlPage
        {
            get
            {
                return "http://localhost:55161/";
            }
        }

        /// <summary>
        /// Permite determinar si el titulo existe o no.
        /// </summary>
        override public bool ExisteTitulo()
        {
            return ((Titulo != null) && (Titulo.Text.Length > 0));
        }

        /// <summary>
        /// Representa el elemento correspondiente al Titulo de la home.
        /// </summary>
        override public IWebElement Titulo
        {
            get
            {
                return titulo;
            }
        }

        /// <summary>
        /// Instancia el titulo de la pagina.
        /// </summary>
        public void InstanciarTitulo()
        {
            titulo = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/div/div/section/form/h2");
        }

        private IList<IWebElement> cuerpo = null;

        /// <summary>
        /// Representa el elemento correspondiente al Copete de la home.
        /// </summary>
        public IList<IWebElement> Cuerpo
        {
            get
            {
                return cuerpo;
            }
        }

        /// <summary>
        /// Instancia la lista de los elementos del cuerpo.
        /// </summary>
        public void InstanciarCuerpo()
        {

            cuerpo = new List<IWebElement>();

            IWebElement tbxEmail = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/div/div/section/form/div[1]/div/input");
            if (tbxEmail != null)
                cuerpo.Add(tbxEmail);

            IWebElement tbxPassword = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/div/div/section/form/div[2]/div/input");
            if (tbxPassword != null)
                cuerpo.Add(tbxPassword);

            IWebElement cbxRecordarme = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/div/div/section/form/div[3]/div/div");
            if (cbxRecordarme != null)
                cuerpo.Add(cbxRecordarme);

            IWebElement btnLogIn = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/div/div/section/form/div[4]/div/input");
            if (btnLogIn != null)
                cuerpo.Add(btnLogIn);

            IWebElement linkRegistrarse = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/div/div/section/form/p/a");
            if (linkRegistrarse != null)
                cuerpo.Add(linkRegistrarse);
        }

        /// <summary>
        /// Permite determinar si el Copete existe o no.
        /// </summary>
        public bool ExisteCuerpo()
        {
            return ((Cuerpo != null) && (Cuerpo.Count > 0));
        }

        /// <summary>
        /// Realiza un click sobre el control indicado.
        /// </summary>
        public void RealizarClickSobreBotonLogIn()
        {
            RealizarClick(Cuerpo.ElementAt(3));
        }
    }
}
