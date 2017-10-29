using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region Constructores
        const string MENSAJE_ERROR = "No hay Profesor para la clase";

        public SinProfesorException()
            : base(MENSAJE_ERROR) { }

        public SinProfesorException(string message)
            : base(message) { }

        public SinProfesorException(string message, Exception inner)
            : base(message, inner) { }
        #endregion
    }
}
