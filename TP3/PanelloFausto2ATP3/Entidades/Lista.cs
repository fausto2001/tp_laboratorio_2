using System;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Entidades
{
    /// <summary>
    /// Clase lista, que depende de la interfaz ILista, que indica que obligatoriamente debe haber un Agregar, Remover, y getIndice.
    /// Esta lista es una clase completamente genérica, y se puede utilizar para cualquier tipo de dato.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Lista<T> : ILista<T>
        where T : new()
    {
        private int capacidad;
        private List<T> elementos;

        public int Capacidad
        {
            get { return this.capacidad; }
            set { this.capacidad = value; }
        }

        public List<T> Elementos
        {
            get { return this.elementos; }
            set { this.elementos = value; }
        }

        /// <summary>
        /// Constructor necesario para poder realizar serialización de XML.
        /// </summary>
        public Lista() { }

        public Lista(int capacidad)
        {
            this.capacidad = capacidad;
            this.elementos = new List<T>();
        }

        /// <summary>
        /// Función agregar que llama a la sobrecarga del operador +
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Agregar(T a)
        {
            return this + a;
        }

        /// <summary>
        /// Función remover llama a la sobrecarga del operador -
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Remover(T a)
        {
            return this - a;
        }

        /// <summary>
        /// Función modificar recibe un índice, y retorna false si es un índice incorrecto. Sino, reemplaza el elemento de la lista
        /// que tiene el índice indicado por la variable a.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Modificar(int index, T a)
        {
            if (index >= 0 && index <= elementos.Count)
            {
                this.elementos[index] = a;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sobrecarga de - verifica que el índice de la variable dadaexista a través de la variable GetIndice, y remueve la misma
        /// a traves del método Remove.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator -(Lista<T> l, T a)
        {
            int aux = l.GetIndice(a);
            if (aux != -1)
            {
                l.elementos.Remove(a);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sobrecarga de + verifica que el elemento recibido no exista ya en la lista, y la capacidad máxima no sea menor a la
        /// cantidad de elementos que hay, y lo agrega si es así.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator +(Lista<T> l, T a)
        {
            if (l.capacidad > l.elementos.Count)
            {
                if (l.elementos.Contains(a))
                {
                    return false;
                }
                else
                {
                    l.elementos.Add(a);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// GetIndice llama a la función IndexOf para poder obtener la variable en el índice recibido.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int GetIndice(T a)
        {
            return elementos.IndexOf(a);
        }

        /// <summary>
        /// Sobrecarga de ToString indica la capacidad máxima de la lista, y luego llama al ToString de cada elemento que haya en la
        /// lista genérica.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad maxima: " + this.capacidad);
            sb.AppendLine("");
            sb.AppendLine("Listado de elementos:");
            sb.AppendLine("");
            foreach (T a in this.elementos)
            {
                sb.Append(a.ToString());
                sb.AppendLine(" ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// La función Save serializa los datos de la lista en un archivo XML, y los escribe en el path recibido. Si no funciona,
        /// catchea la excepción.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public string Save(string path, Lista<T> lista)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Lista<T>));
                    ser.Serialize(writer, lista);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }

        /// <summary>
        /// La función Load crea una lista con una capacidad recibida, lee los datos de un archivo dado como variable en path,
        /// verifica que la extensión sea .XML, e intenta hacer la desserialización. Si no funciona, catchea una excepción y
        /// devuelve un mensaje de error.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="capacidad"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public string Load(string path, int capacidad, out Lista<T> lista)
        {
            lista = new Lista<T>(capacidad);
            try
            {
                using (XmlTextReader reader = new XmlTextReader(@path))
                {
                    if (path.Contains(".xml"))
                    {
                        XmlSerializer ser = new XmlSerializer((typeof(Lista<T>)));
                        lista = (Lista<T>)ser.Deserialize(reader);
                    }
                    else
                    {
                        return "Error";
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }
    }
}
