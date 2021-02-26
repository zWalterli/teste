using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaWeb.API.Model
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Telefone> Telefones { get; set; }
    }
}
