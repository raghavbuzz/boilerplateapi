using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ContractsRepository
{
    public interface IOwnerRepository: IRepositoryBase<Owner>
    {

        #region-- Sync Methods Signatures --
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(long ownerId);
        Owner GetOwnerWithDetails(long ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
        #endregion

        #region-- Async Methods Signatures --
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(long ownerId);
        Task<Owner> GetOwnerWithDetailsAsync(long ownerId);
        #endregion
    }
}
