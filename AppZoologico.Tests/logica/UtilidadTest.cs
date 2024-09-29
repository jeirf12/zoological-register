namespace AppZoologico.Tests.logica 
{
    using global::AppZoologico.logica;

    public class UtilidadTest
    {

        private readonly Zoologico[] Zoologicos = new Zoologico[] 
        {
            new(1, "cali", "cerrado"),
        };

        private readonly Animal[] Animales = new Animal[]
        {
            new(1, "zorro", "Peru", 1.68),
        };

        [Fact]
        public void CrearClase_Zoologico_OK()
        {
            var palabras = new[] { "1", "cali", "abierto" };
            var resultado = Utilidad.CrearClase(palabras);
            Assert.NotNull(resultado);
            Assert.IsType<Zoologico>(resultado);
        }

        [Fact]
        public void CrearClase_Animal_OK()
        {
            var palabras = new[] { "1", "zorro", "Peru", "1.68" };
            var resultado = Utilidad.CrearClase(palabras);
            Assert.NotNull(resultado);
            Assert.IsType<Animal>(resultado);
        }

        [Fact]
        public void VerificarUnicidad_IdZoologicoUnico_OK()
        {
            var zoologico = new Zoologico(10, "cali", "abierto");
            var resultado = Utilidad.VerificarUnicidad(this.Zoologicos, zoologico.Nit);
            Assert.True(resultado);
        }

        [Fact]
        public void VerificarUnicidad_IdAnimalUnico_OK()
        {
            var animal = new Animal(10, "zorro", "Peru", 1.68);
            var resultado = Utilidad.VerificarUnicidad(this.Animales, animal.Codigo);
            Assert.True(resultado);
        }

        [Fact]
        public void ContarValoresNulos_Valido_OK()
        {
            var palabras = new[] { null, "zorro", null, "1.68" };
            var resultado = Utilidad.ObtenerTamanioSinContarValoresNulos(palabras);
            Assert.Equal(2, resultado);
        }

        [Theory]
        [InlineData(123, 123)]
        [InlineData(321, 321)]
        public void CompararIgualdad_NumerosIguales_OK(int primeroNumero, int segundoNumero)
        {
            var resultado = Utilidad.CompararIgualdad(primeroNumero, segundoNumero);
            Assert.True(resultado);
        }

        [Theory]
        [InlineData(321, 123)]
        [InlineData(123, 321)]
        public void CompararIgualdad_NumerosDiferentes_OK(int primeroNumero, int segundoNumero)
        {
            var resultado = Utilidad.CompararIgualdad(primeroNumero, segundoNumero);
            Assert.False(resultado);
        }

        [Theory]
        [InlineData("aehor12")]
        [InlineData("1.2eh")]
        public void EsNumerico_NumeroInvalido_OK(string numero)
        {
            var resultado = Utilidad.EsNumerico(numero);
            Assert.False(resultado);
        }

        [Theory]
        [InlineData("12")]
        [InlineData("1.2")]
        public void EsNumerico_NumeroValido_OK(string numero)
        {
            var resultado = Utilidad.EsNumerico(numero);
            Assert.True(resultado);
        }
    }
}