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

        public DniInvalidoException(string mensaje)
            :base(mensaje)
        { }

        public DniInvalidoException() : base("DNI no valido")
        { }

        public DniInvalidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        { }

        #endregion
    }
}
