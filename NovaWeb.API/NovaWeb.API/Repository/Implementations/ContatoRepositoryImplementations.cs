using Microsoft.EntityFrameworkCore;
using NovaWeb.API.Context;
using NovaWeb.API.Model;
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
                _context.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var result = _context.Contatos.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Contatos.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Contato> FindAll()
        {
            var result = _context.Contatos
                        .ToList();
            
            foreach (Contato c in result)
            {
                c.telefones = _context.Telefones
                                .Where(t => t.IdContato.Equals(c.Id))
                                .ToList();
            }
            
            return result;
        }

        public Contato FindById(long id)
        {
            return _context.Contatos
                    .Include(c => c.telefones)
                    .SingleOrDefault(p => p.Id == id);
        }

        public Contato Update(Contato model)
        {
            var result = _context.Contatos.SingleOrDefault(p => p.Id.Equals(model.Id));
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

        public bool Exists(long id)
        {
            return _context.Contatos.Any(p => p.Id == id);
        }
    }
}
