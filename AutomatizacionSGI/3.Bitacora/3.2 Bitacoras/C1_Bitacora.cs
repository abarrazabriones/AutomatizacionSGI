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
    class C1_Bitacora
    {
        
        [TestCaseSource("SourceTestCaseData")]
        public void CA1_InsertarRegistro(IList<ParametroPrueba> parametroPrueba)
        {
            string cliente  = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Cliente")).Valor;
            string proyecto = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Proyecto")).Valor;
            string titulo   = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Titulo")).Valor;
            string detalle  = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Detalle")).Valor;
            string tags     = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Tags")).Valor;
            string imagen   = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Imagen")).Valor;

            try
            {
                #region "VALIDACION INICIAR LOGIN"

                Utilitarios.ValidacionIniciarPrueba();

                #endregion

                #region "EJECIÓN DE LA PRUEBA

                ElementosWebMenu elementosMenu = new ElementosWebMenu();

                elementosMenu.MenuProyectos.Click();

                System.Threading.Thread.Sleep(1500);

                elementosMenu.SubMenuProyectosBitacora.Click();

                System.Threading.Thread.Sleep(1500);

                ElementosWebBitacoras elementosBitacora = new ElementosWebBitacoras();

                new SelectElement(elementosBitacora.ddlCliente).SelectByText(cliente);
                System.Threading.Thread.Sleep(800);
                new SelectElement(elementosBitacora.ddlProyecto).SelectByText(proyecto);

                System.Threading.Thread.Sleep(1000);

                elementosBitacora.btnNuevaBitacora.Click();

                System.Threading.Thread.Sleep(1000);

                elementosBitacora.txtTitulo.SendKeys(titulo);

                elementosBitacora.txtDetalle.SendKeys(detalle);

                elementosBitacora.txtTags.SendKeys(tags);
                
                elementosBitacora.fileBitacora.SendKeys(imagen);

                System.Threading.Thread.Sleep(1000);

                elementosBitacora.btnGuardar.Click();

                System.Threading.Thread.Sleep(1000);

                //Despliego la grilla.

                new SelectElement(elementosBitacora.ddlCliente).SelectByText(cliente);
                System.Threading.Thread.Sleep(800);
                new SelectElement(elementosBitacora.ddlProyecto).SelectByText(proyecto);

                System.Threading.Thread.Sleep(800);

                string[] columnasAFiltrar = new string[] { "Titulo", "Detalle" };

                Dictionary<string, string> filtros = new Dictionary<string, string>();
                filtros.Add("Titulo", titulo);
                filtros.Add("Detalle", detalle);
                filtros.Add("Tags", tags);

                Utilitarios.ValidarExistenciaGrilla("tableBitacora", columnasAFiltrar, filtros);

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

        public void CA1_InsertarRegistro_bkp()
        {
            Dictionary<string, string> diccionario = Utilitarios.ObtenerParametrosPorExcel("Bitacora", "CA1_InsertarRegistro");

            string cliente = diccionario.Where(x => x.Key.Equals("Cliente")).FirstOrDefault().Value;
            string proyecto = diccionario.Where(x => x.Key.Equals("Proyecto")).FirstOrDefault().Value;
            string titulo = diccionario.Where(x => x.Key.Equals("Titulo")).FirstOrDefault().Value;
            string detalle = diccionario.Where(x => x.Key.Equals("Detalle")).FirstOrDefault().Value;
            string tags = diccionario.Where(x => x.Key.Equals("Tags")).FirstOrDefault().Value;
            string imagen = diccionario.Where(x => x.Key.Equals("Imagen")).FirstOrDefault().Value;


            try
            {
                #region "VALIDACION INICIAR LOGIN"

                Utilitarios.ValidacionIniciarPrueba();

                #endregion

                #region "EJECIÓN DE LA PRUEBA

                ElementosWebMenu elementosMenu = new ElementosWebMenu();

                elementosMenu.MenuProyectos.Click();

                System.Threading.Thread.Sleep(1500);

                elementosMenu.SubMenuProyectosBitacora.Click();

                System.Threading.Thread.Sleep(1500);

                ElementosWebBitacoras elementosBitacora = new ElementosWebBitacoras();

                elementosBitacora.ddlCliente.SendKeys(cliente);

                elementosBitacora.ddlProyecto.SendKeys(proyecto);

                System.Threading.Thread.Sleep(1000);

                elementosBitacora.btnNuevaBitacora.Click();

                System.Threading.Thread.Sleep(1000);

                string valorAConcatenar = DateTime.Now.ToString("hhmmss");

                elementosBitacora.txtTitulo.SendKeys(titulo);

                elementosBitacora.txtDetalle.SendKeys(detalle);

                elementosBitacora.txtTags.SendKeys(tags);

                //Activar para IE, verificar para Firefox;
                //elementosBitacora.fileBitacora.Click();

                elementosBitacora.fileBitacora.SendKeys("C:\\Users\\Nicolas\\Desktop\\avatar01.png");

                System.Threading.Thread.Sleep(1000);

                elementosBitacora.btnGuardar.Click();

                System.Threading.Thread.Sleep(1000);

                //Despliego la grilla

                elementosBitacora.ddlCliente.SendKeys(cliente);

                elementosBitacora.ddlProyecto.SendKeys(proyecto);

                System.Threading.Thread.Sleep(1000);

                string[] columnasAFiltrar = new string[] { "Titulo", "Detalle" };

                Dictionary<string, string> filtros = new Dictionary<string, string>();
                filtros.Add("Titulo", titulo);
                filtros.Add("Detalle", detalle);
                filtros.Add("Tags", tags);

                Utilitarios.ValidarExistenciaGrilla("tableBitacora", columnasAFiltrar, filtros);

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
                                                    .AgregarHoja("Bitacora")
                                                    .AgregarNombrePrueba("CA1_InsertarRegistro")
                                                    .ObtenerCasosDePrueba();

                foreach (TestCaseData testCaseData in testcases)
                {
                    yield return testCaseData;
                }
            }
        }
    }
}
