using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IGenericRepository<C, T> where C: DbContext where T: class  // C es el contexto de la base de datos, no se utiliza aqui porque aqui se define el genérico. Para poderlo utilizar en el cliente necesitas extenderlo aqui para que sepa los métodos de clientes extras, como getbyemail, que aqui no hay pero en cliente si
    {
        void Delete(object id);
        void Delete(T entityToDelete);
        IEnumerable<T> GetAll();
        T GetByID(object id);
        void Insert(T entity);
        void Update(T entityToUpdate);

    }
}
