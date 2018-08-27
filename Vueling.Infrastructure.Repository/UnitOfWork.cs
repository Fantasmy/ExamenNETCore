using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vueling.Common;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork  // unit of work lo que hace es en vez de trabajar con los servicios lo haces aqui. Si guardas haces el save del unit of work, ahorrandote el save de todos ellos. Lo hace todo en una misma transacción, porque guarda todo el contexto. Es una facade de los repositorios que ñade una funcionaldiad del save
    {
        private VInsuranceContext _context;
        private ClientRepository clientRepository;
        private PolicyRepository policyRepository;
        private bool disposed = false;


        public IClientRepository ClientRepository
        {
            get
            {
                if(this.clientRepository == null)
                {
                    this.clientRepository = new ClientRepository(_context);
                }
                return clientRepository;
            }
        }
        public IPolicyRepository PolicyRepository
        {
            get
            {
                if (this.policyRepository == null)
                {
                    this.policyRepository = new PolicyRepository(_context);
                }
                return policyRepository;
            }
        }

        public UnitOfWork(VInsuranceContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));  //?? = si es null te devuelves
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
        }
    }
}
