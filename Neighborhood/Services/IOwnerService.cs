using Neighborhood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighborhood.Services
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetOwners();

        Task<Owner> GetOwner(int id);

        void AddOwner(Owner owner);

        void UpdateOwner(Owner owner);

        void DeleteOwner(int id);

        void Save();
    }
}
