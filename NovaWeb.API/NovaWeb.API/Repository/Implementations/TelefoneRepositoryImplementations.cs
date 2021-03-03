using NovaWeb.API.Context;
using NovaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NovaWeb.API.Repository.Implementations
{
    public class TelefoneRepositoryImplementations : ITelefoneRepository
    {
        private readonly NovaWebContext _context;

        public TelefoneRepositoryImplementations(NovaWebContext context)
        {
            _context = context;
        }

        public Telefone Create(Telefone model)
        {
            try
            {
                model.TelefoneId = FindLastIdTelefone();
                _context.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteTodosTelefonesDoContato(int idContato)
        {
            var result = FindAll().Where(t => t.ContatoId == idContato);
            if (result != null)
            {
                try
                {
                    foreach (var item in result)
                    {
                        _context.Telefones.Remove(item);
                    }
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }

        public List<Telefone> FindAll()
        {
            var result = _context.Telefones
                        .ToList();          
            return result;
        }

        public Telefone FindById(long idTelefone, long idContato)
        {
            return _context.Telefones
                    .SingleOrDefault(c => c.TelefoneId == idTelefone && c.ContatoId == idContato);
        }

        public Telefone Update(Telefone model)
        {
            var result = FindById(model.TelefoneId, model.ContatoId);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(model);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public List<Telefone> GetAllTelefonesByIdContato(int id)
        {
            return _context.Telefones.Where(t => t.ContatoId.Equals(id)).ToList();
        }

        public int FindLastIdTelefone()
        {
            var result = _context.Telefones
                        .ToList();
            return result.Count == 0 ? 1 : result[result.Count - 1].TelefoneId + 1;
        }

        public bool Delete(long IdTelefone, long IdContato)
        {
            var result = FindById(IdTelefone, IdContato);
            if (result != null)
            {
                try
                {
                    _context.Telefones.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }
    }
}
