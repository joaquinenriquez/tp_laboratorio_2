using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        #region Constructores
        
        public ArchivosException(string mensaje)
            :base(mensaje)
        { }

        public ArchivosException() : base("Ocurrio un error al intentar acceder al archivo")
        { }

        public ArchivosException(string mensaje, Exception inner)
            : base(mensaje, inner)
        { }

        #endregion
    }
}
