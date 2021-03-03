using NovaWeb.Model;
using System.Collections.Generic;
using Xunit;

namespace NovaWeb.Test
{
    public class ContatoTest
    {
        [Fact]
        public void InstanciandoContato()
        {
            List<Telefone> telefones = new List<Telefone>
            {
                new Telefone
                {
                    ContatoId = 1,
                    Numero = "34216950",
                    TelefoneId = 1
                },
                new Telefone
                {
                    ContatoId = 1,
                    Numero = "998064823",
                    TelefoneId = 2
                }
            };

            var ContatoEsperado = new {
                ContatoId = 1,
                Email = "walterli.valadares@outlook.com",
                FirstName = "Walterli",
                LastName = "Valadares Junior"
            };

            var Contato = new Contato(ContatoEsperado.ContatoId, 
                                      ContatoEsperado.Email, 
                                      ContatoEsperado.FirstName,
                                      ContatoEsperado.LastName,
                                      telefones);

            Assert.NotNull(Contato);
        }
    }
}
