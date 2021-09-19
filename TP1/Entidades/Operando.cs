using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// ValidarOperando verifica que el numero obtenido pueda convertirse en un double.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {
            if (!double.TryParse(strNumero, out double ret))
            {
                ret = 0;
            }
            return ret;
        }

        private string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        /// <summary>
        /// Esta funcion verifica que el string este compuestos de 1 o 0.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            int length = binario.Length;
            int i = 0;
            bool ret = true;

            while (i < length && !ret)
            {
                if (binario[i] == '0' || binario[i] == '1')
                {
                    i++;
                }
                else
                {
                    ret = false;
                }
            }

            return ret;
        }

        /// <summary>
        /// Esta funcion verifica que el numero dado sea un numero binario positivo y lo convierte a decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string ret = "";

            if (EsBinario(binario))
            {
                try
                {
                    ret = Convert.ToInt64(binario, 2).ToString();
                }
                catch(System.FormatException)
                {
                    ret = "Valor inválido";
                }
                catch(System.ArgumentException)
                {
                    ret = "No se admiten negativos";
                }
            }
            else
            {
                ret = "Valor inválido";
            }

            return ret;
        }

        /// <summary>
        /// Esta funcion verifica el numero, lo pasa a decimal con Math.Abs, y lo convierte a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string ret = "Valor inválido";

            if (numero >= 0)
            {
                int n = Convert.ToInt32(Math.Abs(numero));

                ret = Convert.ToString(n, toBase: 2);
            }

            return ret;
        }

        /// <summary>
        /// Esta funcion verifica el numero, lo pasa a decimal con Math.Abs, y lo convierte a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string ret = "Valor inválido";
            int aux = Convert.ToInt32(numero);

            if (aux >= 0)
            {
                int n = Math.Abs(aux);
                ret = Convert.ToString(n, toBase: 2);
            }

            return ret;
        }

        /// <summary>
        /// La sobrecargas de operadores hacen la cuenta debida con cada numero de acuerdo al operador utilizado. En el caso
        /// de que sea una división por 0, la sobrecarga retorna MinValue.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            double ret;

            if (n2.numero == 0)
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
