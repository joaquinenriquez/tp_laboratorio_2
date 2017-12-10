using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        #region Atributos

        int legajo;

        #endregion

        #region Constructores
        
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Constructor que recibe como parametros: legajo, nombre, apellido, dni y nacionalidad
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Métodos de instancia virtuales

        /// <summary>
        /// Protegido y virtual: devuelve los datos del universitario
        /// </summary>
        /// <returns>String con los atributos de la clase base + el legajo</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder auxReturn = new StringBuilder(base.ToString());

            auxReturn.AppendFormat("{0}LEGAJO NÚMERO: {1}{2}", Environment.NewLine, this.legajo, Environment.NewLine);

            return auxReturn.ToString();
        }

        #endregion

        #region Métodos abstractos

        /// <summary>
        /// Metodo abstact para implemetar el metodo Participar en clase
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga de operadores
        
        /// <summary>
        /// Compara dos universitarios por DNI y por el tipo de objeto
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si son iguales, caso contrario: false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool auxReturn = false;

            if ((pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI) &&  (pg1.GetType() == pg2.GetType()))
                auxReturn = true;

            return auxReturn;
        }
        
        /// <summary>
        /// Compara dos universitarios por DNI y por tipo de objeto
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Devuelve true si son distintos, false caso contrario</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region Sobre-escritura de métodos

        /// <summary>
        /// Compara dos universitarios por DNI y por tipo de objeto
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Devuelve true si son distintos, false caso contrario</returns>
        public override bool Equals(object obj)
        {
            bool auxReturn = false;

            if ((this.GetType() == obj.GetType()) && (this.DNI == ((Universitario)obj).DNI || this.legajo == ((Universitario)obj).legajo))
                auxReturn = true;

            return auxReturn;
        }

        /// <summary>
        /// Llama al metodo mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
