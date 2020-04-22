using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor que inicializa en 0 el atributo
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Recibe por parametro un valor de tipo double
        /// </summary>
        /// <param name="numero">Numero recibido por parametro</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Recibe por parametro un valor de tipo string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Le asigna al atributo el valor ya validado
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Convierte el valor recibido a decimal
        /// </summary>
        /// <param name="binario"> se recibe un valor del tipo string </param>
        /// <returns> Devuelve 'valor invalido' si el numero recibido no es binario, caso contrario devuelve el valor convertido a decimal</returns>
        public string BinarioDecimal(string binario)
        {
            string aux;
            int numeroSolo;
            int nroDecimal = 0;
            int contador = binario.Length;
            string esUnNumeroBinario = "";

            for (int i = 0; i < contador; i++)
            {
                aux = binario.Substring(binario.Length - 1, 1); //tomo solo el ultimo caracter del string
                int.TryParse(aux, out numeroSolo); //lo convierto a entero 

                if (numeroSolo == 1 || numeroSolo == 0)
                {
                    if (numeroSolo == 1) // solo si es 1 lo elevo y lo sumo
                    {
                        nroDecimal = (int)Math.Pow(2, i) + nroDecimal;
                    }
                }
                else
                {
                    esUnNumeroBinario = "Valor invalido";
                    break;
                }

                binario = binario.Remove(binario.Length - 1); //elimino el ultimo caracter del string
            }

            if (!(esUnNumeroBinario.Equals("Valor invalido")))
            {
                esUnNumeroBinario = nroDecimal.ToString();
            }

            return esUnNumeroBinario;
        }

        /// <summary>
        /// Convierte el valor recibido a binario
        /// </summary>
        /// <param name="numero"> se recibe un valor del tipo double</param>
        /// <returns>Devuelve 'valor invalido' si el numero recibido no es decima, caso contrario devuelve el valor convertido a binario</returns>
        public string DecimalBinario(double numero)
        {

            string binario = "";
            int numeroEntero;

            numeroEntero = (int)numero;

            while (numeroEntero > 1)
            {
                if (numeroEntero % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }

                numeroEntero = numeroEntero / 2;
            }

            binario = '1' + binario;

            return binario;
        }

        /// <summary>
        /// Convierte el valor recibido a binario
        /// </summary>
        /// <param name="numero"> se recibe un valor del tipo string</param>
        /// <returns>Devuelve 'valor invalido' si el numero recibido no es decimal, caso contrario devuelve el valor convertido a binario</returns>
        public string DecimalBinario(string numero)
        {
            double binario;

            double.TryParse(numero, out binario);

            return DecimalBinario(binario);
        }

        /// <summary>
        /// operador de clase que resta 2 numeros del tipo Numero
        /// </summary>
        /// <param name="n1">valor recibido del tipo Numero</param>
        /// <param name="n2">valor del tipo Numero</param>
        /// <returns>Devuelve la resta de ambos numeros</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }

        /// <summary>
        /// operador de clase que suma 2 numeros del tipo Numero
        /// </summary>
        /// <param name="n1">valor recibido del tipo Numero</param>
        /// <param name="n2">valor recibido del tipo Numero</param>
        /// <returns>Devuelve la suma de ambos numeros</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return (n1.numero + n2.numero);
        }

        /// <summary>
        /// operador de clase que multiplica 2 numeros del tipo Numero
        /// </summary>
        /// <param name="n1">valor recibido del tipo Numero</param>
        /// <param name="n2">valor recibido del tipo Numero</param>
        /// <returns>Devuelve la multiplicacion de ambos numeros</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }

        /// <summary>
        /// operador de clase que divide 2 numeros del tipo Numero
        /// </summary>
        /// <param name="n1">valor recibido del tipo Numero</param>
        /// <param name="n2">valor recibido del tipo Numero</param>
        /// <returns>Devuelve la division de ambos numeros. En caso de que el dividendo sea cero se devuelve el valor minimo (double.MinValue)</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double ret = 0;

            if (n2.numero > 0)
            {
                ret = (n1.numero / n2.numero);
            }
            else if (n2.numero == 0)
            {
                ret = double.MinValue;
            }

            return ret;
        }

        /// <summary>
        /// Valida que el numero recibido del tipo string sea un numero
        /// </summary>
        /// <param name="strNumero">valor recibido del tipo string</param>
        /// <returns>Devuelve 0 si el valor no es un numero, caso contrario devuelve el numero convertido al tipo doubel</returns>
        private double ValidarNumero(string strNumero)
        {
            double esUnNumero = 0;

            double.TryParse(strNumero, out esUnNumero);

            return esUnNumero;
        }

    }
}
