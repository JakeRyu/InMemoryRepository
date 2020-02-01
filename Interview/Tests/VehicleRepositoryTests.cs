using System;
using System.Linq;
using Interview.Exceptions;
using Interview.Repositories;
using Shouldly;
using Xunit;

namespace Interview.Tests
{
    public class VehicleRepositoryTests
    {
        private const int VEHICLE_ID = 1;
        private readonly Vehicle _miniCooper = new Vehicle
        {
            Id = VEHICLE_ID,
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
            result.Id.ShouldBe(_miniCooper.Id);
            result.Make.ShouldBe(_miniCooper.Make);
            result.Model.ShouldBe(_miniCooper.Model);
            result.Price.ShouldBe(_miniCooper.Price);
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

        [Fact]
        public void Delete_GivenExistingId_ShouldRemoveTheItem()
        {
            var sut = new VehicleRepository();
            sut.Save(_miniCooper);
            
            sut.Delete(VEHICLE_ID);

            Should.Throw<ItemNotFoundException>(() => sut.Get(VEHICLE_ID));
        }

        [Fact]
        public void Delete_GivenNonExistingId_ShouldThrowItemNotFoundException()
        {
            var sut = new VehicleRepository();
            sut.Save(_miniCooper);
            
            Should.Throw<ItemNotFoundException>(() => sut.Delete(100));
        }

        [Fact]
        public void GetAll_ShouldReturnAllItems()
        {
            var sut = new VehicleRepository();
            sut.Save(_miniCooper);
            var jaguarXf = new Vehicle
            {
                Id = 2,
                Make = "Jaguar",
                Model = "XF",
                Price = 38000
            };
            sut.Save(jaguarXf);

            var result = sut.GetAll();
            
            result.Count().ShouldBe(2);
        }
    }
}