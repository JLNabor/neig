using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neighborhood.Models;
using Neighborhood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighborhood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService ) 
        {
            this._ownerService = ownerService;
        }

        [HttpGet]
        public Task<IEnumerable<Owner>> Get() {
            return this._ownerService.GetOwners();
        }

        [HttpGet("{id}", Name = "Get")]
        public Task<Owner> Get(int id)
        {
            return this._ownerService.GetOwner(id);
        }

        [HttpPost]
        public void Post(Owner owner)
        {
            this._ownerService.AddOwner(owner);
        }

        [HttpPut]
        public void Put(Owner owner)
        {
            this._ownerService.UpdateOwner(owner);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this._ownerService.DeleteOwner(id);
        }

    }
}
