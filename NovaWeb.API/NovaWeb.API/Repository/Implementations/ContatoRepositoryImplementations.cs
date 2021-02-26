using Microsoft.EntityFrameworkCore;
using NovaWeb.API.Context;
using NovaWeb.Model;
using RestWithASPNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NovaWeb.API.Repository
{
    public class ContatoRepositoryImplementations : IContatoRepository
    {
        private readonly NovaWebContext _context;

        public ContatoRepositoryImplementations(NovaWebContext context)
        {
            _context = context;
        }
        public Contato Create(Contato model)
        {
            try
            {
                model.ContatoId = FindLastIdContato();
                _context.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(long id)
        {
            var result = FindById(id);
            if (result != null)
            {
                try
                {
                    _context.Contatos.Remove(result);
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

        public List<Contato> FindAll()
        {
            var result = _context.Contatos
                        .Include(c => c.Telefones)
                        .ToList();          
            return result;
        }

        public Contato FindById(long id)
        {
            return _context.Contatos
                    .Include(t => t.Telefones)
                    .SingleOrDefault(c => c.ContatoId == id);
        }

        public Contato Update(Contato model)
        {
            var result = FindById(model.ContatoId);
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

        public int FindLastIdContato()
        {
            var result = _context.Contatos.ToList();
            return result.Count == 0 ? 1 : result[result.Count - 1].ContatoId + 1;
        }
    }
}
