using NovaWeb.API.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Repository
{
    public interface IContatoRepository
    {
        Contato Create(Contato model);
        Contato FindById(long id);
        List<Contato> FindAll();
        Contato Update(Contato model);
        void Delete(long id);
        bool Exists(long id);
        int FindLastIdContato();
    }
}
