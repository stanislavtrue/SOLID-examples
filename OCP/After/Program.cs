using System;
class Motorcycle {
    public string Brand { get; }
    public string Model { get; }
    public MotorcycleType Type { get; }
    public Motorcycle(string Brand, string Model, MotorcycleType Type) {
        this.Brand = Brand;
        this.Model = Model;
        this.Type = Type;
    }
    public string GetType() {
        return Type.getType();
    }
}
abstract class MotorcycleType {
    public abstract string getType();
}
class SportBike: MotorcycleType {
    public override string getType() {
        return "Sport Bike";
    }
}
class Cruiser : MotorcycleType {
    public override string getType() {
        return "Cruiser";
    }
}
class NakedBike: MotorcycleType {
    public override string getType() {
        return "Naked Bike";
    }
}
class AdventureBike: MotorcycleType {
    public override string getType() {
        return "Adventure Bike";
    }
}
class Program {
    static void Main(string[] args) {
        Motorcycle DucatiP = new Motorcycle("Ducati", "Panigale V4 S", new SportBike());
        Console.WriteLine($"The {DucatiP.Brand} {DucatiP.Model} motorcycle is a {DucatiP.GetType()}");
        Motorcycle DucatiD = new Motorcycle("Ducati", "Diavel V4", new Cruiser());
        Console.WriteLine($"The {DucatiD.Brand} {DucatiD.Model} motorcycle is a {DucatiD.GetType()}");
    }
}