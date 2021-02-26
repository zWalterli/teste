using NovaWeb.API.Model;
using System.Collections.Generic;

namespace NovaWeb.API.Bussiness
{
    public interface IContatoBusiness
    {
        Contato Create(Contato model);
        Contato FindById(long id);
        List<Contato> FindAll();
        Contato Update(Contato model);
        void Delete(long id);
    }
}
