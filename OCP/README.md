# Open/Closed Principle
**OCP (Open/Closed Principle)** — це принцип відкритості/закритості, говорить що код повинен бути відкритий для розширення, але закритий для модифікації. Іншими словами, модифікація поведінки програми здійснюється тільки шляхом додавання нових компонентів. Новий функціонал накладається на старий.
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
- при додаванні нового типу мотоцикла доводиться редагувати існуючий клас
- логіка визначення типів зібрана в одному методі, який постійно росте
- клас стає менш гнучким і складним для підтримки

Іншими словами, клас закритий для розширення, тому що кожна зміна потребує модифікації його коду.
