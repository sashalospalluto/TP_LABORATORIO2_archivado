using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// metodo que realiza la operacion aritmetica recibida en el parametro operador
        /// </summary>
        /// <param name="num1"> valor recibido del tipo Numero</param>
        /// <param name="num2"> valor recibido del tipo Numero</param>
        /// <param name="operador"> valor que contiene la operacion aritmetica que se va a realizar</param>
        /// <returns>Devuelve el resultado de la operacion realizada</returns>
        public static double Operar (Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "-":
                    resultado = num1 - num2 ;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                case "/":
                    resultado = num1 / num2;                    
                    break;
                    
                default:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el operador recibido sea + , - , * o /
        /// </summary>
        /// <param name="operador"> valor que contiene al operador a validar</param>
        /// <returns>Devuelve el valor verificado. Si no es un valor correcto, devuelve + </returns>
        private static string ValidarOperador (string operador)
        {
            string retorna;

            switch (operador)
            {              
                case "-":
                    retorna = "-";
                    break;

                case "*":
                    retorna = "*";
                    break;

                case "/":
                    retorna = "/";
                    break;

                default:
                    retorna = "+";
                    break;
            }

            return retorna;
        }


    }
}
