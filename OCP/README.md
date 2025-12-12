# Open/Closed Principle
**OCP (Open/Closed Principle)** - це принцип відкритості/закритості, говорить що код повинен бути відкритий для розширення, але закритий для модифікації. Іншими словами, модифікація поведінки програми здійснюється тільки шляхом додавання нових компонентів. Новий функціонал накладається на старий.
## Приклад з порушення OCP
У поганому прикладі клас `Motorcycle` містить метод `getMotorcycleType()`, який визначає тип мотоцикла за допомогою великого `switch`:
```csharp
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
```
Таке рішення порушує принцип відкритості-закритості, тому що:
- При додаванні нового типу мотоцикла доводиться редагувати існуючий клас
- Логіка визначення типів зібрана в одному методі, який постійно росте
- Клас стає менш гнучким і складним для підтримки

Іншими словами, клас закритий для розширення, тому що кожна зміна потребує модифікації його коду.
## Виправлений код
У виправленій версії вся логіка визначення типу мотоцикла переноситься у окрему ієрархію класів:
- `MotorcycleType` - абстрактний клас
- `SportBike`, `Cruiser`, `NakedBike`, `AdventureBike` - конкретні реалізації
```csharp
class Motorcycle
{
    public string Brand { get; }
    public string Model { get; }
    public MotorcycleType Type { get; }

    public Motorcycle(string Brand, string Model, MotorcycleType Type)
    {
        this.Brand = Brand;
        this.Model = Model;
        this.Type = Type;
    }

    public string GetType()
    {
        return Type.getType();
    }
}

abstract class MotorcycleType
{
    public abstract string getType();
}

class SportBike: MotorcycleType
{
    public override string getType()
    {
        return "Sport Bike";
    }
}

class Cruiser : MotorcycleType
{
    public override string getType()
    {
        return "Cruiser";
    }
}

class NakedBike: MotorcycleType
{
    public override string getType()
    {
        return "Naked Bike";
    }
}

class AdventureBike: MotorcycleType
{
    public override string getType()
    {
        return "Adventure Bike";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Motorcycle DucatiP = new Motorcycle("Ducati", "Panigale V4 S", new SportBike());
        Console.WriteLine($"The {DucatiP.Brand} {DucatiP.Model} motorcycle is a {DucatiP.GetType()}");

        Motorcycle DucatiD = new Motorcycle("Ducati", "Diavel V4", new Cruiser());
        Console.WriteLine($"The {DucatiD.Brand} {DucatiD.Model} motorcycle is a {DucatiD.GetType()}");
    }
}
```
