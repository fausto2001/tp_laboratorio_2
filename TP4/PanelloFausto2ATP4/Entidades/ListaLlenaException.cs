using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Exception para la clase genérica Lista, que contiene el mensaje "No hay mas lugar en la lista" cuando se crea.
    public class ListaLlenaException : Exception
    {
        private static string message;
        public ListaLlenaException()
        {
            ListaLlenaException.message = "No hay mas lugar en la lista.";
        }
    }
}
