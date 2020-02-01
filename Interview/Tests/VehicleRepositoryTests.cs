using System;
using Interview.Exceptions;
using Interview.Repositories;
using Shouldly;
using Xunit;

namespace Interview.Tests
{
    public class VehicleRepositoryTests
    {
        private readonly Vehicle _miniCooper = new Vehicle
        {
            Id = 1,
            Make = "Mini",
            Model = "Cooper",
            Price = 15000m
        };
        
        [Fact]
        public void Save_GivenValidInput_ShouldSaveVehicleItem()
        {
            // Arrange
            var sut = new VehicleRepository();
            
            // Act
            sut.Save(_miniCooper);

            // Assert
            var result = sut.Get(1);
            result.Equals(_miniCooper).ShouldBeTrue();
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
            var sut = new VehicleRepository();
            
            sut.Save(_miniCooper);

            Should.Throw<DuplicateItemException>(() => sut.Save(_miniCooper));
        }

        [Fact]
        public void Save_GivenNewItemWithSameId_ShouldThrowDuplicateItemException()
        {
            var sut = new VehicleRepository();
            sut.Save(_miniCooper);
            var sameIdVehicle = new Vehicle
            {
                Id = 1
            };

            Should.Throw<DuplicateItemException>(() => sut.Save(sameIdVehicle));
        }

        [Fact]
        public void Get_GivenExistingId_ShouldFindItem()
        {
            // Already covered by Save_GivenValidInput_ShouldSaveVehicleItem()
        }

        [Fact]
        public void Get_GivenNonExistingId_ShouldThrowItemNotFoundException()
        {
            var sut = new VehicleRepository();
            sut.Save(_miniCooper);

            Should.Throw<ItemNotFoundException>(() => sut.Get(2));
        }
    }
}