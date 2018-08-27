using System;
using System.Collections.Generic;
using System.Text;

namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IUnitOfWork: IDisposable //Idisposable porque se va a cerrar y utilizar muchas veces
    {
        IClientRepository ClientRepository { get; }
        IPolicyRepository PolicyRepository { get; }
        void Save(); // save va a guardar todo, así no tienes que ir a repository de cada cosa
    }
}
