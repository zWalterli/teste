﻿using Microsoft.EntityFrameworkCore;
using NovaWeb.API.Context;
using NovaWeb.API.Model;
using RestWithASPNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NovaWeb.API.Repository
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
                model.TelefoneId = FindLastId();
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
            var result = FindById(id);
            if (result != null)
            {
                try
                {
                    _context.Telefones.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Telefone> FindAll()
        {
            var result = _context.Telefones
                        .ToList();          
            return result;
        }

        public Telefone FindById(long id)
        {
            return _context.Telefones
                    .SingleOrDefault(c => c.TelefoneId == id);
        }

        public Telefone Update(Telefone model)
        {
            var result = FindById(model.TelefoneId);
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

        public int FindLastId()
        {
            var result = _context.Telefones.ToList();
            return result.Count == null ? 1 : result[result.Count - 1].TelefoneId + 1;
        }

        public bool Exists(long id)
        {
            return _context.Telefones.Any(p => p.TelefoneId == id);
        }
    }
}