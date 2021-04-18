using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    static class Calculadora
    {
        /// <summary>
        /// La función operar recibe dos parámetros de tipo Numero, y un string. Primero se intenta convertir el operador a
        /// char con try, en el caso que no se pueda, se catchea la exception para que el programa no termine, y se retorna
        /// MaxValue. A continuación, se valida el operador recibido. En caso que el mismo haya retornado "+", se utiliza como
        /// suma. De acuerdo al operador, se realiza la sobrecarga necesaria para que el resultado sea acorde al operador uti-
        /// lizado.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            char auxOperador;
            double ret = 0;

            try
            { 
                auxOperador = Convert.ToChar(operador);
            }
            catch(Exception)
            {
                return double.MaxValue;
            }

            operador = ValidarOperador(auxOperador);

            if (operador == "0" || operador == "+")
            {
                ret = num1 + num2;
            }
            else if (operador == "1")
            {
                ret = num1 - num2;
            }
            else if (operador == "2")
            {
                ret = num1 * num2; 
            }
            else if (operador == "3")
            {
                ret = num1 / num2;
            }

            return ret;
        }

        /// <summary>
        /// ValidarOperador recibe un char, y verifica si este es +, -, *, ó /, dándole un ID de 0, 1, 2, y 3 respectivamente
        /// a cada uno.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(char operador)
        {
            string ret;
            string aux = Convert.ToString(operador);
            if(String.Compare(aux, "+") == 0)
            {
                ret = "0";
            }
            else if(String.Compare(aux, "-") == 0)
            {
                ret = "1";
            }
            else if(String.Compare(aux, "*") == 0)
            {
                ret = "2";
            }
            else if(String.Compare(aux, "/") == 0)
            {
                ret = "3";
            }
            else
            {
                ret = "+";
            }

            return ret;
        }
    }
}
