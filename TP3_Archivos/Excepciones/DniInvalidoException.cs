using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        #region Constructores
        const string MENSAJE_ERROR = "DNI no válido";

        public DniInvalidoException()
            :base(MENSAJE_ERROR){ }

        public DniInvalidoException(string message)
            : base(message) { }

        public DniInvalidoException(string message, Exception inner)
            : base(message, inner) { }
        #endregion
    }   
}
