using Interview.Repositories;
using Shouldly;
using Xunit;

namespace Interview.Tests
{
    public class VehicleRepositoryTests
    {
        [Fact]
        public void Save_GivenValidInput_ShouldSaveVehicleItem()
        {
            // Arrange
            var miniCooper = new Vehicle
            {
                Id = 1,
                Make = "Mini",
                Model = "Cooper",
                Price = 15000m
            };
            var sut = new VehicleRepository();
            
            // Act
            sut.Save(miniCooper);

            // Assert
            var result = sut.Get(1);
            result.ShouldBe(miniCooper);
        }
    }
}