using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz de una lista, donde toda lista va a poder permitir que se agreguen y se remuevan datos; para el remover también
    /// es necesario obtener el índice así que esa función también sería parte de la interfaz.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILista<T> where T : new()
    {
        bool Agregar(T a);
        bool Remover(T a);
        int GetIndice(T a);
    }
}
