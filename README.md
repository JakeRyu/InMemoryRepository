# IN-MEMORY REPOSITORY

This practice takes a vehicle as a sample model to demonstrate CRUD functions using an in-memory repository.

```
    public class Vehicle : IStoreable<int>
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }
```

The practice aims to prove that I follow the RED-GREEN-REFACTOR pattern in my commits. The source code is 100% covered by tests.
