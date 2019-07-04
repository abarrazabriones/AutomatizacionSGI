using AutomatizacionSGI.Login.Propiedades;
using AutomatizacionSGI.Tranversal;
using AutomatizacionSGI.Tranversal.Excepciones;
using AutomatizacionSGI.Tranversal.Utilitario;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatizacionSGI
{
    public class A1_Login
    {
        /// <summary>
        /// Prueba de login del sistema.
        /// </summary>
        [TestCaseSource("SourceTestCaseData")]
        public void AA1_LoginSGI(IList<ParametroPrueba> parametroPrueba)
        {
            string usuario = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Usuario")).Valor;
            string password = parametroPrueba.FirstOrDefault(x => x.Nombre.Equals("Password")).Valor;

            try
            {
                #region "VALIDACION LOGIN"

                Utilitarios.ValidacionLogin();

                #endregion

                #region "EJECUCION DE LA PRUEBA"

                ElementosWebLogin elementosLogin = new ElementosWebLogin();

                elementosLogin.txtUsuario.SendKeys(usuario);

                elementosLogin.txtPassword.SendKeys(password);

                Utilitarios.GenerarCaptura("AA1_LoginSGI_Captura1_Ingreso de Campos");

                System.Threading.Thread.Sleep(1000);

                elementosLogin.btnLogin.Click();

                System.Threading.Thread.Sleep(1000);

                Utilitarios.GenerarCaptura("AA1_LoginSGI_Captura2_Click botón Login");

                /*Validacion de pagina inicial*/
                if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio+"/Gestion")
                {
                    Utilitarios.GenerarCaptura("AA1_LoginSGI_Captura3_Error validación");

                    throw new ExcepcionSistema("VALIDACION: Error usuario no pudo iniciar sesión en la aplicación.");
                }

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
            }
        }

        /// <summary>
        /// Prueba de usuario y contraseña inválidos
        /// </summary>
        [Test]
        public void AA2_LoginMensajeErrorSGI()
        {
            Dictionary<string, string> diccionario = Utilitarios.ObtenerParametrosPorExcel("Login", "AA2_LoginMensajeErrorSGI");

            string usuario = diccionario.Where(x => x.Key.Equals("Usuario")).FirstOrDefault().Value;
            string password = diccionario.Where(x => x.Key.Equals("Password")).FirstOrDefault().Value;

            try
            {
                #region "VALIDACION LOGIN"

                Utilitarios.ValidacionLogin();

                #endregion 

                #region "EJECUCION DE LA PRUEBA"

                ElementosWebLogin elementosLogin = new ElementosWebLogin();

                System.Threading.Thread.Sleep(4000);

                elementosLogin.txtUsuario.SendKeys(usuario);

                System.Threading.Thread.Sleep(1000);

                elementosLogin.txtPassword.SendKeys(password);

                System.Threading.Thread.Sleep(1000);

                Utilitarios.GenerarCaptura("AA2_LoginMensajeErrorSGI_Captura1_Ingreso de campos");

                System.Threading.Thread.Sleep(1500);

                elementosLogin.btnLogin.Click();

                System.Threading.Thread.Sleep(1500);

                Utilitarios.GenerarCaptura("AA2_LoginMensajeErrorSGI_Captura2_Click botón login");

                /*Validacion de pagina inicial*/
                if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio+"/Gestion")
                {
                    List<IWebElement> listaElementosTagName = Utilitarios.ObtieneElementosPorTag("div");

                    if (!listaElementosTagName.Where(x => x.Text.Equals("El nombre de usuario o la contraseña especificados son incorrectos.")).Any())
                    {
                        Utilitarios.GenerarCaptura("AA2_LoginMensajeErrorSGI_Captura3_Error validación");

                        throw new ExcepcionSistema("VALIDACION: Error, no despliega mensaje que indica que el usuario o la contraseña son inválidos.");
                    }
                    else
                    {
                        elementosLogin.btnAceptar.Click();
                    }
                }

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
            }
        }

        /// <summary>
        /// Prueba campos requeridos
        /// </summary>
        [Test]
        public void AA3_LoginCamposRequeridos()
        {
            try
            {
                #region "VALIDACION LOGIN"

                Utilitarios.ValidacionLogin();

                #endregion 

                #region "EJECUCION DE LA PRUEBA"

                ElementosWebLogin elementosLogin = new ElementosWebLogin();

                System.Threading.Thread.Sleep(1000);

                elementosLogin.txtUsuario.Clear();

                System.Threading.Thread.Sleep(1000);

                elementosLogin.txtPassword.Clear();

                System.Threading.Thread.Sleep(1500);

                Utilitarios.GenerarCaptura("AA3_LoginCamposRequeridos_Captura1_Limpia campos");

                elementosLogin.btnLogin.Click();

                System.Threading.Thread.Sleep(1500);

                Utilitarios.GenerarCaptura("AA3_LoginCamposRequeridos_Captura2_Click botón login");

                List<IWebElement> listaElementoTagName = Utilitarios.ObtieneElementosPorTag("div");

                if (!listaElementoTagName.Where(x => x.Text.Equals("Nombre de usuario es obligatorio")).Any())
                {
                    System.Threading.Thread.Sleep(1500);

                    Utilitarios.GenerarCaptura("AA3_LoginCamposRequeridos_Captura3_Error Validacion");

                    throw new ExcepcionSistema("VALIDACION: Error, al desplegar mensaje de Usuario requerido.");
                }
                else if (!listaElementoTagName.Where(x => x.Text.Equals("Contraseña es obligatorio")).Any())
                {
                    System.Threading.Thread.Sleep(1500);

                    Utilitarios.GenerarCaptura("AA3_LoginCamposRequeridos_Captura4_Error validación");

                    throw new ExcepcionSistema("VALIDACION: Error, al desplegar mensaje de Contraseña requerido.");
                }

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
            }

        }

        /// <summary>
        /// Prueba cerrar sesion usuario
        /// </summary>
        [Test]
        public void AA4_LogoutSGI()
        {

            Dictionary<string, string> diccionario = Utilitarios.ObtenerParametrosPorExcel("Login", "AA4_LogoutSGI");

            string usuario = diccionario.Where(x => x.Key.Equals("Usuario")).FirstOrDefault().Value;
            string password = diccionario.Where(x => x.Key.Equals("Password")).FirstOrDefault().Value;

            try
            {
                #region "VALIDACION LOGIN"

                Utilitarios.ValidacionLogin();

                #endregion

                #region "EJECUCIÓN DE LA PRUEBA"

                ElementosWebLogin elementosLogout = new ElementosWebLogin();

                if (PropiedadColeccionDriver.driver != null)
                {
                    var dropDownMenu = Utilitarios.ObtieneElementosPorClase("user-menu");

                    if (dropDownMenu.Count > 0)
                    {
                        elementosLogout.btnCerrar.Click();

                        Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura1_Click botón cerrar");

                        System.Threading.Thread.Sleep(1500);

                        elementosLogout.btnCerrarSesion.Click();

                        Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura2_Click botón cerrar sesión");

                        if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio)
                        {
                            System.Threading.Thread.Sleep(1500);

                            Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura3_Error validación");

                            throw new ExcepcionSistema("VALIDACION: Error, el usuario no pudo salir del sistema.");
                        }
                    }
                    else
                    {
                        ElementosWebLogin elementosLogin = new ElementosWebLogin();

                        elementosLogin.txtUsuario.SendKeys(usuario);

                        elementosLogin.txtPassword.SendKeys(password);

                        System.Threading.Thread.Sleep(1500);

                        Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura4_Completa campos");

                        elementosLogin.btnLogin.Click();

                        System.Threading.Thread.Sleep(1500);

                        Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura5_Click botón login");

                        if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio + "/Gestion")
                        {
                            PropiedadColeccionDriver.driver.Url = ParametrosEjecucion.RutaDelSitio + "/Gestion";
                        }
                    }
                }
                else
                {
                    ElementosWebLogin elementosLogin = new ElementosWebLogin();

                    elementosLogin.txtUsuario.SendKeys(usuario);

                    elementosLogin.txtPassword.SendKeys(password);

                    System.Threading.Thread.Sleep(1500);

                    Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura6_Completa campos");

                    elementosLogin.btnLogin.Click();

                    System.Threading.Thread.Sleep(1500);

                    Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura7_Click botón login");

                    if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio + "/Gestion")
                    {
                        PropiedadColeccionDriver.driver.Url = ParametrosEjecucion.RutaDelSitio + "/Gestion";
                    }
                }

                elementosLogout.btnCerrar.Click();

                System.Threading.Thread.Sleep(1500);

                Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura8_Click botón cerrar");

                elementosLogout.btnCerrarSesion.Click();

                System.Threading.Thread.Sleep(1500);

                Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura9_Click botón cerrar sesión");

                if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio)
                {
                    System.Threading.Thread.Sleep(1500);

                    Utilitarios.GenerarCaptura("AA4_LogoutSGI_Captura10_Error validación");

                    throw new ExcepcionSistema("VALIDACION: Error, el usuario no pudo salir del sistema.");
                }

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
            }
        }

        public static IEnumerable<TestCaseData> SourceTestCaseData
        {
            get
            {
                IList<TestCaseData> testcases = ExcelTestCaseDataReader.Nuevo()
                                                    .AgregarUrlArchivo(ParametrosEjecucion.RutaCarpetaAutomatizacion + "/SGI.xlsx")
                                                    .AgregarHoja("Login")
                                                    .AgregarNombrePrueba("AA1_LoginSGI")
                                                    .ObtenerCasosDePrueba();

                foreach (TestCaseData testCaseData in testcases)
                {
                    yield return testCaseData;
                }
            }
        }

    }
}
