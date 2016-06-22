using OpenQA.Selenium;
using ProyectoDeTest_ConPatron.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDeTest_ConPatron.Paginas
{
    class RegistroPage : MasterPage
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
            titulo = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/form/h2");
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

            IWebElement tbxEmail = BuscarControl(TiposDeBusqueda.Id, "/html/body/div[2]/form/div[2]/div/input");
            if (tbxEmail != null)
                cuerpo.Add(tbxEmail);

            IWebElement tbxPassword = BuscarControl(TiposDeBusqueda.Id, "/html/body/div[2]/form/div[3]/div/input");
            if (tbxPassword != null)
                cuerpo.Add(tbxPassword);

            IWebElement tbxConfirmar = BuscarControl(TiposDeBusqueda.Id, "/html/body/div[2]/form/div[4]/div/input");
            if (tbxConfirmar != null)
                cuerpo.Add(tbxConfirmar);

            IWebElement btnRegistrar = BuscarControl(TiposDeBusqueda.XPath, "/html/body/div[2]/form/div[5]/div/input");
            if (btnRegistrar != null)
                cuerpo.Add(btnRegistrar);

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
        public void RealizarClickSobreBotonRegistrar()
        {
            RealizarClick(Cuerpo.ElementAt(3));
        }
    }
}
