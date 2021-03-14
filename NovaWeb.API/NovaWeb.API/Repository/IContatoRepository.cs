using NovaWeb.Model;
using System.Collections.Generic;

namespace NovaWeb.API.Repository
{
    public interface IContatoRepository
    {
        Contato Create(Contato model);
        Contato FindById(long id);
        List<Contato> FindAll();
        Contato Update(Contato model);
        bool Delete(long id);
        int FindLastIdContato();
        List<Contato> FindByName(string firtsName, string lastName);
    }
}
