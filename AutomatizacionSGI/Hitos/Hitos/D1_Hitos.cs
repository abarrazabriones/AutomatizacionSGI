using AutomatizacionSGI.Tareas.Propiedades;
using AutomatizacionSGI.Tranversal;
using AutomatizacionSGI.Tranversal.Excepciones;
using AutomatizacionSGI.Tranversal.Menu.Propiedades;
using AutomatizacionSGI.Tranversal.Utilitario;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatizacionSGI
{
    class D1_Hitos
    {

        [TestCaseSource("SourceTestCaseData")]
        public void DA1_InsertarRegistro(IList<ParametroPrueba> parametroPrueba)
        {
            string descripcion       = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Descripcion")).Valor;
            string montoUF           = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("MontoUF")).Valor;
            string proyecto          = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Proyecto")).Valor;
            string fechaPlanificada  = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("FechaPlanificada")).Valor;
            string fechaCumplimiento = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("FechaCumplimiento")).Valor;
            string rutaSVN           = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("RutaSVN")).Valor;
            string estado            = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Estado")).Valor;
            string SLA               = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("SLA")).Valor;

            try
            {
                #region "VALIDACION INICIAR LOGIN"

                Utilitarios.ValidacionIniciarPrueba();

                #endregion

                #region "EJECIÓN DE LA PRUEBA

                ElementosWebMenu elementosMenu = new ElementosWebMenu();

                elementosMenu.MenuProyectos.Click();

                System.Threading.Thread.Sleep(1500);

                elementosMenu.SubMenuProyectosHitos.Click();

                System.Threading.Thread.Sleep(1500);

                ElementosWebHitos elementosWebHitos = new ElementosWebHitos();

                new SelectElement(elementosWebHitos.ddlProyectoInicio).SelectByText(proyecto);

                System.Threading.Thread.Sleep(1000);

                elementosWebHitos.btnNuevoHito.Click();

                System.Threading.Thread.Sleep(1000);

                elementosWebHitos.txtDescripcion.SendKeys(descripcion);

                elementosWebHitos.txtMontoUF.SendKeys(montoUF);

                new SelectElement(elementosWebHitos.ddlProyecto).SelectByText(proyecto);

                elementosWebHitos.dtFechaCumplimiento.SendKeys(fechaCumplimiento);

                elementosWebHitos.dtFechaCumplimiento.SendKeys(fechaPlanificada);

                elementosWebHitos.txtRutaSVN.SendKeys(rutaSVN);

                new SelectElement(elementosWebHitos.ddlEstado).SelectByText(estado);

                new SelectElement(elementosWebHitos.ddlSLA).SelectByText(SLA);

                System.Threading.Thread.Sleep(1000);

                elementosWebHitos.btnGuardarHito.Click();

                System.Threading.Thread.Sleep(1000);

                System.Threading.Thread.Sleep(800);

                if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio + "/Gestion/Hito")
                {
                    throw new ExcepcionSistema("Prueba Fallada.  Revise si completó todos los campos obligatorios");
                }

                string[] columnasAFiltrar = new string[] { "Proyecto", "Descripción", "Monto UF" };

                Dictionary<string, string> filtros = new Dictionary<string, string>();
                filtros.Add("Proyecto", proyecto);
                filtros.Add("Descripción", descripcion);
                filtros.Add("Monto UF", montoUF.Replace(',', '.'));

                Utilitarios.ValidarExistenciaGrilla("tableHito", columnasAFiltrar, filtros);

                #endregion
            }
            catch (ExcepcionSistema)
            {
                throw;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (ParametrosEjecucion.CerrarNavegadorPorPrueba)
                {
                    Prueba.Finalizar();
                }

                if (!ParametrosEjecucion.CerrarNavegadorPorPrueba && ParametrosEjecucion.CerrarNavegadorPorModulo)
                {
                    Prueba.Finalizar();
                }

                if (!ParametrosEjecucion.CerrarNavegadorPorPrueba && !ParametrosEjecucion.CerrarNavegadorPorModulo)
                {
                    Prueba.Finalizar();
                }
            }
        }
        
        public static IEnumerable<TestCaseData> SourceTestCaseData
        {
            get
            {
                IList<TestCaseData> testcases = ExcelTestCaseDataReader.Nuevo()
                                                    .AgregarUrlArchivo(ParametrosEjecucion.RutaCarpetaAutomatizacion + "/SGI.xlsx")
                                                    .AgregarHoja("Hitos")
                                                    .AgregarNombrePrueba("DA1_InsertarRegistro")
                                                    .ObtenerCasosDePrueba();

                foreach (TestCaseData testCaseData in testcases)
                {
                    yield return testCaseData;
                }
            }
        }
    }
}
