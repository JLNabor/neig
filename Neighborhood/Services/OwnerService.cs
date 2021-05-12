using Microsoft.EntityFrameworkCore;
using Neighborhood.DataBaseContext;
using Neighborhood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighborhood.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly NeighborhoodContext _neighborhoodContext;
        public OwnerService(NeighborhoodContext neighborhoodContext) {
            this._neighborhoodContext = neighborhoodContext;
        }
        public void AddOwner(Owner owner)
        {
            this._neighborhoodContext.Owners.Add(owner);
            this.Save();
        }

        public void DeleteOwner(int id)
        {
            Owner owner = this._neighborhoodContext
                .Owners
                .FirstOrDefault(x=>x.Id.Equals(id));

            this._neighborhoodContext.Owners.Remove(owner);
            this.Save();
        }

        public async Task<Owner> GetOwner(int id)
        {
            return await _neighborhoodContext.Owners
                .Include(x => x.Houses)
                .FirstOrDefaultAsync(x=>x.Id.Equals(id));
        }

        public async Task<IEnumerable<Owner>> GetOwners()
        {
            return await _neighborhoodContext.Owners                
                .ToListAsync();
        }

        public void UpdateOwner(Owner owner)
        {
            this._neighborhoodContext.Entry<Owner>(owner).State = EntityState.Modified;
            this.Save();
        }

        public void Save() 
        {
            this._neighborhoodContext.SaveChanges();
        }
    }
}
