using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionSGI.Login.Propiedades
{
    /// <summary>
    /// Elementos Web del Modulo de Login.
    /// </summary>
    public class ElementosWebLogin
    {
        public ElementosWebLogin()
        {
            PageFactory.InitElements(PropiedadColeccionDriver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUsuario { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogin")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[3]/button")]
        public IWebElement btnAceptar { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='wrapper']/header/nav/div/ul/li/a/span")]
        public IWebElement btnCerrar { get; set; }

        [FindsBy(How = How.LinkText, Using = "Cerrar Sesión")]
        public IWebElement btnCerrarSesion { get; set; }
    }
}







