using Moq;
using Neighborhood.Controllers;
using Neighborhood.Models;
using Neighborhood.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitExample
{
    public class TestOwner
    {

        private readonly OwnerServiceFake ownerServiceFake;
        private readonly OwnerController ownerController;

        public TestOwner()
        {
            this.ownerServiceFake = new OwnerServiceFake();
            this.ownerController = new OwnerController(this.ownerServiceFake);
        }

        [Fact]
        public void TestGetAll()
        {
            // Arrange

            // Act
            var result = ownerController.Get();
            IEnumerable<Owner> owners = result.Result;

            // Assert
            Assert.NotNull(owners);

        }

        [Fact]
        public void TestGetOne()
        {
            // Arrange
            int id = 2;

            // Act
            var result = ownerController.Get(id);
            Owner owner = result.Result;

            // Assert
            Assert.True(owner.Name.Equals("yo merengues1"));

        }
    }
}
