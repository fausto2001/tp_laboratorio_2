using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Incluyo los Xml de las clases hijas de Aeronave.
    /// </summary>
    [XmlInclude(typeof(Helicoptero))]
    [XmlInclude(typeof(Avion))]
    [XmlInclude(typeof(Globo))]

    public class Aeronave : IAeronave, IEquatable<Aeronave> //Utilizo la interfaz IEquatable para poder hacer funcionar el Contains().
    {
        //Variables indicadas en la interfaz.
        protected string marca;
        protected string modelo;
        protected int velocidadMaxima;
        protected int alturaMaxima;
        protected float peso;
        protected float largo;
        protected float ancho;
        protected int anio;

        /// <summary>
        /// Constructor vacío para la serialización del XML.
        /// </summary>
        public Aeronave() { }

        /// <summary>
        /// Constructor para crear una aeronave con todos los parámetros.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="velocidadMaxima"></param>
        /// <param name="alturaMaxima"></param>
        /// <param name="peso"></param>
        /// <param name="largo"></param>
        /// <param name="ancho"></param>
        /// <param name="anio"></param>
        public Aeronave(string marca, string modelo, int velocidadMaxima, int alturaMaxima,
            float peso, float largo, float ancho, int anio)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.velocidadMaxima = velocidadMaxima;
            this.alturaMaxima = alturaMaxima;
            this.peso = peso;
            this.largo = largo;
            this.ancho = ancho;
            this.anio = anio;
        }

        //Getters y setters en todas las variables de aeronave.
        public string Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        public string Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        public int VelocidadMaxima
        {
            get { return this.velocidadMaxima; }
            set { this.velocidadMaxima = value; }
        }

        public int AlturaMaxima
        {
            get { return this.alturaMaxima; }
            set { this.alturaMaxima = value; }
        }

        public float Peso
        {
            get { return this.peso; }
            set { this.peso = value; }
        }

        public float Largo
        {
            get { return this.largo; }
            set { this.largo = value; }
        }

        public float Ancho
        {
            get { return this.ancho; }
            set { this.ancho = value; }
        }

        public int Anio
        {
            get { return this.anio; }
            set { this.anio = value; }
        }

        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Sobrecarga == en la que si la marca, modelo, y año de fabricación de dos aeronaves dadas son iguales, entonces 
        /// cuentan como iguales.
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        public static bool operator ==(Aeronave a1, Aeronave a2)
        {
            bool ret = false;

            if (a1.marca == a2.marca && a1.modelo == a2.modelo && a1.anio == a2.anio)
            {
                ret = true;
            }

            return ret;
        }

        public static bool operator !=(Aeronave a1, Aeronave a2)
        {
            return !(a1 == a2);
        }

        /// <summary>
        /// Equals de la clase aeronave, que llama a la sobrecarga de ==.
        /// </summary>
        /// <param name="a1"></param>
        /// <returns></returns>
        public bool Equals(Aeronave a1)
        {
            return (this == a1);
        }

        /// <summary>
        /// Sobrecarga de string donde creo un stringbuilder que muestre en consola todas las caracteristicas
        /// que deberia tener una aeronave genérica.
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator string(Aeronave a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----------------------");
            sb.AppendLine("Marca: " + a.marca);
            sb.AppendLine("Modelo: " + a.modelo);
            sb.AppendLine("Velocidad maxima: " + a.velocidadMaxima + " km/h");
            sb.AppendLine("Altura maxima: " + a.alturaMaxima + " ft. (pies)");
            sb.AppendLine("Peso: " + a.peso + " kg");
            sb.AppendLine("Largo: " + a.largo + "m.");
            sb.AppendLine("Año: " + a.anio);

            return sb.ToString();
        }

        /// <summary>
        /// Función Descripcion que utilizo para escribir solamente los datos más básicos de una aeronave, y poder eventualmente
        /// tener una lista más comprimida de todas las aeronaves.
        /// </summary>
        /// <returns></returns>
        public virtual string Descripcion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.marca + " " + this.modelo + " - " + this.anio);

            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga de ToString que llama a la función Mostrar.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}

