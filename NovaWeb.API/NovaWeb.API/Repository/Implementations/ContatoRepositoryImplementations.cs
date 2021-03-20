using Microsoft.EntityFrameworkCore;
using NovaWeb.API.Context;
using NovaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NovaWeb.API.Repository.Implementations
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
                    foreach (var item in model.Telefones)
                    {
                        if (item.ContatoId <= 0)
                        {
                            item.ContatoId = model.ContatoId;
                            _context.Add(item);
                        } else
                        {
                            var result_item = _context.Telefones
                                                      .SingleOrDefault(t => t.TelefoneId
                                                                        .Equals(item.TelefoneId));
                            _context.Entry(result_item).CurrentValues.SetValues(item);
                        }
                    }
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

        public List<Contato> FindByName(string firtsName, string lastName)
        {
            
            if (!string.IsNullOrWhiteSpace(firtsName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Contatos.Where(
                c => c.FirstName.Contains(firtsName)
                     && c.LastName.Contains(lastName)).Include(c => c.Telefones).ToList();
            }
            else if (string.IsNullOrWhiteSpace(firtsName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Contatos.Where(
                c => c.LastName.Contains(lastName)).Include(c => c.Telefones).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(firtsName) && string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Contatos.Where(
                c => c.FirstName.Contains(firtsName)).Include(c => c.Telefones).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Contato> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            List<Contato> contatos = new List<Contato>();

            if (string.IsNullOrWhiteSpace(name))
            {
                contatos = _context.Contatos
                            .Include(c => c.Telefones)
                            .ToList();
            } else
            {
                contatos = _context.Contatos
                            .Include(c => c.Telefones)
                            .Where(c => c.LastName.ToUpper().Contains(name) 
                                   || c.FirstName.ToUpper().Contains(name) 
                                   || c.Email.ToUpper().Contains(name))
                            .ToList();
            }

            if ( sortDirection.Equals("asc") )
            {
                contatos.OrderBy( c => c);
            }
            else
            {
                contatos.OrderByDescending(c => c);
            }

            return contatos.Skip(pageSize * (page - 1)).Take(pageSize).ToList(); ;
        }

        public int GetCount(string name)
        {
            int qntContatos; 

            if ( string.IsNullOrWhiteSpace(name) )
            {
                qntContatos = _context.Contatos.ToList().Count();
            }
            else
            {
                qntContatos = _context.Contatos
                    .Where(c => c.LastName.ToUpper().Contains(name) 
                           || c.FirstName.ToUpper().Contains(name) 
                           || c.Email.ToUpper().Contains(name))
                    .ToList()
                    .Count();
            }

            return qntContatos;
        }
    }
}
