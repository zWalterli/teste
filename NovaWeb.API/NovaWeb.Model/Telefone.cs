namespace NovaWeb.Model
{
    public class Telefone
    {
        public Telefone() { }
        public Telefone(int telefoneId, int contatoId, string Numero)
        {
            this.TelefoneId = telefoneId;
            this.ContatoId = contatoId;
            this.Numero = Numero;
        }

        public int TelefoneId { get; set; }
        public int ContatoId { get; set; }
        public string Numero { get; set; }
    }
}