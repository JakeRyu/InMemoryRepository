using System.Collections.Generic;

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
        public IEnumerable<Vehicle> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Vehicle Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Vehicle item)
        {
            throw new System.NotImplementedException();
        }
    }
}