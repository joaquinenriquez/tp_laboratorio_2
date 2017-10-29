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

        public enum ENacionalidad { Argentino, Extranjero }

        #endregion

        #region Atributos privados

        string nombre;
        string apellido;

        ENacionalidad nacionalidad;

        int dni;

        #endregion

        #region Propiedades públicas

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }  
        }


        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }  
        }


        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.Nacionalidad, value); }
        }


        public string StringToDNI
        {
            set {this.DNI = ValidarDni(this.Nacionalidad, value); }
        }


        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

      
        #endregion

        #region Constructores

        protected Persona()
        { }

        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        protected Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        #endregion

        #region Métodos privados

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            const int MAX_DNI = 89999999;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:

                    if (dato < 1 || dato > MAX_DNI)
                        throw new DniInvalidoException();

                    break;

                case ENacionalidad.Extranjero:
                    if (dato < MAX_DNI)
                        throw new NacionalidadInvalidaException();

                    break;
            }

            return dato;
        }


        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if (int.TryParse(dato, out dni))
                dni = ValidarDni(nacionalidad, dni);
            else
                throw new DniInvalidoException();

            return dni;

        }


        private string ValidarNombreApellido(string dato)
        {
            for (int pos = 0; pos < dato.Length; pos++)
            {
                if (!char.IsLetter(dato[pos]))                  
                    if (!char.IsWhiteSpace(dato[pos]))
                    {
                        dato = "";
                        break;
                    }
                    else if (char.IsWhiteSpace(dato[pos - 1])) //Por si tiene dos espacios seguidos
                    {
                        dato = "";
                        break;
                    }
            }

            return dato;
        }


        

        #endregion

        #region Sobrescritura de métodos

        public override string ToString()
        {
            StringBuilder salida = new StringBuilder();

            salida.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            salida.Append(Environment.NewLine);

            salida.AppendFormat("NACIONALIDAD: {0}", this.nacionalidad);
            salida.Append(Environment.NewLine);

            return salida.ToString();
        }


        #endregion
    }
}
