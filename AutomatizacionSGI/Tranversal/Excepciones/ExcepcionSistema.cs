using System;

namespace AutomatizacionSGI.Tranversal.Excepciones
{
    /// <summary>
    /// Excepcion del sistema utilizada para relanzar errores controlados en las pruebas.
    /// </summary>
    class ExcepcionSistema : Exception
    {
        /// <summary>
        /// Constructor de la Clase.
        /// </summary>
        public ExcepcionSistema()
        {
        }

        public ExcepcionSistema(string message)
        : base(message)
        {
        }

        public ExcepcionSistema(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
