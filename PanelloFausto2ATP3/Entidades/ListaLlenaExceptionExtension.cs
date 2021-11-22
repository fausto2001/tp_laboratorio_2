using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Metodo de extension de ListaLlenaException que contiene una función Informar.
    public static class ListaLlenaExceptionExtension
    {
        public static string Informar(this ListaLlenaException ex)
        {
            return "No hay mas lugar en la lista.";
        }
    }
}
