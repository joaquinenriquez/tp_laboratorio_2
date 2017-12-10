using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno:Universitario
    {
        #region Enumerados
        
        public enum EEstadoCuenta { AlDia, Deudor, Becado}

        #endregion

        #region Atributos

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores
        
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {    
        }
        
        /// <summary>
        /// Constructor que recibe como parametros: legajo, nombre, apellido, dni (string) nacionalidad, clases que toma)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor que recibe como parametros: legajo, nombre, apellido, dni (string), nacionalidad, claes que toma y estado de la cuenta)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Sobre-escritura de métodos
        
        /// <summary>
        /// Devuelve la clase que toma el alumno
        /// </summary>
        /// <returns>String "TOMA CLASE DE" seguido de la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            string auxRetun = "TOMA CLASE DE " + this.claseQueToma + Environment.NewLine;

            return auxRetun;
        }

        /// <summary>
        /// Devuelve todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Devuelve todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder auxReturn = new StringBuilder(base.MostrarDatos());
            string auxEstadoCuenta = this.estadoCuenta.ToString();


            if (this.estadoCuenta == EEstadoCuenta.AlDia)
                auxEstadoCuenta = "Cuota al día";

            auxReturn.AppendFormat("ESTADO DE CUENTA: {0}{1}", auxEstadoCuenta, Environment.NewLine);
            auxReturn.Append(this.ParticiparEnClase());

            return auxReturn.ToString();
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara un alumno con una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Verdadero, si el alumno toma esa clase y no es deudor, caso contrario falso</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool auxReturn = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                auxReturn = true;

            return auxReturn;
        }

        /// <summary>
        /// Compara un alumno con una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Verdadero, si el alumno no toma esa clase, caso contrario falso</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        
        
        #endregion
    }
}
