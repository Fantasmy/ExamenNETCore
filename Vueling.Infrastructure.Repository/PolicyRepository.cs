using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vueling.Common;
using Vueling.Infrastructure.Model;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository
{
    public class PolicyRepository : GenericRepository<VInsuranceContext, Policy>, IPolicyRepository
    {
        public PolicyRepository(VInsuranceContext context) : base(context)
        {
        }

        public IEnumerable<Policy> GetByClientId(Guid id)
        {
            return dbSet.Where(cli => cli.ClientId == id);
        }
    }
}
