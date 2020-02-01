using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Instrumentation;
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
            var item = _vehicles.SingleOrDefault(v => v.Id == id);

            if (item == null)
            {
                throw new ItemNotFoundException($"Vehicle with id({id}) doesn't exist.");
            }

            return item;
        }

        public void Delete(int id)
        {
            var item = _vehicles.SingleOrDefault(v => v.Id == id);

            if (item == null)
            {
                throw new ItemNotFoundException($"Vehicle with id({id}) doesn't exist.");

            }

            _vehicles.Remove(item);
        }

        public void Save(Vehicle item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_vehicles.Any(v => v.Id == item.Id))
            {
                throw new DuplicateItemException("Vehicle already exists.");
            }
            
            _vehicles.Add(item);
        }
    }
}