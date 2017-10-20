using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {


        #region Constructores públicos

        public DniInvalidoException(): base()
        { 
        }

        public DniInvalidoException(string mensaje): base(mensaje)
        { 
        }

        public DniInvalidoException(string mensaje, string origenError):base(mensaje)
        {
            base.Source = origenError;
        }

        public DniInvalidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        { 
        }


        public DniInvalidoException(string mensaje, string origenError, Exception innerException)
            :base(mensaje, innerException)
        { 
        
        
        }

        public override string ToString()
        {
            return "Mensaje: " + base.Message + ", Origen del error: " + base.Source;
        }


        #endregion

    }
}
