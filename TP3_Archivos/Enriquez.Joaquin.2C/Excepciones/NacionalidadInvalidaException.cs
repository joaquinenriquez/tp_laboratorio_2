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

        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el número de DNI")
        { }

        public NacionalidadInvalidaException(string mensaje)
            :base(mensaje)
        { }

        public NacionalidadInvalidaException(string mensaje, Exception inner)
            : base(mensaje, inner)
        { }

        #endregion 
    }
}
