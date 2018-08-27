using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vueling.Common;
using Vueling.Infrastructure.Model;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository
{
    public class ClientRepository : GenericRepository<VInsuranceContext, Client>, IClientRepository
    {
        public ClientRepository(VInsuranceContext context) : base(context)
        {
        }

        public Client GetByEmail(string email)
        {
            return dbSet.FirstOrDefault(cli => cli.Email == email);
        }

        public Client GetByName(string name)
        {
            return dbSet.FirstOrDefault(cli => cli.Name == name);
        }
        
    }
}
