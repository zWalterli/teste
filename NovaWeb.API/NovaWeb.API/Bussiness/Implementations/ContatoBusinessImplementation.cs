using NovaWeb.API.Model;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace NovaWeb.API.Bussiness.Implementations
{
    public class ContatoBusinessImplementation : IContatoBusiness
    {
        private readonly IContatoRepository _repository;

        public ContatoBusinessImplementation(IContatoRepository repository)
        {
            _repository = repository;
        }

        public Contato Create(Contato model)
        {
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public List<Contato> FindAll()
        {
            return _repository.FindAll();
        }

        public Contato FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Contato Update(Contato model)
        {
            return _repository.Update(model);
        }
    }
}
