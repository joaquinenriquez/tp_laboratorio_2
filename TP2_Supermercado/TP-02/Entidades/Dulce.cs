using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {
        #region Propiedades

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        //protected short CantidadCalorias // Para poder sobrescribir la propiedad abstract hace falta el modificador override
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

        #region Constructores

        //Agregamos el argumento codigodeBarras y sacamos el argumento Patente (no existe en el diagrama de clases) 
        //LLamamos el constructor de la clase padre 
        //public Dulce(EMarca marca, string patente, ConsoleColor color) 
        public Dulce (EMarca marca, string codigoDeBarras, ConsoleColor color):base(codigoDeBarras, marca, color)
        {
        }

        #endregion

        #region Métodos de instancia

        //private override sealed string Mostrar() // No se puede cambiar el modificador de acceso de la clase base (de protected a private)
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            //sb.AppendLine("CALORIAS : {0}", this.CantidadCalorias); //El método AppendLine no permite modificadores de formato
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            //return sb; //El método espera que se devuelva un string no stringbuilder.
            return sb.ToString();
        }

#endregion
    }
}
