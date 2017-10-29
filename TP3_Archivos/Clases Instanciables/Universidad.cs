using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Enumerados

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        
        #endregion

        #region Atributos privados

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesor;

        #endregion

        #region Constructores
        
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesor = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        
        #endregion

        #region Propiedades públicas

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesor; }
            set { this.profesor = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        
        #endregion

        #region Indizadores públicos

        public Jornada this[int i]
        {
            get { return this.Jornadas[i]; }
            set { this.Jornadas[i] = value; }
        }
        
        #endregion

        #region Métodos públicos de instancia

        public bool Guardar(Universidad gim)
        {
            return true; //TODO Falta metodo guardar en Universidad
        }
        
        #endregion

        #region Métodos privados de clase 

        static private string MostrarDatos(Universidad gim)
        {
            StringBuilder salida = new StringBuilder();

            foreach (Jornada auxJornada in gim.Jornadas)
            {
                salida.AppendLine(auxJornada.ToString());
                salida.AppendLine("<----------------------------------------------------->");
            }

            return salida.ToString();
        }

        #endregion

        #region Sobreescritura de métodos

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region Sobrecarga de operadores

        #region Igualdad

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool encontrado = false;

            foreach (Alumno auxAlumno in g.Alumnos)
            {
                if (auxAlumno == a)
                {
                    encontrado = true;
                    break;
                }
            }

            return encontrado;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool encontrado = false;

            foreach (Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor == i)
                {
                    encontrado = true;
                    break;
                }
            }

            return encontrado;
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor auxReturn = null;

            foreach (Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor == clase)
                {
                    auxReturn = auxProfesor;
                    break;
                }
            }
                
            if (auxReturn is null)
                throw new SinProfesorException();

            return auxReturn;
        }

        #endregion

        #region Desigualdad

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor auxProfesor in g.Instructores)
                if (auxProfesor != clase)
                    return auxProfesor;

            throw new SinProfesorException(); //En el enunciado no aclara si no encuentra un distinto
                                              //que hacer. Por las dudas lanzamos la excepcion sin profesor.
        }

        #endregion

        #region Adición

        public static Universidad operator +(Universidad g, Alumno a)
        {

            foreach (Alumno auxAlumno in g.Alumnos)
            {
                if (auxAlumno == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }

            g.Alumnos.Add(a);

            return g;
        }


        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g.Instructores.Add(i);

            return g;
        }


        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada;
            Profesor auxProfesor;

            auxProfesor = (g == clase);

            nuevaJornada = new Jornada(clase, auxProfesor);

            foreach (Alumno auxAlumno in g.Alumnos)
                if (auxAlumno == clase)
                    nuevaJornada.Alumnos.Add(auxAlumno);

            g.Jornadas.Add(nuevaJornada);

            return g;
        }

        #endregion

        #endregion
    }
}
