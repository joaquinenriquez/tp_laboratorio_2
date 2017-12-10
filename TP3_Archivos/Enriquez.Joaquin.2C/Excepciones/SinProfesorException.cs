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

        public SinProfesorException()
            : base("No hay Profesor para la clase.")
        {}

        public SinProfesorException(string mensaje)
            : base(mensaje)
        { }

        public SinProfesorException(string mensaje, Exception inner)
            : base(mensaje, inner)
        { }

        #endregion 
    }
}
