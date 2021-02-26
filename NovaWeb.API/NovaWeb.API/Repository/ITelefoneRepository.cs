using NovaWeb.API.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Repository
{
    public interface ITelefoneRepository
    {
        Telefone Create(Telefone model);
        Telefone FindById(long id);
        List<Telefone> FindAll();
        Telefone Update(Telefone model);
        void Delete(long id);
        bool Exists(long id);
        int FindLastId();
    }
}
