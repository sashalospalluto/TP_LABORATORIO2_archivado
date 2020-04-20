using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
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
