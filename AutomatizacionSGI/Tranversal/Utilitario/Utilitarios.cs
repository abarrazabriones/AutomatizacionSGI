using AutomatizacionSGI.Login.Propiedades;
using AutomatizacionSGI.Tareas.Propiedades;
using AutomatizacionSGI.Tranversal.Excepciones;
using AutomatizacionSGI.Tranversal.Menu.Propiedades;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatizacionSGI.Tranversal.Utilitario
{
    /// <summary>
    /// Clase de utilitarios del sistema SGI.
    /// </summary>
    public class Utilitarios
    {
        /// <summary>
        /// Método utilizado para generar delay en las pruebas
        /// </summary>
        /// <param name="valorEspera"></param>
        public static void Espera(int valorEspera)
        {
            bool ejecutaEspera = Convert.ToBoolean(ParametrosEjecucion.EjecutaEspera);

            if (ejecutaEspera)
            {
                System.Threading.Thread.Sleep(valorEspera);
            }
        }
        /// <summary>
        /// Método de captura de pantalla
        /// </summary>
        /// <param name="nombreImagen"></param>
        public static void GenerarCaptura(string nombreImagen)
        {
            bool ejecutaCaptura = Convert.ToBoolean(ParametrosEjecucion.EjecutaCaptura);

            if (ejecutaCaptura)
            {
                System.Threading.Thread.Sleep(2000);

                int wid = Screen.GetBounds(new Point(0, 0)).Width;
                int he = Screen.GetBounds(new Point(0, 0)).Height;
                Bitmap now = new Bitmap(wid, he);
                Graphics grafico = Graphics.FromImage((Image)now);
                grafico.CopyFromScreen(0, 0, 0, 0, new Size(wid, he));
                // usando "grafico"
                now.Save(ParametrosEjecucion.RutaCarpetaAutomatizacion + "\\screenshot\\" + nombreImagen + "_"
                    + DateTime.Now.Hour + "_"
                    + DateTime.Now.Minute + "_"
                    + DateTime.Now.Second + "_"
                    + DateTime.Now.Millisecond.ToString() + ".jpg", ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// Método ára obtener la lista de elementos web por Tag
        /// </summary>
        /// <param name="nombreTag"></param>
        /// <returns></returns>
        public static List<IWebElement> ObtieneElementosPorTag(string nombreTag)
        {
            List<IWebElement> listaWebElements = new List<IWebElement>();

            if (PropiedadColeccionDriver.driver != null)
            {
                listaWebElements = PropiedadColeccionDriver.driver.FindElements(By.TagName(nombreTag)).ToList();
            }

            return listaWebElements;
        }

        /// <summary>
        /// Método para obtener la lista de elementos web por Id
        /// </summary>
        /// <param name="nombreId"></param>
        /// <returns></returns>
        public static List<IWebElement> ObtieneElementosPorId(string nombreId)
        {
            List<IWebElement> listaWebElements = new List<IWebElement>();

            if (PropiedadColeccionDriver.driver != null)
            {
                listaWebElements = PropiedadColeccionDriver.driver.FindElements(By.Id(nombreId)).ToList();
            }

            return listaWebElements;
        }

        /// <summary>
        /// Método para obtener la lista de elementos web por Nombre de la Clase
        /// </summary>
        /// <param name="nombreClase"></param>
        /// <returns></returns>
        public static List<IWebElement> ObtieneElementosPorClase(string nombreClase)
        {
            List<IWebElement> listaWebElements = new List<IWebElement>();

            if (PropiedadColeccionDriver.driver != null)
            {
                listaWebElements = PropiedadColeccionDriver.driver.FindElements(By.ClassName(nombreClase)).ToList();
            }

            return listaWebElements;
        }

        /// <summary>
        /// Método ára obtener la lista de elementos web por Clase Compuesta
        /// </summary>
        /// <param name="nombreClaseCompuesta"></param>
        /// <returns></returns>
        public static List<IWebElement> ObtieneElementosPorClaseCompuesta(string nombreClaseCompuesta)
        {
            List<IWebElement> listaWebElements = new List<IWebElement>();

            if (PropiedadColeccionDriver.driver != null)
            {
                listaWebElements = PropiedadColeccionDriver.driver.FindElements(By.CssSelector("[class='" + nombreClaseCompuesta + "']")).ToList();
            }

            return listaWebElements;
        }

        /// <summary>
        /// Método para Iniciar la ejecución de la prueba
        /// </summary>
        public static void ValidacionIniciarPrueba()
        {
            string usuario = ParametrosEjecucion.Usuario;
            string password = ParametrosEjecucion.Password;

            if (PropiedadColeccionDriver.driver != null)
            {
                var pestañasNavegador = PropiedadColeccionDriver.driver.WindowHandles;

                if (pestañasNavegador.Count > 0)
                {
                    /*VALIDACION DE LOGEO*/
                    var dropDownMenu = PropiedadColeccionDriver.driver.FindElements(By.ClassName("user-menu"));

                    if (dropDownMenu.Count > 0)
                    {
                        if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio + "/Gestion")
                        {
                            PropiedadColeccionDriver.driver.Url = ParametrosEjecucion.RutaDelSitio + "/Gestion";
                        }
                    }
                    else
                    {
                        ElementosWebLogin elementosLogin = new ElementosWebLogin();

                        elementosLogin.txtUsuario.SendKeys(usuario);

                        elementosLogin.txtPassword.SendKeys(password);

                        elementosLogin.btnLogin.Click();

                        System.Threading.Thread.Sleep(2000);

                        if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio + "/Gestion")
                        {
                            throw new ExcepcionSistema("VALIDACION: Error al inicial sesión en la aplicación.");
                        }
                    }
                }
                else
                {
                    Prueba.Iniciar(ParametrosEjecucion.Navegador, ParametrosEjecucion.RutaDelSitio);

                    ElementosWebLogin elementosLogin = new ElementosWebLogin();

                    elementosLogin.txtUsuario.SendKeys(usuario);

                    elementosLogin.txtPassword.SendKeys(password);

                    elementosLogin.btnLogin.Click();

                    System.Threading.Thread.Sleep(2000);

                    if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio + "/Gestion")
                    {
                        throw new ExcepcionSistema("VALIDACION: Error al inicial sesión en la aplicación.");
                    }
                }
            }
            else
            {
                Prueba.Iniciar(ParametrosEjecucion.Navegador, ParametrosEjecucion.RutaDelSitio);

                ElementosWebLogin elementosLogin = new ElementosWebLogin();

                elementosLogin.txtUsuario.SendKeys(usuario);

                elementosLogin.txtPassword.SendKeys(password);

                elementosLogin.btnLogin.Click();

                System.Threading.Thread.Sleep(4000);

                if (PropiedadColeccionDriver.driver.Url != ParametrosEjecucion.RutaDelSitio + "/Gestion")
                {
                    throw new ExcepcionSistema("VALIDACION: Error al inicial sesión en la aplicación.");
                }
            }
        }

        /// <summary>
        /// Método para validar el login
        /// </summary>
        public static void ValidacionLogin()
        {
            if (PropiedadColeccionDriver.driver != null)
            {
                var pestañasNavegador = PropiedadColeccionDriver.driver.WindowHandles;

                if (pestañasNavegador.Count > 0)
                {
                    var dropDownMenu = PropiedadColeccionDriver.driver.FindElements(By.ClassName("user-menu"));

                    if (dropDownMenu.Count > 0)
                    {
                        ElementosWebLogin elementosLogout = new ElementosWebLogin();

                        elementosLogout.btnCerrar.Click();

                        elementosLogout.btnCerrarSesion.Click();
                    }

                }
                else
                {
                    Prueba.Iniciar(ParametrosEjecucion.Navegador, ParametrosEjecucion.RutaDelSitio);
                }
            }
            else
            {
                Prueba.Iniciar(ParametrosEjecucion.Navegador, ParametrosEjecucion.RutaDelSitio);
            }
        }

        public static bool ValidarExistenciaGrilla(string idGrilla, string[] columnasAFiltrar, Dictionary<string, string> datosParaFiltrar)
        {
            ElementosWebPaginador elementoPaginador = new ElementosWebPaginador();
            var elementosNumericos = elementoPaginador.Paginador.Where(x => !x.Text.Equals("Anterior") && !x.Text.Equals("Siguiente"));

            int ultimaPagina = Convert.ToInt32(elementosNumericos.Last().Text);

            for (int i = 1; i <= ultimaPagina; i++)
            {
                var elementosColumnasCabecera = PropiedadColeccionDriver.driver.FindElements(By.XPath("id('" + idGrilla + "')/thead/tr/th"));

                Dictionary<int, string> diccionarioCabeceras = new Dictionary<int, string>();
                int contador = 1;

                foreach (var fila in elementosColumnasCabecera)
                {
                    diccionarioCabeceras.Add(contador, fila.Text);
                    contador++;
                }

                List<IList<Columna>> filas = new List<IList<Columna>>();
                IList<Columna> columnasConCabecera = new List<Columna>();

                var elementosColumnasTabla = PropiedadColeccionDriver.driver.FindElements(By.XPath("id('" + idGrilla + "')/tbody/tr/td"));

                int indiceCabecera = 0;
                int indiceFilaGrilla = 0;

                Columna columna = new Columna();

                for (int c = 0; c < elementosColumnasTabla.Count; c++)
                {
                    indiceCabecera = indiceCabecera + 1;

                    columna.IndiceFilaGrilla = indiceFilaGrilla;
                    columna.Id = diccionarioCabeceras[indiceCabecera].ToString();
                    columna.Valor = elementosColumnasTabla[c].Text;

                    columnasConCabecera.Add(columna);
                    columna = new Columna();

                    if (indiceCabecera == diccionarioCabeceras.Count)
                    {
                        indiceFilaGrilla++;
                        filas.Add(columnasConCabecera);
                        columnasConCabecera = new List<Columna>();
                        indiceCabecera = 0;
                    }
                }

                bool registroExiste = true;
                var filaAPintar = new List<IList<Columna>>();

                foreach (var item in columnasAFiltrar)
                {
                    var valorABuscar = datosParaFiltrar.FirstOrDefault(x => x.Key.Equals(item)).Value;

                    if (!filas.Any(x => x.Any(y => y.Id.Equals(item) && y.Valor.Equals(valorABuscar))))
                    {
                        registroExiste = false;
                        break;
                    }
                    else
                    {
                        if (filaAPintar.Any())
                        {
                            filaAPintar = filaAPintar.Where(x => x.Any(y => y.Id.Equals(item) && y.Valor.Equals(valorABuscar))).ToList();
                        }
                        else
                        {
                            filaAPintar = filas.Where(x => x.Any(y => y.Id.Equals(item) && y.Valor.Equals(valorABuscar))).ToList();
                        }

                        registroExiste = true;
                        continue;
                    }
                }


                if (registroExiste == true)
                {
                    int indiceFilaAPintar = filaAPintar.First().First().IndiceFilaGrilla;

                    IJavaScriptExecutor js = (IJavaScriptExecutor)PropiedadColeccionDriver.driver;
                    IList<IWebElement> listaFilasTabla = new List<IWebElement>();

                    listaFilasTabla = PropiedadColeccionDriver.driver.FindElements(By.XPath("id('" + idGrilla + "')/tbody/tr")).ToList();

                    js.ExecuteScript("arguments[0].setAttribute('style', 'color:red')", listaFilasTabla[indiceFilaAPintar]);

                    break;
                }

                if (i != ultimaPagina)
                {
                    elementoPaginador.BotonSiguiente.Click();
                }
                else if (i == ultimaPagina)
                {
                    throw new ExcepcionSistema("No ha sido posible encontrar el registro insertado.");
                }
            }

            GenerarCaptura("Existencia_de_Registro_en_Grilla");

            return true;
        }

        public static Dictionary<string, string> ObtenerParametrosPorExcel(string nombreHoja, string nombrePrueba)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            Microsoft.Office.Interop.Excel.Range range;

            string str = string.Empty;
            int rCnt;
            int cCnt;
            int numeroDeFilas = 0;
            int numeroDeColumnas = 0;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(ParametrosEjecucion.RutaCarpetaAutomatizacion + "\\SGI.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            IList<string> nombre = new List<string>();
            bool encontroRegistro = false;
            Dictionary<string, string> diccionario = new Dictionary<string, string>();

            foreach (var worksheet in xlWorkBook.Worksheets)
            {
                var hojaExcel = (Microsoft.Office.Interop.Excel.Worksheet)worksheet;

                if (hojaExcel.Name.Equals(nombreHoja))
                {
                    range = hojaExcel.UsedRange;
                    numeroDeFilas = range.Rows.Count;
                    numeroDeColumnas = range.Columns.Count;

                    for (rCnt = 1; rCnt <= numeroDeFilas; rCnt++)
                    {
                        if (string.IsNullOrEmpty(str))
                        {
                            //Asigno la primera ves
                            str = Convert.ToString((range.Cells[rCnt, 1] as Microsoft.Office.Interop.Excel.Range).Value2);
                        }
                        else if (!encontroRegistro)
                        {
                            //Asigno por que no he encontrado el registro.
                            str = Convert.ToString((range.Cells[rCnt, 1] as Microsoft.Office.Interop.Excel.Range).Value2);
                        }
                        else if (encontroRegistro && (str == Convert.ToString((range.Cells[rCnt, 1] as Microsoft.Office.Interop.Excel.Range).Value2)))
                        {
                            //Asigno por que encontre el registro y aun continuo obteniendo variables de la prueba.
                            str = Convert.ToString((range.Cells[rCnt, 1] as Microsoft.Office.Interop.Excel.Range).Value2);
                        }
                        else if (encontroRegistro && (str != Convert.ToString((range.Cells[rCnt, 1] as Microsoft.Office.Interop.Excel.Range).Value2)))
                        {
                            //Lo boto del ciclo por que ya obtuve todas las variables de la prueba.
                            break;
                        }

                        if (!string.IsNullOrEmpty(str) && str.Equals(nombrePrueba))
                        {
                            //Obtengo Las Variables
                            diccionario.Add(Convert.ToString((range.Cells[rCnt, 2] as Microsoft.Office.Interop.Excel.Range).Value2), Convert.ToString((range.Cells[rCnt, 3] as Microsoft.Office.Interop.Excel.Range).Value2));
                            encontroRegistro = true;
                        }
                    }
                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            return diccionario;
        }
    }
}
