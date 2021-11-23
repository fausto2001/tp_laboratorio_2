using System;
using Xunit;
using Entidades;

namespace UnitTest
{
    public class AeronaveTest
    {
        [Fact]
        public void VerificarIgualdadAeronaves_true()
        {
            Aeronave a1 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);
            Aeronave a2 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);

            bool rta = a1 == a2;

            Assert.True(rta);
        }

        [Fact]
        public void VerificarIgualdadAeronaves_false()
        {
            Aeronave a1 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);
            Aeronave a2 = new Aeronave("Cessna", "152", 204, 14000, 490, 14, 10, 1977);

            bool rta = a1 == a2;

            Assert.False(rta);
        }

        [Fact]

        public void VerificarAgregar_true()
        {
            Aeronave a1 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);
            Aeronave a2 = new Aeronave("Cessna", "152", 204, 14000, 490, 14, 10, 1977);
            Aeronave a3 = new Aeronave("Diamond", "DA40", 216, 12250, 552, 13, 13, 1996);

            Lista<Aeronave> MiLista = new Lista<Aeronave>(5);

            MiLista.Agregar(a1);
            MiLista.Agregar(a2);

            Assert.True(MiLista.Agregar(a3));
        }

        [Fact]
        public void VerificarAgregar_false()
        {
            Aeronave a1 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);
            Aeronave a2 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);
            Aeronave a3 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);

            Lista<Aeronave> MiLista = new Lista<Aeronave>(5);

            MiLista.Agregar(a1);
            MiLista.Agregar(a2);

            Assert.False(MiLista.Agregar(a3));
        }

        [Fact]
        public void VerificarRemover_true()
        {
            Aeronave a1 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);
            Aeronave a2 = new Aeronave("Cessna", "152", 204, 14000, 490, 14, 10, 1977);
            Aeronave a3 = new Aeronave("Diamond", "DA40", 216, 12250, 552, 13, 13, 1996);


            Lista<Aeronave> MiLista = new Lista<Aeronave>(4);

            MiLista.Agregar(a1);
            MiLista.Agregar(a2);
            MiLista.Agregar(a3);

            Assert.True(MiLista.Remover(a2));
        }

        [Fact]
        public void VerificarRemover_false()
        {
            Aeronave a1 = new Aeronave("Cessna", "172", 302, 18500, 757, 15, 11, 1955);
            Aeronave a2 = new Aeronave("Cessna", "152", 204, 14000, 490, 14, 10, 1977);
            Aeronave a3 = new Aeronave("Diamond", "DA40", 216, 12250, 552, 13, 13, 1996);


            Lista<Aeronave> MiLista = new Lista<Aeronave>(2);

            MiLista.Agregar(a1);
            MiLista.Agregar(a2);

            Assert.False(MiLista.Remover(a3));
        }
    }
}
