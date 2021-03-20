using NovaWeb.API.Util;
using NovaWeb.Model;
using System.Collections.Generic;

namespace NovaWeb.API.Bussiness
{
    public interface IContatoBusiness
    {
        Contato Create(Contato model);
        Contato FindById(long id);
        List<Contato> FindAll();
        Contato Update(Contato model);
        bool Delete(long id);
        List<Contato> FindByName(string firtsName, string lastName);
        PagedSearch<Contato> findWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
