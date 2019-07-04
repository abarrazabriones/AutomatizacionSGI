using System.Configuration;

namespace AutomatizacionSGI.Tranversal.Utilitario
{
    /// <summary>
    /// Clase con los parametros de ejecuccion del sistema SGI.
    /// </summary>
    public static class ParametrosEjecucion
    {
        public const string Usuario                     = "csoarzo";
        public const string Password                    = "cl4ud10";
        public const bool   EjecutaEspera               = false;
        public const bool   EjecutaCaptura              = true;
        public const bool   CerrarNavegadorPorPrueba    = true;
        public const bool   CerrarNavegadorPorModulo    = false;
        public static string Navegador                   = ConfigurationManager.AppSettings["Navegador"].ToString();
        public const string RutaCarpetaAutomatizacion   = "C:\\SGI";
        public const string RutaDelSitio                = "http://172.17.206.12:3610";
    }
}
