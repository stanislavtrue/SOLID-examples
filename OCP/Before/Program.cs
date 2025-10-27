using System;
class Motorcycle
{
    public string Brand { get; }
    public string Model { get; }
    public string Type { get; }
    public Motorcycle(string Brand, string Model, string Type)
    {
        this.Brand = Brand;
        this.Model = Model;
        this.Type = Type;
    }
    public void getMotorcycleType()
    {
        switch (this.Type)
        {
            case "Sport Bike":
                Console.WriteLine($"The {this.Brand} {this.Model} motorcycle is a Sport Bike");
                break;
            case "Cruiser":
                Console.WriteLine($"The {this.Brand} {this.Model} motorcycle is a Cruiser");
                break;
            case "Naked Bike":
                Console.WriteLine($"The {this.Brand} {this.Model} motorcycle is a Naked Bike");
                break;
            case "Adventure Bike":
                Console.WriteLine($"The {this.Brand} {this.Model} motorcycle is an Adventure Bike");
                break;
            default:
                Console.WriteLine("Unsupported type");
                break;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Motorcycle DucatiP = new Motorcycle("Ducati", "Panigale V4 S", "Sport Bike");
        Motorcycle DucatiD = new Motorcycle("Ducati", "Diavel V4", "Cruiser");
        DucatiP.getMotorcycleType();
        DucatiD.getMotorcycleType();
    }
}