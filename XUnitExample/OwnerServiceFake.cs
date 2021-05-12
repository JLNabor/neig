using Microsoft.EntityFrameworkCore;
using Neighborhood.Models;
using Neighborhood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitExample
{
    public class OwnerServiceFake: IOwnerService
    {
        private readonly List<Owner> _owners;
        public OwnerServiceFake()
        {
            _owners = new List<Owner>() {
                new Owner{ Id=1, Email="nabor1@hotmail.com", Name="yo merengues", Phone="9987343009" },
                new Owner{ Id=2, Email="nabor2@hotmail.com", Name="yo merengues1", Phone="9987343009" },
                new Owner{ Id=3, Email="nabor3@hotmail.com", Name="yo merengues", Phone="9987343009" },
                new Owner{ Id=4, Email="nabor4@hotmail.com", Name="yo merengues", Phone="9987343009" },
                new Owner{ Id=5, Email="nabor5@hotmail.com", Name="yo merengues", Phone="9987343009" }
            };
        }

        public void AddOwner(Owner owner)
        {
            owner.Id = _owners.Count + 1;
            _owners.Add(owner);
        }

        public void DeleteOwner(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Owner> GetOwner(int id)
        {
            return await Task.FromResult(_owners.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public async Task<IEnumerable<Owner>> GetOwners()
        {
            return await Task.FromResult(_owners);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
