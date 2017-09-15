using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Calculadora
{
    class Calculadora
    {
        #region Métodos de clase

        /// <summary>
        /// Realiza la operacion matematica entre dos operando de la clase
        /// Numero y devuelve el resultado como coma flotante de doble precisión
        /// En el caso de la división por cero retorna 0
        /// </summary>
        /// <param name="numero1">Usado como primer operando</param>
        /// <param name="numero2">Usado como segundo operando</param>
        /// <param name="operador">Usado como operador</param>
        /// <returns>Resultado de la operación como tipo double 
        /// (o cero en caso de division no valida)</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            double auxNumero1 = numero1.getNumero();
            double auxNumero2 = numero2.getNumero();

            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = auxNumero1 + auxNumero2;
                    break;
                case "-":
                    resultado = auxNumero1 - auxNumero2;
                    break;
                case "*":
                    resultado = auxNumero1 * auxNumero2;
                    break;
                case "/":
                    if (auxNumero2 != 0)
                        resultado = auxNumero1 / auxNumero2;
                    else
                        resultado = 0;
                    break;
            }

            return resultado;
        }


        /// <summary>
        /// Valida que el operador se encuentre entre los permitidos
        /// (+ ; - ; * ; /) de lo contrario devuelve el operador '+'
        /// </summary>
        /// <param name="operador">Usado como operador</param>
        /// <returns>En caso de que el operador es válido, devuelve el mismo
        /// caso contrario devuelve '+'</returns>
        public static string ValidarOperador (string operador)
        {
            switch (operador)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    break;
                default:
                    operador = "+";
                    break;
            }

            return operador;
        }
#endregion
    }
}
