using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaWeb.API.Model
{
    [Table("contato")]
    public class Contato
    {
        [Column("id_contato")]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }
        public List<Telefone> telefones { get; set; }
    }
}
