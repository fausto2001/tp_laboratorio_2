using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase hija de aeronave.
    /// </summary>
    public class Globo : Aeronave
    {
        private int capacidadAire;
        private int pasajeros;

        //Constructor vacío para la serialización XML.
        public Globo() { }

        public int CapacidadAire
        {
            get { return capacidadAire; }
            set { this.capacidadAire = value; }
        }

        public int Pasajeros
        {
            get { return pasajeros; }
            set { this.pasajeros = value; }
        }

        /// <summary>
        /// Constructor que llama al base, y agrega las dos nuevas variables de globo.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="velocidadMaxima"></param>
        /// <param name="alturaMaxima"></param>
        /// <param name="peso"></param>
        /// <param name="largo"></param>
        /// <param name="ancho"></param>
        /// <param name="anio"></param>
        /// <param name="capacidadAire"></param>
        /// <param name="pasajeros"></param>
        public Globo(string marca, string modelo, int velocidadMaxima, int alturaMaxima,
            float peso, float largo, float ancho, int anio, int capacidadAire, int pasajeros) :
            base(marca, modelo, velocidadMaxima, alturaMaxima, peso, largo, ancho, anio)
        {
            this.capacidadAire = capacidadAire;
            this.pasajeros = pasajeros;
        }

        /// <summary>
        /// Sobrecarga de ToString que llama a la función Mostrar de la clase base, y agrega la capacidad de aire y cantidad de
        /// pasajeros.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine("Capacidad Aire: " + this.capacidadAire + " kg.");
            sb.AppendLine("Pasajeros: " + this.pasajeros + " personas");
            sb.AppendLine("------------------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de == en la que se casteo ambas variables a Aeronave para que tenga la misma funcionalidad que la de la
        /// clase padre (polimorfismo).
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        public static bool operator ==(Globo g1, Globo g2)
        {
            return ((Aeronave)g1 == (Aeronave)g2);
        }

        public static bool operator !=(Globo g1, Globo g2)
        {
            return !(g1 == g2);
        }

        /// <summary>
        /// Sobreescritura de la función descripción en la que especifico qué tipo de aeronave es la que se está listando.
        /// </summary>
        /// <returns></returns>
        public override string Descripcion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GLOBO: " + base.Descripcion());
            return sb.ToString();
        }

    }
}
