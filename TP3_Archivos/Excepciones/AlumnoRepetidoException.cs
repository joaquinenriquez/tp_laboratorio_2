using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        #region Constructores

        const string MENSAJE_ERROR = "Alumno repetido.";

        public AlumnoRepetidoException()
            :base(MENSAJE_ERROR){ }
     

        public AlumnoRepetidoException(string message)
            : base(message) { }


        public AlumnoRepetidoException(string message, Exception inner)
            : base(message, inner) { }

        #endregion
    }
}
