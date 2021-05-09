using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio //cambio este enum a public para que pueda funcionar la propiedad Tamanio
        {
            Chico, Mediano, Grande
        }
        EMarca marca;
        string chasis;
        ConsoleColor color;

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get;}

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CHASIS: " + p.chasis);
            sb.AppendLine("MARCA : " + p.marca);
            sb.AppendLine("COLOR : " + p.color);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (v1.chasis == v2.chasis)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            if(v1.chasis == v2.chasis)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Constructor de Vehiculo.
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="colour"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor colour)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = colour;
        }
    }
}
