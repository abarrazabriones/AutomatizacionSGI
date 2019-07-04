using Excel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionSGI.Tranversal.Utilitario
{
    public class ExcelTestCaseDataReader
    {
        protected string ExcelFile { get; set; }

        protected List<string> Sheets { get; set; }

        protected List<string> Tests { get; set; }

        private IExcelDataReader GetExcelReader(string excelFile)
        {
            var stream = ObtenerStream(excelFile);

            IExcelDataReader excelReader;
            var extencion = excelFile.Trim().Substring(excelFile.LastIndexOf("."));
            switch (extencion.ToUpper())
            {
                case ".XLS":
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    break;
                case ".XLSX":
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    break;
                default:
                    throw new ArgumentException("Unknown file extension.");
            }
            return excelReader;
        }

        private Stream ObtenerStream(string excelFile)
        {
            Stream stream = null;

            stream = ObtenerArchivoExcelStreamDesdeArchivoDeSistema(excelFile);

            if (stream == null)
            {
                throw new FileNotFoundException(excelFile);
            }
            return stream;
        }


        protected virtual Stream ObtenerArchivoExcelStreamDesdeArchivoDeSistema(string rutaArchivoExcel)
        {
            var fileStream = new FileStream(rutaArchivoExcel, FileMode.Open, FileAccess.Read);
            return fileStream;
        }

        /// <summary>
        /// Returns a new instance of ExcelTestCaseDataReader
        /// </summary>
        /// <returns></returns>
        public static ExcelTestCaseDataReader Nuevo()
        {
            return new ExcelTestCaseDataReader();
        }        
        
        /// <summary>
        /// Loads the excel file from the file system
        /// </summary>
        /// <param name="excelFilePath">full absolute path to the excel file</param>
        /// <returns></returns>
        public ExcelTestCaseDataReader AgregarUrlArchivo(string excelFilePath)
        {
            ExcelFile = excelFilePath;
            //ReadFileFrom = ReadFileFrom.FileSystem;
            return this;
        }

        /// <summary>
        /// Add an existing sheet to the 
        /// </summary>
        /// <param name="sheetName">workbookk´s sheet name</param>
        /// <returns></returns>
        public ExcelTestCaseDataReader AgregarHoja(string sheetName)
        {
            if (Sheets == null)
            {
                Sheets = new List<string>();
            }
            Sheets.Add(sheetName);
            return this;
        }

        public ExcelTestCaseDataReader AgregarNombrePrueba(string testName)
        {
            if (Tests == null)
            {
                Tests = new List<string>();
            }
            Tests.Add(testName);
            return this;
        }
        
        public List<TestCaseData> ObtenerCasosDePrueba()
        {
            var testDataList = new List<TestCaseData>();
            var excelReader = GetExcelReader(ExcelFile);
            excelReader.IsFirstRowAsColumnNames = true;
            var result = excelReader.AsDataSet();

            foreach (var sheet in Sheets)
            {
                var sheetTable = result.Tables[sheet];

                IList<string> nombresColumnas = new List<string>();

                foreach (DataColumn columna in sheetTable.Columns)
                {
                    nombresColumnas.Add(columna.ColumnName);
                }

                int rowNum = 0;

                foreach (DataRow dr in sheetTable.Rows)
                {
                    if (dr[0].ToString().Equals(Tests.First()))
                    {
                        var testName = Tests.First() + "_" + rowNum;

                        IList<ParametroPrueba> listaParametrosPrueba = new List<ParametroPrueba>();

                        for (int i = 0; i < nombresColumnas.Count; i++)
                        {
                            ParametroPrueba parametroPrueba = new ParametroPrueba();
                            parametroPrueba.Nombre = nombresColumnas[i];
                            parametroPrueba.Valor = dr.ItemArray[i].ToString();

                            listaParametrosPrueba.Add(parametroPrueba);
                        }

                        TestCaseData testData = new TestCaseData(listaParametrosPrueba).SetName(testName);
                        testDataList.Add(testData);

                        rowNum++;
                    }
                }
            }

            excelReader.Close();
            return testDataList;
        }

    }
    
}
