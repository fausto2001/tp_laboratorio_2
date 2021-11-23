using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La interfaz IAeronave indica que toda aeronave debe tener una marca, modelo, velocidad maxima, altura maxima, peso, largo,
    /// ancho, y año de creación. Además, tiene una función Mostrar para poder leer todos los datos de una aeronave dada.
    /// </summary>
    interface IAeronave
    {
        string Marca { get; }
        string Modelo { get; }
        int VelocidadMaxima { get; }
        int AlturaMaxima { get; }
        float Peso { get; }
        float Largo { get; }
        float Ancho { get; }
        int Anio { get; }

        string Mostrar();
    }
}
