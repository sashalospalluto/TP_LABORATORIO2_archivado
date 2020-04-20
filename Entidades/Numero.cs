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

        public Numero()
        {
            this.numero=0;
        }

        public Numero(double numero) : this()
        {

        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public string SetNumero 
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public string BinarioDecimal (string binario)
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
                
                if(numeroSolo==1 || numeroSolo==0)
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

            if(!(esUnNumeroBinario.Equals("Valor invalido")))
            {
                esUnNumeroBinario = nroDecimal.ToString();
            }

            return esUnNumeroBinario;
        }

        public string DecimalBinario (double numero)
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

        public string DecimalBinario(string numero)
        {
            double binario;

            double.TryParse(numero, out binario);                     

            return DecimalBinario(binario);
        }

        public static double operator - (Numero n1, Numero n2)
        {
            return (n1.numero-n2.numero);
        }

        public static double operator + (Numero n1, Numero n2)
        {
            return (n1.numero+n2.numero);
        }

        public static double operator * (Numero n1, Numero n2)
        {
            return (n1.numero*n2.numero);
        }

        public static double operator / (Numero n1, Numero n2)
        {
            double ret = 0;

            if(n2.numero > 0)
            {
                ret = (n1.numero / n2.numero);
            }
            else if (n2.numero==0)
            {
                ret = double.MinValue;
            }

            return ret;
        }

        private double ValidarNumero (string strNumero)
        {
            double esUnNumero = 0;

            double.TryParse(strNumero, out esUnNumero);
           
            return esUnNumero;
        }

    }
}
