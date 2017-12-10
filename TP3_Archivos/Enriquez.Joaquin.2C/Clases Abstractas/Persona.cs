using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados

        public enum ENacionalidad { Argentino, Extranjero };

        #endregion

        #region Atributos de instancia

        string nombre;
        string apellido;
        int dni;
        ENacionalidad nacionalidad;

        #endregion

        #region Propiedades
        
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = this.ValidarNombreApellido(value); }
        }
        
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDNI(this.Nacionalidad, value); }
           
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = this.ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set { this.dni = ValidarDNI(this.Nacionalidad, value);  }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor que recibe como parametros: nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que recibe como parametros: nombre, apellido, dni (int) y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que recibe como parametros: nombre, apellido, dni (string) y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Valida que el dni (int) se encuentre entre 1 y 89999999 (para nacionalidad argentina) caso contrario lanza excepcion
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el el mismo dato recibido como parametro</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case (ENacionalidad.Argentino):
                {
                    if (dato < 1 || dato > 89999999)
                        throw new DniInvalidoException();

                    break;
                }

                case ENacionalidad.Extranjero:
                    {
                        if (dato >= 1 && dato <= 89999999)
                            throw new NacionalidadInvalidaException();

                        break;

                    }
            }

            return dato;
        }

        /// <summary>
        /// Valida que el dni (string) se encuentre entre 1 y 89999999 (para nacionalidad argentina) caso contrario lanza excepcion
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el el mismo dato recibido como parametro</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int auxReturn;

            if (!int.TryParse(dato, out auxReturn))
                throw new DniInvalidoException();
            
            return this.ValidarDNI(nacionalidad, auxReturn);
        }

        /// <summary>
        /// Valida que un string solo tenga letras
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Si solo contiene letras devuelve el mismo dato, caso contrario devuelve vacio.</returns>
        private string ValidarNombreApellido(string dato)
        {
            string auxReturn = "";

            if (Regex.IsMatch(dato, "^[A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ ]+$"))
                auxReturn = dato;

            return auxReturn;
        }


        #endregion

        #region Sobre-escritura de métodos

        /// <summary>
        /// Sobrecarga del metodo ToString para mostrar los atributos del objeto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder auxReturn = new StringBuilder();

            auxReturn.AppendFormat("NOMBRE COMPLETO: {0}, {1}{2}", this.Apellido, this.Nombre, Environment.NewLine);
            auxReturn.AppendFormat("NACIONALIDAD: {0}{1}", this.nacionalidad, Environment.NewLine);

            return auxReturn.ToString();
        }

        #endregion

    }
}
