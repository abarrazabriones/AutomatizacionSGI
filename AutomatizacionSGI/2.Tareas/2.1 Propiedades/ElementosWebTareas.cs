using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
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
    public class ElementosWebTareas
    {
        public ElementosWebTareas()
        {
            PageFactory.InitElements(PropiedadColeccionDriver.driver, this);
        }


        [FindsBy(How = How.Id, Using = "lnkCrear")]
        public IWebElement btnNuevaTarea { get; set; }

        [FindsBy(How = How.Id, Using = "Titulo")]
        public IWebElement txtTitulo { get; set; }

        [FindsBy(How = How.Id, Using = "Descripcion")]
        public IWebElement txtDecripcion { get; set; }

        [FindsBy(How = How.Id, Using = "IdProyecto")]
        public IWebElement ddlProyectos { get; set; }

        [FindsBy(How = How.Id, Using = "EstadoTareaId")]
        public IWebElement ddlEstado { get; set; }

        [FindsBy(How = How.Id, Using = "ServiceLevelAgreementId")]
        public IWebElement ddlServiceLevelAgreement { get; set; }

        [FindsBy(How = How.Id, Using = "btnGuardarTarea")]
        public IWebElement btnGuardarTarea { get; set; }

    }
}
