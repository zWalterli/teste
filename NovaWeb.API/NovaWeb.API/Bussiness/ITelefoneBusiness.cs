using NovaWeb.Model;
using System.Collections.Generic;

namespace NovaWeb.API.Bussiness
{
    public interface ITelefoneBusiness
    {
        Telefone Create(Telefone model);
        Telefone FindById(long idTelefone, long idContato);
        List<Telefone> FindAll();
        List<Telefone> GetAllTelefonesByIdContato(int id);
        Telefone Update(Telefone model);
        bool Delete(long idTelefone, long idContato);
        bool DeleteTodosTelefonesDoContato(int IdContato);
    }
}
