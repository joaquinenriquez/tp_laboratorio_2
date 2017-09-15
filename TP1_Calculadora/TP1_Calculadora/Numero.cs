using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Calculadora
{
    class Numero
    {

        #region Atributos
        //Atributo utilizado para almacenar el valor del numero
        private double numero;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto. Inicializa el valor del atributo numero en 0
        /// </summary>
        public Numero ()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un string lo valida y lo utiliza para inicializar 
        /// el artributo numero
        /// </summary>
        /// <param name="numero">String a ser validado</param>
        public Numero (string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Constructor que recibe un double y lo utiliza para inicializar el atributo numero
        /// </summary>
        /// <param name="numero">Valor double utilizado para inicializar el atributo numero</param>
        public Numero (double numero)
        {
            this.numero = numero;
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Realiza la validación de un double a partir de un string
        /// en caso de que la validación no se logre se devolvera 0
        /// </summary>
        /// <param name="numeroString">Cadena que se intentara validar como double</param>
        /// <returns>Valor obtenerido tras la validación del double. En caso de 
        /// no poder validar se devolvera 0</returns>
        private double validarNumero(string numeroString)
        {
            double auxReturn = 0;

            double.TryParse(numeroString, out auxReturn);

            return auxReturn;
        }


        /// <summary>
        /// Asigna el el atributo numero a partir de un string que se validara
        /// como double
        /// </summary>
        /// <param name="numero">String que sera validado y luego asignado al atriburo
        /// numero</param>
        private void setNumero(string numero)
        {
            this.numero = this.validarNumero(numero);
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Devuelve el valor del atributo numero
        /// </summary>
        /// <returns>Valor double almacenado en el atributo numero</returns>
        public double getNumero()
        {
            return this.numero;
        }

        #endregion

    }
}
