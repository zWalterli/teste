using System.ComponentModel.DataAnnotations.Schema;

namespace NovaWeb.API.Model
{
    public class Telefone
    {
        public int TelefoneId { get; set; }
        public int ContatoId { get; set; }
        public string Numero { get; set; }
    }
}