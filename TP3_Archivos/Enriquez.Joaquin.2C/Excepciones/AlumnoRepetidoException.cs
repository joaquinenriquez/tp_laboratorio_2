using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Constructores

        /// <summary>
        /// Constructor por defecto con mensaje propio
        /// </summary>
        public AlumnoRepetidoException()
            : base("Alumno repetido.")
        { }

        /// <summary>
        /// Constructor que recibe como parametro el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        { }
    
        /// <summary>
        /// Constructor que recibe como parametros el mensaje a mostrar y la excepcion que original
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public AlumnoRepetidoException(string mensaje, Exception inner)
            :base(mensaje, inner)
        { }

        #endregion
    }
}
