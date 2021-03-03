using System.Collections.Generic;

namespace NovaWeb.Model
{
    public class Contato
    {
        public Contato() { }
        public Contato(int _ContatoId, string _Email, string _FirstName, string _LastName, List<Telefone> _Telefones) 
        {
            ContatoId = _ContatoId;
            Email = _Email;
            FirstName = _FirstName;
            LastName = _LastName;
            Telefones = _Telefones;
        }

        public int ContatoId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Telefone> Telefones { get; set; }
    }
}
