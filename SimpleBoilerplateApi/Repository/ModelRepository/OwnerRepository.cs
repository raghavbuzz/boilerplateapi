using Contracts.ContractsRepository;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository.ModelRepository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }

        #region-- Sync Methods --
        public IEnumerable<Owner> GetAllOwners()
        {
            var owners = FindAll().OrderBy(ow => ow.Name).Include(ac => ac.Accounts).ToList();
            return owners;
        }
        public Owner GetOwnerById(long ownerId)
        {
            var owner = FindByCondition(x => x.Id.Equals(ownerId)).FirstOrDefault();
            return owner;
        }
        public Owner GetOwnerWithDetails(long ownerId)
        {
            var owner = FindByCondition(x => x.Id.Equals(ownerId)).Include(ac => ac.Accounts).FirstOrDefault();
            return owner;
        }
        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }
        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }
        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }
        #endregion

        #region-- Async Methods --
        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            var owners = await FindAll().OrderBy(ow => ow.Name).Include(ac => ac.Accounts).ToListAsync();
            return owners;
        }

        public async Task<Owner> GetOwnerByIdAsync(long ownerId)
        {
            var owner = await FindByCondition(x => x.Id.Equals(ownerId)).FirstOrDefaultAsync();
            return owner;
        }

        public async Task<Owner> GetOwnerWithDetailsAsync(long ownerId)
        {
            var owner = await FindByCondition(x => x.Id.Equals(ownerId)).Include(ac => ac.Accounts).FirstOrDefaultAsync();
            return owner;
        }
        #endregion
    }
}
