using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos

        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        
        public Universidad.EClases Clase
        {
            get { return this.clase;}
            set { this.clase = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto, inicializa la lista de alumnos
        /// </summary>
        private Jornada ()
        {
            this.alumnos = new List<Alumno>();
        }
        
        /// <summary>
        /// Constructor: recibe como parametros: clase y profesor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion
        
        #region Métodos de instancia

        /// <summary>
        /// Guarda en un archivo de texto los datos de una jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Devuelve true si pudo guardar el archivo</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivo = new Texto();
            archivo.Guardar("jornada.txt", jornada.ToString());
            return true;
        }

        /// <summary>
        /// Lee los datos de un archivo de texto.
        /// </summary>
        /// <returns>String con el contenido del archivo</returns>
        public static string Leer()
        {
            string salida;
            Texto archivo = new Texto();
            archivo.Leer("jornada.txt", out salida);
            return salida;
        }

        #endregion

        #region Sobre-escritura de métodos

        /// <summary>
        /// Muestra todos los datos de una jornada
        /// </summary>
        /// <returns>String con todos los datos de una jornada</returns>
        public override string ToString()
        {
            StringBuilder auxReturn = new StringBuilder();

            auxReturn.AppendLine("JORNADA:");
            auxReturn.AppendFormat("CLASE DE {0} POR {1}{2}", this.Clase, this.Instructor.ToString(), Environment.NewLine);
            auxReturn.AppendLine("ALUMNOS: ");
            foreach (Alumno auxAlumno in this.Alumnos)
                auxReturn.Append(auxAlumno.ToString());

            auxReturn.AppendLine("<------------------------------------------->");

            return auxReturn.ToString();
        }


        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Una jornada es igual a un alumno si el mismo participa en la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>True si participa, caso contrario false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool auxReturn = false;

            if (a == j.Clase)
                auxReturn = true;

            return auxReturn;
        }

        /// <summary>
        /// Una jornada es igual a un alumno si el mismo participa en la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>False si participa, caso contrario true</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(a == j.Clase);
        }

        /// <summary>
        /// Agrega un alumno a la clase una jornada solo si el mismo no participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Jornada con el alumno cargado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);

            return j;
        }

        #endregion
    }
}
