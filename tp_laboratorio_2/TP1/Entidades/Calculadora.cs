using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Calculadora
    {
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
