using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Profesor:Universitario
    {
        #region Atributos

        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #endregion

        #region Constructores
        
        /// <summary>
        /// Constructor estático. Inicializamos el atributo profesor
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Constructor que recibe como parametros: legajo, nombre, apellido, dni (string) y nacionalidad)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClase();
            this.RandomClase();
        }


        #endregion

        #region Métodos privados
        
        /// <summary>
        /// Asigna una clase random al atributo clase del dia
        /// </summary>
        private void RandomClase()
        {
            Array clases = Enum.GetValues(typeof(Universidad.EClases));
            Universidad.EClases claseRandom = (Universidad.EClases)clases.GetValue(Profesor.random.Next(clases.Length));
            this.clasesDelDia.Enqueue(claseRandom);
        }

        #endregion

        #region Sobrecarga de operadores
        
        /// <summary>
        /// Un profesor es igual a una clase si el mismo da la clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Verdadero si da la clase, caso contrario falso</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool auxReturn = false;

            foreach (Universidad.EClases auxClase in i.clasesDelDia)
            {
                if (clase == auxClase)
                {
                    auxReturn = true;
                    break;
                }
            }

            return auxReturn;
        }

        /// <summary>
        /// Un profesor es distinto a una clase si el mismo no da la clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Verdadero si no da la clase, caso contrario falso</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

        #region Sobre-escritura de métodos

        /// <summary>
        /// Muestra las clases del dia que da el profesor
        /// </summary>
        /// <returns>String "CLASE DEL DIA" + clases que da ese profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder auxReturn = new StringBuilder("CLASE DEL DIA:");

            auxReturn.AppendLine();
            foreach (Universidad.EClases auxClase in this.clasesDelDia)
                auxReturn.AppendLine(auxClase.ToString());

            return auxReturn.ToString();
        }

        /// <summary>
        /// Muestra los datos de un profesor
        /// </summary>
        /// <returns>String con todos los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder auxReturn = new StringBuilder(base.MostrarDatos());

            auxReturn.Append(this.ParticiparEnClase());

            return auxReturn.ToString();
        }

        /// <summary>
        /// Hace publico todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
