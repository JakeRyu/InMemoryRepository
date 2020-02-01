using System;
using Interview.Exceptions;
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
            result.Equals(miniCooper).ShouldBeTrue();
        }

        [Fact]
        public void Save_GivenNullItem_ShouldThrowArgumentNullException()
        {
            Vehicle nullVehicle = null;
            var sut = new VehicleRepository();
            
            Should.Throw<ArgumentNullException>(() => sut.Save(nullVehicle));
        }

        [Fact]
        public void Save_WhenSavingTwice_ShouldThrowDuplicateItemException()
        {
            var miniCooper = new Vehicle
            {
                Id = 1,
                Make = "Mini",
                Model = "Cooper",
                Price = 15000m
            };
            var sut = new VehicleRepository();
            
            sut.Save(miniCooper);

            Should.Throw<DuplicateItemException>(() => sut.Save(miniCooper));
        }

        [Fact]
        public void Save_GivenNewItemWithSameId_ShouldThrowDuplicateItemException()
        {
            var miniCooper = new Vehicle
            {
                Id = 1,
                Make = "Mini",
                Model = "Cooper",
                Price = 15000m
            };
            var sut = new VehicleRepository();
            sut.Save(miniCooper);
            var sameIdVehicle = new Vehicle
            {
                Id = 1
            };

            Should.Throw<DuplicateItemException>(() => sut.Save(sameIdVehicle));
        }
    }
}