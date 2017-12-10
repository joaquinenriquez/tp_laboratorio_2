using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Enumerados

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        #endregion

        #region Atributos

        List<Alumno> alumnos;
        List<Profesor> profesores;
        List<Jornada> jornadas;

        #endregion

        #region Propiedades
        
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value;}
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        #endregion

        #region Indizadores
        
        public Jornada this[int i]
        {
            get { return this.jornadas[i]; }
            set { this.jornadas[i] = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto. Inicializa listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornadas = new List<Jornada>();
        }
        
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Una universidad es igual a un alumno si este ultimo esta inscripto en la misma
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Verdadero si se encuentra inscripto, falso caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool auxReturn = false;

            foreach (Alumno auxAlumno in g.Alumnos)
            {
                if (auxAlumno == a)
                {
                    auxReturn = true;
                    break;
                }
            }

            return auxReturn;
        }

        /// <summary>
        /// Una universidad es igual a un alumno si este ultimo esta inscripto en la misma
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Verdadero si no se encuentra inscripto, falso caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una universidad es igual a un profesor si este ultimo esta inscripto en la misma
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Verdadero si se encuentra inscripto, falso caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool auxReturn = false;

            foreach(Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor == i)
                {
                    auxReturn = true;
                    break;
                }
            }

            return auxReturn;
        }

        /// <summary>
        /// Una universidad es distinto a un profesor si este ultimo no esta inscripto en la misma
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Verdadero si no se encuentra inscripto, falso caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega un alumno a la universidad. En caso de estar repetido lanza una excepción
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Universidad con el alumno cargado</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();

            g.Alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Una universidad es igual a una clase si hay un profesor que dicte esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Un profesor en caso de que existe uno, caso contrario se lanza una excepción</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor auxReturn = new Profesor();

            foreach(Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor == clase)
                {
                    auxReturn = auxProfesor;
                    break;
                }
                else
                    throw new SinProfesorException();
            }

            return auxReturn;
        }

        /// <summary>
        /// Una universidad es distinta a una clase si no tiene un profesor que dicte esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Verdadero si encuentra un profesor, falso caso contrario</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor auxReturn = new Profesor();

            foreach(Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor != clase)
                {
                    auxReturn = auxProfesor;
                    break;
                }
            }

            return auxReturn;
        }

        /// <summary>
        /// Agrega un profesor a una universidad siempre y cuando no se encuentre ya cargado
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>Universidad con el profesor cargado</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g.Instructores.Add(i);

            return g;
        }

        /// <summary>
        /// Crea una jornada con la clase y un profesor que pueda dar esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Universidad con la jornada cargada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada;

            foreach (Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor == clase)
                {
                    nuevaJornada = new Jornada(clase, auxProfesor);

                    foreach (Alumno auxAlumno in g.Alumnos)
                        if (auxAlumno == clase)
                            nuevaJornada.Alumnos.Add(auxAlumno);

                    g.Jornadas.Add(nuevaJornada);

                    break;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }

            return g;
        }


        #endregion

        #region Métodos privados

        /// <summary>
        /// Muestra todos los datos de una universidad
        /// </summary>
        /// <param name="gim"></param>
        /// <returns>String con todos los datos de una universidad</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder auxReturn = new StringBuilder();

            foreach (Jornada auxJornada in gim.Jornadas)
                auxReturn.AppendLine(auxJornada.ToString());

            foreach (Alumno auxAlumno in gim.Alumnos)
                auxReturn.AppendLine(auxAlumno.ToString());

            foreach (Profesor auxProfesor in gim.profesores)
                auxReturn.AppendLine(auxProfesor.ToString());

            return auxReturn.ToString();
        }

        #endregion

        #region Métodos públicos
        
        /// <summary>
        /// Serializa un objeto Univsersidad como XML
        /// </summary>
        /// <param name="gim"></param>
        /// <returns>Verdadero si logro guardar el archivo, falso caso contrario</returns>
        public static bool Guardar (Universidad gim)
        {
            Xml<Universidad> archivo = new Xml<Universidad>();
            return archivo.Guardar("universidad.xml", gim);
        }

        /// <summary>
        /// Deserializa un objeto universidad desde un archivo XML
        /// </summary>
        /// <returns>Verdadero si lo logro hacer, falso caso contrario</returns>
        public static Universidad Leer()
        {
            Universidad uni;
            Xml<Universidad> archivo = new Xml<Universidad>();
            archivo.Leer("universidad.xml", out uni);
            return uni;
        }
        
        #endregion

        #region Sobre-escritura de métodos

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

    }
}
