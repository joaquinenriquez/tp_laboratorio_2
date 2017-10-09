using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    //public class Snacks //No hereda de Producto
    public class Snacks : Producto
    {
        #region Propiedades

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        #endregion

        #region Constructores

        public Snacks(EMarca marca, string codigoDeBarras, ConsoleColor color)
            : base(codigoDeBarras, marca, color)
        {
        }

        #endregion

        #region Métodos de clase

        //public override sealed string Mostrar() //No se puede cambiar el modificador de acceso de la clase base
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            //sb.AppendLine(base);
            sb.AppendLine(base.Mostrar());
            //sb.AppendLine("CALORIAS : {0}", this.CantidadCalorias); //AppendLine no permite modificadores de formato
            sb.AppendFormat("CALORIAS: {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            //return sb; //El método tiene que devolver string
            return sb.ToString();
        }

        #endregion
    }
}
