using NovaWeb.API.Repository;
using NovaWeb.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NovaWeb.API.Bussiness.Implementations
{
    public class TelefoneBusinessImplementation : ITelefoneBusiness
    {
        private readonly ITelefoneRepository _repository;

        public TelefoneBusinessImplementation(ITelefoneRepository repository)
        {
            _repository = repository;
        }

        private static string ApenasNumeros(string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            return apenasDigitos.Replace(str, "");
        }

        public List<Telefone> GetAllTelefonesByIdContato(int id)
        {
            return _repository.GetAllTelefonesByIdContato(id);
        }

        public Telefone Create(Telefone model)
        {
            // Permitir apenas caracteres numéricos
            model.Numero = ApenasNumeros(model.Numero);
            return _repository.Create(model);
        }

        public bool Delete(long IdTelefone, long IdContato)
        {
            if (IdTelefone < 1 && IdContato < 1)
            {
                return false;
            }

            return _repository.Delete(IdTelefone, IdContato);
        }

        public List<Telefone> FindAll()
        {
            return _repository.FindAll();
        }

        public Telefone FindById(long IdTelefone, long IdContato)
        {
            if (IdTelefone < 1 && IdContato < 1)
            {
                return null;
            }
            return _repository.FindById(IdTelefone, IdContato);
        }

        public Telefone Update(Telefone model)
        {
            // Permitir apenas caracteres numéricos
            if (model.ContatoId == null || model.ContatoId < 0)
            {
                return null;
            }
            model.Numero = ApenasNumeros(model.Numero);
            return _repository.Update(model);
        }

        public bool DeleteTodosTelefonesDoContato(int IdContato)
        {
            return _repository.DeleteTodosTelefonesDoContato(IdContato);
        }
    }
}
