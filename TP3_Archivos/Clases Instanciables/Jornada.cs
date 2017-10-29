using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos privados

        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #endregion

        #region Propiedades públicas

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }


        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Constructores
        
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region Métodos de instancia públicos 

        public bool Guardar(Jornada jornada)
        {
            return true;
        }
        
        public string Leer()
        {
            return ""; //TODO METODO LEER
        }

        #endregion

        #region Sobrecarga de operadores

        #region Igualdad

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool encontrado = false;

            foreach (Alumno auxAlumno in j.Alumnos)
            {
                if (auxAlumno == a)
                {
                    encontrado = true;
                    break;
                }
            }

            return encontrado;
        }

        #endregion

        #region Desigualdad

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        #endregion

        #region Adición
        
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool encontrado = false;

            foreach (Alumno auxAlumno in j.Alumnos)
                if (auxAlumno == a)
                    encontrado = true;

            if (!encontrado)
                j.Alumnos.Add(a);

            return j;
        }
        
        #endregion

        #endregion

        #region Sobreescritura de métodos

        public override string ToString()
        {
            StringBuilder salida = new StringBuilder("JORNADA");

            salida.Append(Environment.NewLine);
            salida.AppendFormat("CLASE DE {0} POR: ", this.Clase.ToString());
            salida.Append(this.Instructor.ToString());

            salida.Append(Environment.NewLine);
            salida.AppendLine("ALUMNOS:");
            foreach (Alumno auxAlumno in this.Alumnos)
            {
                salida.AppendLine(auxAlumno.ToString());
                salida.Append(Environment.NewLine);
            }
   
            return salida.ToString();
        }

        #endregion
    }
}
