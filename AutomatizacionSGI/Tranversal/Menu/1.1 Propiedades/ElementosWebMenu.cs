using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomatizacionSGI.Tranversal.Menu.Propiedades
{
    /// <summary>
    /// Elementos Web del Menu.
    /// </summary>
    public class ElementosWebMenu
    {
        public ElementosWebMenu()
        {
            PageFactory.InitElements(PropiedadColeccionDriver.driver, this);
        }
        
        [FindsBy(How = How.LinkText, Using = "Proyectos")]
        public IWebElement MenuProyectos { get; set; }

        [FindsBy(How = How.LinkText, Using = "Tareas")]
        public IWebElement SubMenuProyectosTareas { get; set; }

        [FindsBy(How = How.LinkText, Using = "Bitácora Timeline")]
        public IWebElement SubMenuProyectosBitacora { get; set; }

        [FindsBy(How = How.LinkText, Using = "Hitos")]
        public IWebElement SubMenuProyectosHitos { get; set; }

        [FindsBy(How = How.LinkText, Using = "Administración")]
        public IWebElement MenuAdmimistracion { get; set; }
    }
}
