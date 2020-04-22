using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ContractsRepository
{
    public interface IAccountRepository: IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(long ownerId);
    }
}
