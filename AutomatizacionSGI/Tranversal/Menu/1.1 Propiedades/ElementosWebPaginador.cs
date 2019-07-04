using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace AutomatizacionSGI.Tranversal.Menu.Propiedades
{
    /// <summary>
    /// Elementos Web del Menu.
    /// </summary>
    public class ElementosWebPaginador
    {
        public ElementosWebPaginador()
        {
            PageFactory.InitElements(PropiedadColeccionDriver.driver, this);
        }
        
        [FindsBy(How = How.LinkText, Using = "Anterior")]
        public IWebElement BotonAnterior { get; set; }

        [FindsBy(How = How.LinkText, Using = "Siguiente")]
        public IWebElement BotonSiguiente { get; set; }

        [FindsBy(How = How.ClassName, Using = "paginate_button")]
        public IList<IWebElement> Paginador { get; set; }
    }
}
