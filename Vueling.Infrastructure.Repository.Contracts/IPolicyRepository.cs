using System;
using System.Collections.Generic;
using System.Text;
using Vueling.Common;
using Vueling.Infrastructure.Model;

namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IPolicyRepository: IGenericRepository<VInsuranceContext, Policy>
    {
        IEnumerable<Policy> GetByClientId(Guid id);
    }
}
