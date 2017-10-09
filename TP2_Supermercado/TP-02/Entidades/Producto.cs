using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    //public sealed class Producto //La clase estaba declarada como sellada en lugar de abstacta
    public abstract class Producto
    {
        #region Enumerados

        //enum EMarca   //En el diagrama de clase aparece como publico.
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        #endregion

        #region Atributos

        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        #endregion

        #region Propiedades

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>

        //abstract short CantidadCalorias { get; set; } //Los miembros abstractos no pueden ser privados
        //protected abstract short CantidadCalorias { get; set; } //En el diagrama de clases aparece como solo lectura
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>

        #endregion

        #region Constructores

        //Faltaba el constructor que si aparece en el diagrama de clases
        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this._codigoDeBarras = codigoDeBarras;
            this._marca = marca;
            this._colorPrimarioEmpaque = color;
        }

        #endregion

        #region Métodos de instancia

        //sealed string Mostrar() //No puede estar sellado porque las clases derivadas lo sobrescriben
        public virtual string Mostrar()
        {
            //return this; //No esta definida la conversion implicita a string
            return (string)this;
        }

        #endregion

        #region Sobrecarga de operadores

        //private static explicit operator string(Producto p) //No puede ser private y static
        public static explicit operator string (Producto p) 
        {
            StringBuilder sb = new StringBuilder();

            //AppendLine no soporta modificadores de formato.
            //sb.AppendLine("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            //sb.AppendLine("MARCA          : {0}\r\n", p._marca.ToString());
            //sb.AppendLine("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());


            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            //return (v1._codigoDeBarras == v2._codigoDeBarras); //Esta devolviendo lo mismo que ==

            return !(v1._codigoDeBarras == v2._codigoDeBarras);
        }

        #endregion
    }
}
