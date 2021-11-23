using System;
using Entidades;

namespace ConsoleApp1
{
    class Test
    {
        static void Main(string[] args)
        {
            Aeronave a1 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);
            Aeronave a2 = new Aeronave("Cessna", "152", 204, 14000, 490, 14, 10, 1977);
            Aeronave a3 = new Aeronave("Diamond", "DA40", 216, 12250, 552, 13, 13, 1996);
            Aeronave a4 = new Aeronave("Diamond", "DA40", 216, 12250, 552, 13, 13, 1996);

            Lista<Aeronave> MiLista = new Lista<Aeronave>(5);

            MiLista.Agregar(a1);
            MiLista.Agregar(a2);
            MiLista.Agregar(a3);
            if(!MiLista.Agregar(a4))
            {
                Console.WriteLine("No se pudo agregar!");
            }

            Console.WriteLine(MiLista);

            MiLista.Save("Datos.xml", MiLista);

            MiLista.Remover(a1);
            MiLista.Remover(a2);
            if(!MiLista.Remover(a1))
            {
                Console.WriteLine("No se pudo remover!");
            }

            Console.WriteLine(MiLista);
        }
    }
}
