using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository
{
    public class GenericRepository<C, T> : IGenericRepository<C, T> where C : DbContext where T : class
    {
        internal C context;
        internal DbSet<T> dbSet; // el que realmente trabaja con las entidades. Se saca a aprtir del constructor

        public GenericRepository(C context)
        {
            this.context = context ?? throw new ArgumentException(nameof(context));
            this.dbSet = context.Set<T>();
        }

        public void Delete(object id) // busca primero en el dbset el modelo (nº440) y luego lo bora
        {
            T entityToDelete = GetByID(id);
            Delete(entityToDelete);
        }

        public void Delete(T entityToDelete) // se implemente el delete aqui y se llama arriba
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet as IEnumerable<T>;
        }

        public T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
