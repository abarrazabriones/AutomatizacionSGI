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
    public class ElementosWebBitacoras
    {
        public ElementosWebBitacoras()
        {
            PageFactory.InitElements(PropiedadColeccionDriver.driver, this);
        }

        #region "Formulario Inicial Bitacora"

        [FindsBy(How = How.Id, Using = "ClienteId")]
        public IWebElement ddlCliente { get; set; }

        [FindsBy(How = How.Id, Using = "ProyectoId")]
        public IWebElement ddlProyecto { get; set; }

        [FindsBy(How = How.Id, Using = "lnkCrear")]
        public IWebElement btnNuevaBitacora { get; set; }

        #endregion

        #region "Formulario Ingeso Bitacora"

        [FindsBy(How = How.Id, Using = "Titulo")]
        public IWebElement txtTitulo { get; set; }

        [FindsBy(How = How.Id, Using = "Detalle")]
        public IWebElement txtDetalle { get; set; }

        [FindsBy(How = How.Id, Using = "Tags")]
        public IWebElement txtTags { get; set; }

        [FindsBy(How = How.Id, Using = "inputdteFechaCreacion")]
        public IWebElement dtFechaCreacion { get; set; }

        [FindsBy(How = How.Id, Using = "flBitacora")]
        public IWebElement fileBitacora { get; set; }

        [FindsBy(How = How.Id, Using = "btnGuardarBitacoraTimeline")]
        public IWebElement btnGuardar { get; set; }

        #endregion

    }
}
