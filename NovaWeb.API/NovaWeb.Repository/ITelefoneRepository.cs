using NovaWeb.Model;
using System.Collections.Generic;

namespace NovaWeb.Repository
{
    public interface ITelefoneRepository
    {
        Telefone Create(Telefone model);
        Telefone FindById(long id);
        List<Telefone> FindAll();
        Telefone Update(Telefone model);
        List<Telefone> GetAllTelefonesByIdContato(int id);
        bool Delete(long id);
        int FindLastIdTelefone(int IdContato);
    }
}
