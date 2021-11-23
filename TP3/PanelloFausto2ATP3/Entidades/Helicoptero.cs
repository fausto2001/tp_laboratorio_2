using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Helicoptero : Aeronave
    {
        private int rotores;
        private EHelicoptero tipo;
        
        //Constructor vacío para la serialización XML.
        public Helicoptero() { }

        public int Rotores
        {
            get { return rotores; }
            set { this.rotores = value; }
        }

        public EHelicoptero Tipo
        {
            get { return tipo; }
            set { this.tipo = value; }
        }

        /// <summary>
        /// Constructor que llama al base, y agrega las dos nuevas variables de helicóptero.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="velocidadMaxima"></param>
        /// <param name="alturaMaxima"></param>
        /// <param name="peso"></param>
        /// <param name="largo"></param>
        /// <param name="ancho"></param>
        /// <param name="anio"></param>
        /// <param name="rotores"></param>
        /// <param name="tipo"></param>
        public Helicoptero(string marca, string modelo, int velocidadMaxima, int alturaMaxima,
            float peso, float largo, float ancho, int anio, int rotores, EHelicoptero tipo) :
            base(marca, modelo, velocidadMaxima, alturaMaxima, peso, largo, ancho, anio)
        {
            this.rotores = rotores;
            this.tipo = tipo;
        }

        /// <summary>
        /// Sobrecarga de ToString que llama a la función Mostrar de la clase base, y agrega los rotores y el tipo de helicóptero.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine("Rotores: " + this.rotores);
            sb.AppendLine("Tipo: " + this.tipo);
            sb.AppendLine("------------------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de == en la que se casteo ambas variables a Aeronave para que tenga la misma funcionalidad que la de la
        /// clase padre (polimorfismo).
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static bool operator ==(Helicoptero h1, Helicoptero h2)
        {
            return ((Aeronave)h1 == (Aeronave)h2);
        }

        public static bool operator !=(Helicoptero h1, Helicoptero h2)
        {
            return !(h1 == h2);
        }

        /// <summary>
        /// Sobreescritura de la función descripción en la que especifico qué tipo de aeronave es la que se está listando.
        /// </summary>
        /// <returns></returns>
        public override string Descripcion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("HELICOPTERO: " + base.Descripcion());
            return sb.ToString();
        }
    }
}
