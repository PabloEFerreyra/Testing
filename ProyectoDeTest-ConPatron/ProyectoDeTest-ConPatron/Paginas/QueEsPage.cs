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
    class QueEsPage : MasterPage
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
            titulo = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/h2");
        }

        private IWebElement copete = null;

        /// <summary>
        /// Representa el elemento correspondiente al Copete de la home.
        /// </summary>
        public IWebElement Copete
        {
            get
            {
                return copete;
            }
        }

        /// <summary>
        /// Instancia el copete de la master.
        /// </summary>
        public void InstanciarCopete()
        {
            IWebElement sectionFeatured = BuscarControl(TiposDeBusqueda.Css, "featured");
            copete = sectionFeatured.FindElement(By.TagName("P"));
        }

        /// <summary>
        /// Permite determinar si el Copete existe o no.
        /// </summary>
        public bool ExisteCopete()
        {
            return ((Copete != null) && (Copete.Text.Length > 0));
        }

        /// <summary>
        /// Retorna el texto contenido en el control Copete.
        /// </summary>
        public virtual string TextoCopete { get { return Copete.Text; } }

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
            IWebElement listCuerpo = BuscarControl(TiposDeBusqueda.Css, "main-content");

            cuerpo = new List<IWebElement>();

            if (listCuerpo != null)
            {
                cuerpo.Add(listCuerpo.FindElement(By.TagName("h3")));

                foreach (var item in listCuerpo.FindElements(By.TagName("li")))
                {
                    cuerpo.Add(item);
                }
            }
        }

        /// <summary>
        /// Permite determinar si el Copete existe o no.
        /// </summary>
        public bool ExisteCuerpo()
        {
            return ((Cuerpo != null) && (Cuerpo.Count > 0));
        }

        /// <summary>
        /// Retorna el texto del item del Cuerpo, en la posicion indicada.
        /// </summary>
        public string RetornarTextoItemCuerpo(int posicionItem)
        {
            string itemARetornar = null;

            if (Cuerpo != null)
                itemARetornar = Cuerpo.ElementAtOrDefault(posicionItem).Text;

            return itemARetornar;
        }

    }
}
