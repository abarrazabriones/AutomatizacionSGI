using AutomatizacionSGI.Tranversal.Utilitario;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AutomatizacionSGI
{
    /// <summary>
    /// Clase de inicializacion y finalizacion de las pruebas.
    /// </summary>
    public static class Prueba
    {
        #region Iniciadores de Pruebas

        /// <summary>
        /// Metodo utilizado para iniciar el navegador Chrome con la url del sitio.
        /// </summary>
        /// <param name="urlSitio">Url del Sitio a Probar</param>
        public static void IniciarEnChrome(string urlSitio)
        {
            PropiedadColeccionDriver.driver = new ChromeDriver();

            PropiedadColeccionDriver.driver.Manage().Window.Maximize();

            PropiedadColeccionDriver.driver.Navigate().GoToUrl(urlSitio);
        }

        /// <summary>
        /// Metodo utilizado para iniciar el navegador Firefox con la url del sitio.
        /// </summary>
        /// <param name="urlSitio">Url del Sitio a Probar</param>
        public static void IniciarEnFirefox(string urlSitio)
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.AcceptUntrustedCertificates = true;

            PropiedadColeccionDriver.driver = new FirefoxDriver( new FirefoxOptions { Profile = profile });

            PropiedadColeccionDriver.driver.Manage().Window.Maximize();

            PropiedadColeccionDriver.driver.Navigate().GoToUrl(urlSitio);
        }

        /// <summary>
        /// Metodo utilizado para iniciar el navegador Internet Explorer con la url del sitio.
        /// </summary>
        /// <param name="urlSitio">Url del Sitio a Probar</param>
        public static void IniciarEnInternetExplorer(string urlSitio)
        {
            PropiedadColeccionDriver.driver = new InternetExplorerDriver();

            PropiedadColeccionDriver.driver.Manage().Window.Maximize();
            
            PropiedadColeccionDriver.driver.Navigate().GoToUrl(urlSitio);
        }

        /// <summary>
        /// Metodo utilizado para iniciar las prubas en el navegador indicado, y con la url del sitio.
        /// </summary>
        /// <param name="navegador">nombre del navegador</param>
        /// <param name="urlSitio">url del sitio</param>
        public static void Iniciar(string navegador, string urlSitio)
        {
            if (navegador == "Chrome")
            {
                PropiedadColeccionDriver.driver = new ChromeDriver();

                PropiedadColeccionDriver.driver.Manage().Window.Maximize();

                PropiedadColeccionDriver.driver.Navigate().GoToUrl(urlSitio);
            }
            else if (navegador == "Firefox")
            {
                FirefoxProfile profile = new FirefoxProfile();
                profile.AcceptUntrustedCertificates = true;
                profile.SetPreference("dom.disable_beforeunload", true);
                profile.SetPreference("security.insecure_field_warning.contextual.enabled", false);

                PropiedadColeccionDriver.driver = new FirefoxDriver(new FirefoxOptions { Profile = profile });

                PropiedadColeccionDriver.driver.Manage().Window.Maximize();

                PropiedadColeccionDriver.driver.Navigate().GoToUrl(urlSitio);
            }
            else if (navegador == "IE")
            {
                PropiedadColeccionDriver.driver = new InternetExplorerDriver();

                PropiedadColeccionDriver.driver.Manage().Window.Maximize();

                PropiedadColeccionDriver.driver.Navigate().GoToUrl(urlSitio);
            }
        }

        #endregion

        #region Finalizadores de Pruebas

        /// <summary>
        /// Metodo utilizado para cerrar el navegador y finalizar la prueba.
        /// </summary>
        public static void Finalizar()
        {
            if (PropiedadColeccionDriver.driver != null)
            {
                PropiedadColeccionDriver.driver.Quit();
                PropiedadColeccionDriver.driver = null;
            }
        }

        #endregion
    }
}
