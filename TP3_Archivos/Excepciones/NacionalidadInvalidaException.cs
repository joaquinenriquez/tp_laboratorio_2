using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        #region Constructores
        const string MENSAJE_ERROR = "La nacionalidad no se condice con el número de DNI";

        public NacionalidadInvalidaException()
            :base(MENSAJE_ERROR){ }

        public NacionalidadInvalidaException(string message)
            : base(message) { }

        public NacionalidadInvalidaException(string message, Exception inner)
            : base(message, inner) { }
        #endregion
    }
}
