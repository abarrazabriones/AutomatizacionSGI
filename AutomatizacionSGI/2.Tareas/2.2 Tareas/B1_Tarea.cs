using AutomatizacionSGI.Tareas.Propiedades;
using AutomatizacionSGI.Tranversal;
using AutomatizacionSGI.Tranversal.Excepciones;
using AutomatizacionSGI.Tranversal.Menu.Propiedades;
using AutomatizacionSGI.Tranversal.Utilitario;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AutomatizacionSGI
{
    class B1_Tarea
    {
        /// <summary>
        /// Prueba de Ingreso al módulo Tareas
        /// </summary>
        [Test]
        public void BA1_InsertarTarea()
        {
            try
            {
                #region "VALIDACION INICIAR LOGIN"

                Utilitarios.ValidacionIniciarPrueba();

                #endregion

                #region "EJECIÓN DE LA PRUEBA

                ElementosWebMenu elementosMenu = new ElementosWebMenu();

                elementosMenu.MenuProyectos.Click();

                System.Threading.Thread.Sleep(1500);

                elementosMenu.SubMenuProyectosTareas.Click();

                System.Threading.Thread.Sleep(1500);

                ElementosWebTareas elementosWebTareas = new ElementosWebTareas();

                elementosWebTareas.btnNuevaTarea.Click();

                System.Threading.Thread.Sleep(1000);

                var valorAConcatenar = DateTime.Now.ToString("hhmmss");

                elementosWebTareas.txtTitulo.SendKeys("Titulo"+ valorAConcatenar);

                elementosWebTareas.txtDecripcion.SendKeys("Decripcion" + valorAConcatenar);

                elementosWebTareas.ddlProyectos.SendKeys("Pruebas Automatizadas");

                elementosWebTareas.ddlEstado.SendKeys("Pendiente");

                elementosWebTareas.btnGuardarTarea.Click();

                System.Threading.Thread.Sleep(1000);

                string[] columnasAFiltrar = new string[] { "Título" };

                Dictionary<string, string> filtros = new Dictionary<string, string>();
                filtros.Add("Título", "Titulo" + valorAConcatenar);
                filtros.Add("Decripcion", "Decripcion" + valorAConcatenar);
                filtros.Add("Estado", "Pendiente");

                Utilitarios.ValidarExistenciaGrilla("tableTarea", columnasAFiltrar, filtros);

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
                Utilitarios.Espera(2000);

                if (ParametrosEjecucion.CerrarNavegadorPorPrueba)
                {
                    Prueba.Finalizar();
                }
            }
        }
    }
}
