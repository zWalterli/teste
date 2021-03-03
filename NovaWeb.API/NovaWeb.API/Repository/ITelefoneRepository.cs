using NovaWeb.Model;
using System.Collections.Generic;

namespace NovaWeb.API.Repository
{
    public interface ITelefoneRepository
    {
        Telefone Create(Telefone model);
        Telefone FindById(long idTelefone, long idContato);
        List<Telefone> FindAll();
        Telefone Update(Telefone model);
        List<Telefone> GetAllTelefonesByIdContato(int id);
        bool Delete(long IdTelefone, long IdContato);
        int FindLastIdTelefone();
        bool DeleteTodosTelefonesDoContato(int IdContato);
    }
}
