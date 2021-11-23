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
    public class Avion : Aeronave
    {
        //Variables particulares de avión. Los enumerados están en el archivo ENums.cs.
        private EAvion tipo;
        private EMotores motor;

        //Constructor vacío para la serialización XML.
        public Avion() { }

        /// <summary>
        /// Constructor que llama al base, y agrega las dos nuevas variables de avión.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="velocidadMaxima"></param>
        /// <param name="alturaMaxima"></param>
        /// <param name="peso"></param>
        /// <param name="largo"></param>
        /// <param name="ancho"></param>
        /// <param name="anio"></param>
        /// <param name="tipo"></param>
        /// <param name="motor"></param>
        public Avion(string marca, string modelo, int velocidadMaxima, int alturaMaxima,
            float peso, float largo, float ancho, int anio, EAvion tipo, EMotores motor) :
            base(marca, modelo, velocidadMaxima, alturaMaxima, peso, largo, ancho, anio)
        {
            this.motor = motor;
            this.tipo = tipo;
        }

        public EMotores Motor
        {
            get { return motor; }
            set { this.motor = value; }
        }

        public EAvion Tipo
        {
            get { return tipo; }
            set { this.tipo = value; }
        }

        /// <summary>
        /// Sobrecarga de ToString que llama a la función Mostrar de la clase base, y agrega el motor y el tipo.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine("Motor: " + this.motor);
            sb.AppendLine("Tipo: " + this.tipo);
            sb.AppendLine("------------------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de == en la que se casteo ambas variables a Aeronave para que tenga la misma funcionalidad que la de la
        /// clase padre (polimorfismo).
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        public static bool operator ==(Avion a1, Avion a2)
        {
            return ((Aeronave)a1 == (Aeronave)a2);
        }

        public static bool operator !=(Avion a1, Avion a2)
        {
            return !(a1 == a2);
        }

        /// <summary>
        /// Sobreescritura de la función descripción en la que especifico qué tipo de aeronave es la que se está listando.
        /// </summary>
        /// <returns></returns>
        public override string Descripcion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("AVION: " + this.Tipo + ", " + base.Descripcion());
            return sb.ToString();
        }
    }
}

