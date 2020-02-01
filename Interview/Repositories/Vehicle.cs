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
            throw new System.NotImplementedException();
        }

        public Vehicle Get(int id)
        {
            return _vehicles.SingleOrDefault(v => v.Id == id);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Vehicle item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_vehicles.Any(v => v == item))
            {
                throw new DuplicateItemException("Vehicle already exists.");
            }
            
            _vehicles.Add(item);
        }
    }
}