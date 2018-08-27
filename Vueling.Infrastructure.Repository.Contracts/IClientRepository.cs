using System;
using System.Collections.Generic;
using System.Text;
using Vueling.Common;
using Vueling.Infrastructure.Model;

namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IClientRepository: IGenericRepository<VInsuranceContext, Client>
    {
        Client GetByEmail(string email);
        Client GetByName(string name); 
    }
}
