using NovaWeb.API.Model;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace NovaWeb.API.Bussiness.Implementations
{
    public class TelefoneBusinessImplementation : ITelefoneBusiness
    {
        private readonly ITelefoneRepository _repository;

        public TelefoneBusinessImplementation(ITelefoneRepository repository)
        {
            _repository = repository;
        }

        public List<Telefone> GetAllTelefonesByIdContato(int id)
        {
            return _repository.GetAllTelefonesByIdContato(id);
        }

        public Telefone Create(Telefone model)
        {
            return _repository.Create(model);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Telefone> FindAll()
        {
            return _repository.FindAll();
        }

        public Telefone FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Telefone Update(Telefone model)
        {
            return _repository.Update(model);
        }
    }
}
