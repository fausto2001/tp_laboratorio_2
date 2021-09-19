using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida operador, y luego hace la cuenta que debe de acuerdo al operador obtenido.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double ret = 0;
            ValidarOperador(operador);

            switch (operador)
            {
                case '+':
                    ret = num1 + num2;
                    break;
                case '-':
                    ret = num1 - num2;
                    break;
                case '*':
                    ret = num1 * num2;
                    break;
                case '/':
                    ret = num1 / num2;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Valida operador. Si no es ninguno correcto, utiliza '+'.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }

            return operador;
        }

    }
}
