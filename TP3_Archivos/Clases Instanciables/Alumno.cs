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

        public enum EEstadoCuenta {AlDia, Deudor, Becado }
        
        #endregion

        #region Atributos privados

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        public Alumno()
        {
        }


        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }


        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Sobreescritura de métodos

        protected override string MostrarDatos()
        {
            StringBuilder salida = new StringBuilder(base.MostrarDatos());

            salida.Append(Environment.NewLine);
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
                salida.AppendFormat("ESTADO DE CUENTA: {0}", "Cuota al día");
            else
                salida.AppendFormat("ESTADO DE CUENTA: {0}", this.estadoCuenta);

            salida.Append(Environment.NewLine);
            salida.AppendFormat("TOMA CLASES DE {0}", this.claseQueToma);

            return salida.ToString();
        }


        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Implementación de métodos

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this.claseQueToma.ToString();
        }

        #endregion

        #region Sobrecarga de operadores
        
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }

        #endregion
    }
}
