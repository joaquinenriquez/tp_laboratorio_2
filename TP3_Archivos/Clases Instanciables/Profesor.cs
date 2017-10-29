using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        #region Atributos privados

        Queue<Universidad.EClases> clasesDelDia = new Queue<Universidad.EClases>();
        static Random random;

        #endregion

        #region Constructores

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.randomClase();
            this.randomClase();
        }

        private Profesor()
        { }
        
        #endregion

        #region Sobreescritura de métodos

        protected override string MostrarDatos()
        {
            StringBuilder salida = new StringBuilder(base.MostrarDatos());

            salida.Append(this.ParticiparEnClase());

            return salida.ToString();
        }


        protected override string ParticiparEnClase()
        {
            StringBuilder salida = new StringBuilder("CLASES DEL DIA: ");

            salida.Append(Environment.NewLine);
            foreach (Universidad.EClases clase in this.clasesDelDia)
                salida.AppendLine(clase.ToString());

            return salida.ToString();
        }


        public override string ToString()
        {
            return this.MostrarDatos();
        }


        #endregion

        #region Sobrecarga de operadores

        #region Igualdad

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool auxReturn = false;

            foreach (Universidad.EClases auxClase in i.clasesDelDia)
            {
                if (auxClase == clase)
                    auxReturn = true;
            }

            return auxReturn;
        }

        #endregion

        #region Desigualdad

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        
        #endregion

        #region Métodos privados

        private void randomClase()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0,3));
        }

        #endregion

        #endregion
    }
}
