using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Interview.Exceptions;

namespace Interview.Repositories
{
    public class Vehicle : IStoreable<int>
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }

    public class VehicleRepository : IRepository<Vehicle, int>
    {
        private readonly ICollection<Vehicle> _vehicles = new Collection<Vehicle>();
        
        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public Vehicle Get(int id)
        {
            return GetVehicleById(id);
        }

        public void Delete(int id)
        {
            var item = GetVehicleById(id);

            _vehicles.Remove(item);
        }

        public void Save(Vehicle item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Vehicle existing = null;
            foreach (var vehicle in _vehicles)
            {
                if (vehicle.Id == item.Id)
                    existing = vehicle;
            }
            
            if (existing != null)
            {
                throw new DuplicateItemException("Vehicle already exists.");
            }
            
            _vehicles.Add(item);
        }

        private Vehicle GetVehicleById(int id)
        {
            Vehicle item = null;
            
            foreach (var vehicle in _vehicles)
            {
                if (vehicle.Id == id)
                    item = vehicle;
            }

            if (item == null)
            {
                throw new ItemNotFoundException($"Vehicle with id({id}) doesn't exist.");
            }

            return item;
        }
    }
}