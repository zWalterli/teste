using NovaWeb.Model;
using System.Collections.Generic;
using Xunit;

namespace NovaWeb.Test
{
    public class TelefoneTest
    {
        [Fact]
        public void InstanciandoContato()
        {
            var TelefoneEsperado = new {
                TelefoneId = 1,
                ContatoId = 1,
                Numero = "998064823"
            };

            var Telefone = new Telefone(TelefoneEsperado.TelefoneId,
                                        TelefoneEsperado.ContatoId,
                                        TelefoneEsperado.Numero);

            Assert.NotNull(Telefone);
        }
    }
}
