using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

        public Numero()
        {
            numero = 0;
        }

        public Numero(string numero)
        {
            SetNumero = numero;
        }

        /// <summary>
        /// comprobará que el valor recibido sea numérico, y lo retornará en
        /// formato double. Caso contrario, retornará 0.
        /// Para esta funcion, usé la estructura de control "try" para intentar convertir el string a double,
        /// en el caso que no pueda y retorne una exception, uso la estructura "catch" para que el programa no
        /// finalice, y como result ya estaba igualado previamente a 0, se retorna el mismo.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double result = 0;
            try
            {
                result = Convert.ToDouble(strNumero);

            }
            catch (SystemException)
            {
                result = Double.MaxValue;
            }

            return result;
        }

        public string SetNumero
        {
            set 
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Verifica si el string recibido es un numero binario, chequeando si cada dígito vale 1 ó 0.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            bool result = true;
            int aux;

            if(Int32.TryParse(binario, out aux))
            {
                if (aux >= 0)
                {
                    int i = 0;
                    while (i < binario.Length && result)
                    {
                        if (binario[i] != '0' && binario[i] != '1')
                        {
                            result = false;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Convierte un número binario a decimal con la sobrecarga del Convert.ToInt(string, base), en el que se puede
        /// elegir desde qué base se convierte el número a decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string result = "Valor Inválido";

            if (EsBinario(binario))
            {
                result = Convert.ToString(Convert.ToInt32(binario, 2));
            }

            return result;
        }

        /// <summary>
        /// Verifica que el número recibido sea mayor a 0, y si lo es, devuelve el mismo en binario con la función
        /// Convert.ToString, que tiene una sobrecarga que indica Convert.ToString(int value, int toBase), en la que elijo
        /// base 2, para que quede binario. La función DecimalBinario tiene dos sobrecargas, como es indicado en el PDF del TP.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string result = "Valor inválido";

            if(numero >= 0)
            { 
                int n = Convert.ToInt32(Math.Abs(numero));

                result = Convert.ToString(n, toBase: 2);
            }

            return result;
        }

        public static string DecimalBinario(string numero)
        {
            string result = "Valor inválido";
            int aux = Convert.ToInt32(numero);

            if(aux >= 0)
            {
                int n = Math.Abs(aux);
                result = Convert.ToString(n, toBase: 2);
            }

            return result;
        }

        /// <summary>
        /// Todas las sobrecargas realizan las operaciones de Numero.numero. En caso en que numero == MaxValue, devuelve
        /// MaxValue, y en caso en que el divisor de la sobrecarga del "/" sea 0, devuelve MinValue.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        /// 

        public static double operator -(Numero n1, Numero n2)
        {
            double ret;
            if(n1.numero == Double.MaxValue || n2.numero == Double.MaxValue)
            {
                ret = double.MaxValue;
            }
            else
            { 
            ret = n1.numero - n2.numero;
            }
            return ret;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double ret;
            if (n1.numero == Double.MaxValue || n2.numero == Double.MaxValue)
            {
                ret = double.MaxValue;
            }
            else
            {
                ret = n1.numero + n2.numero;
            }
            return ret;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double ret;
            if (n1.numero == Double.MaxValue || n2.numero == Double.MaxValue)
            {
                ret = double.MaxValue;
            }
            else
            {
                ret = n1.numero * n2.numero;
            }
            return ret;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double ret;

            if (n1.numero == Double.MaxValue || n2.numero == Double.MaxValue)
            {
                ret = double.MaxValue;
            }
            else if (n2.numero == 0)
            {
                ret = double.MinValue;
            }
            else
            {
                ret = n1.numero / n2.numero;
            }

            return ret;
        }
    }
}