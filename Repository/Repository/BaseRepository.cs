﻿using Domain.Entity;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class BaseRepository<T, TId> where T : class
    {
        private readonly GestaoContext _context;

        public BaseRepository(GestaoContext context)
        {
            _context = context;
        }

        public T GetById(TId id)
        {
            return _context.Set<T>().Find(id);
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Salvar(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
            return t;
        }

        public T Atualizar(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();

            return t;
        }

        public T Deletar(TId id)
        {
            T t = GetById(id);
            _context.Entry(t).State = EntityState.Deleted;
            _context.Remove(t);
            _context.SaveChanges();

            return t;
        }
    }
}
