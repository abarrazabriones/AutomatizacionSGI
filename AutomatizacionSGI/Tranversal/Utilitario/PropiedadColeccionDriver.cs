using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomatizacionSGI
{
    public class PropiedadColeccionDriver
    {
        internal static IWebDriver driver;

        public enum PropertyType
        {
            Id,
            Name,
            LinkText,
            CssName,
            ClassName
        }

        public class PropiedadColeccionDrivers
        {
            public static IWebDriver driver { get; set; }
        }
    }
}
