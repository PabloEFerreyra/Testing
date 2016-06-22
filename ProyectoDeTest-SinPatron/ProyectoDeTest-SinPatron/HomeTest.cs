using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace ProyectoDeTest_SinPatron
{
    [TestClass]
    public class HomeTest
    {
        [TestMethod]
        public void IngresarAPaginaQueEs()
        {
            //Abre ventana del browser Firefox.
            IWebDriver webDriver = new FirefoxDriver();

            //Utiliza el browser abierto y navega a la url indicada.
            webDriver.Navigate().GoToUrl("http://localhost:55161/");

            //Defino el tiempo maximo a esperar.
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            // Busco el link login
            IWebElement queEsLink = wait.Until<IWebElement>(d => d.FindElement(By.LinkText("Que es...")));

            //Selecciona la opcion de menu "Que es..."
            if (queEsLink != null)
            {
                queEsLink.Click();

                //Recupero el titulo de la pagina.
                IWebElement tituloPagina = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[2]/h2")));

                //Realizo la verificacion sobre el titulo.
                Assert.AreEqual(tituloPagina.Text, "... Hexacta Labs?");

                //Cierra el browser abierto.
                webDriver.Quit();
            }
            else
                Assert.Fail("No se encontro el menu principal.");
        }

        [TestMethod]
        public void RealizarLogin()
        {
            //Abre ventana del browser Firefox.
            IWebDriver webDriver = new FirefoxDriver();

            //Utiliza el browser abierto y navega a la url indicada.
            webDriver.Navigate().GoToUrl("http://localhost:55161/");

            //Defino el tiempo maximo a esperar.
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            // Busco el link login
            IWebElement loginLink = wait.Until<IWebElement>(d => d.FindElement(By.LinkText("Log in")));

            //Selecciona la opcion de menu "Log In"
            if (loginLink != null)
            {

                loginLink.Click();

                //Intento recuperar el control Email.
                IWebElement textboxEmail = wait.Until<IWebElement>(d => d.FindElement(By.Name("Email")));
                //Completa campo Email.
                textboxEmail.SendKeys("dnagali@hexacta.com");
                //Assert.AreEqual(textboxEmail.GetAttribute("value"),"");

                //Intento recuperar el control Password.
                IWebElement textboxPassword = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/section/form/div[2]/div/input")));
                //Completa campo Password.
                textboxPassword.SendKeys("Damian1'");

                //Intento recuperar el boton Login.
                IWebElement botonLogIn = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/section/form/div[4]/div/input")));

                //Ejecuto el login.
                botonLogIn.Click();

                //Intento recuperar el boton Login.
                IWebElement usuarioLogueado = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[1]/div/div[2]/form/ul/li[1]/a")));

                //Realizo la verificacion para chequear el usuario logueado.
                Assert.AreEqual(usuarioLogueado.Text, "Hello dnagali@hexacta.com!");

                //Cierra el browser abierto.
                webDriver.Quit();
            }
            else
                Assert.Fail("No se encontro el link login.");
        }
        
        [TestMethod]
        public void RealizarRegistro()
        {
            IWebDriver firefox = new FirefoxDriver();

            firefox.Navigate().GoToUrl("http://localhost:55161");

            WebDriverWait wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(10));

            firefox.Navigate().GoToUrl("http://localhost:55161/Account/Register");

            IWebElement usuario = wait.Until<IWebElement>(d => d.FindElement(By.Id("Email")));

            IWebElement contrasenia = wait.Until<IWebElement>(d => d.FindElement(By.Id("Password")));

            IWebElement confirmacion = wait.Until<IWebElement>(d => d.FindElement(By.Id("ConfirmPassword")));

            IWebElement botonRegistrar = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[2]/form/div[5]/div/input")));

            usuario.SendKeys("usuario@usuario.com");
            contrasenia.SendKeys("ABCd123.");
            confirmacion.SendKeys("ABCd123.");
            botonRegistrar.Click();
        }
    }
}
