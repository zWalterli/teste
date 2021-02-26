using System.ComponentModel.DataAnnotations.Schema;

namespace NovaWeb.API.Model
{
    [Table("telefone")]
    public class Telefone
    {
        [Column("id_telefone")]
        public int Id { get; set; }

        [Column("id_contato")]
        public int IdContato { get; set; }

        [Column("contato")]
        public string numero { get; set; }

        public Contato contato { get; set; }

        public Telefone()
        {
            Contato contato = new Contato();
        }
    }
}