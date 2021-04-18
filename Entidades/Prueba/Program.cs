using System;

namespace Prueba
{
    class Program
    {
        public static string DecimalBinario2(double numero)
        {
            string result = "";

            int n = Convert.ToInt32(Math.Abs(numero));

            result = Convert.ToString(n, toBase: 2);

            return result;
        }
        public static string DecimalBinario(double numero)
        {
            string result = "Valor inválido";
            string auxResult = "";
            int pos = 0;
            bool conf = false;
            bool end = false;
            double exp = 0;
            double maxPos = 0;

            while(!conf)
            {
                end = false;
                while(!end)
                {
                    if(Math.Pow(2, exp) > numero)
                    {
                        maxPos = exp - 1;
                        end = true;
                    }
                    else
                    {
                        exp++;
                    }
                }
                if(maxPos != -1)
                {
                    auxResult += "1";
                }
            }
            


            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

           string binario = DecimalBinario2(23);

            Console.WriteLine("Binario: {0}", binario);
        }
    }
}
