using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        #region Enumerados

        public enum ETipo { Entera, Descremada }
        ETipo _tipo;

        #endregion

        #region Propiedades

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }


        #endregion

        #region Constructores

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor color)
            : base(codigoDeBarras, marca, color)
        {
            _tipo = ETipo.Entera;
        }
        
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor color, ETipo tipo)
            :base(codigoDeBarras, marca, color)
        {
            this._tipo = tipo;
        }

        #endregion

        #region Métodos de instancia

        //public override sealed string Mostrar() //No se puede cambiar el modificador de acceso de la clase base
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            //sb.AppendLine(this);
            sb.AppendLine(base.Mostrar());
            //sb.AppendLine("CALORIAS : {0}", this.CantidadCalorias); //AppendLine no permite modificadores de formato
            sb.AppendFormat("CALORIAS: {0}\n\r", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            //return sb; //El método devuelve un string no un StringBuilder
            return sb.ToString();
        }

        #endregion
    }
}
