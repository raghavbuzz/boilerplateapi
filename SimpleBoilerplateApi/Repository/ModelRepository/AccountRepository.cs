using Contracts.ContractsRepository;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.ModelRepository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }

        public IEnumerable<Account> AccountsByOwner(long ownerId)
        {
            var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
            return accounts;
        }
    }
}
