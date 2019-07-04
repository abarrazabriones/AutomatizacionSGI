using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionSGI.Tareas.Propiedades
{
    /// <summary>
    /// Elementos Web del Modulo de Tareas
    /// </summary>
    public class ElementosWebHitos
    {
        public ElementosWebHitos()
        {
            PageFactory.InitElements(PropiedadColeccionDriver.driver, this);
        }

        #region "Formulario Inicial Hitos"
        
        [FindsBy(How = How.Id, Using = "ProyectoId")]
        public IWebElement ddlProyectoInicio { get; set; }

        [FindsBy(How = How.Id, Using = "btnNuevoHito")]
        public IWebElement btnNuevoHito { get; set; }

        #endregion

        #region "Formulario Ingeso Hitos"

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDescripcion { get; set; }

        [FindsBy(How = How.Id, Using = "MontoUF")]
        public IWebElement txtMontoUF { get; set; }

        [FindsBy(How = How.Id, Using = "ProyectoId")]
        public IWebElement ddlProyecto { get; set; }

        [FindsBy(How = How.Id, Using = "inputdteFechaPlanificada")]
        public IWebElement dtFechaPlanificada { get; set; }

        [FindsBy(How = How.Id, Using = "inputdteFechaCumplimiento")]
        public IWebElement dtFechaCumplimiento { get; set; }
        
        [FindsBy(How = How.Id, Using = "RutaSVN")]
        public IWebElement txtRutaSVN { get; set; }

        [FindsBy(How = How.Id, Using = "Estado")]
        public IWebElement ddlEstado { get; set; }
        
        [FindsBy(How = How.Id, Using = "checkFacturado")]
        public IWebElement chkFacturado { get; set; }

        [FindsBy(How = How.Id, Using = "ServiceLevelAgreementId")]
        public IWebElement ddlSLA { get; set; }

        [FindsBy(How = How.Id, Using = "btnGuardarHito")]
        public IWebElement btnGuardarHito { get; set; }
        
        #endregion

    }
}
