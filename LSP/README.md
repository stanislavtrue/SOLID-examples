# Liskov Substitution Principle
**LSP (Liskov Substitution Principle)** - це принцип заміни Барбари Лісков, в якому зазначено, що об'єкти в програмі повинні бути замінені їх спадкоємцями без зміни правильності програми. Іншими словами, спадкоємці класів повинні повністю зберегти поведінку своїх батьків.
## Приклад з порушення LSP
У першому прикладі клас `Square` наслідує `Rectangle`, але змінює його поведінку:
- У прямокутника ширина і висота можуть змінюватися незалежно
- У квадрата ці значення жорстко пов’язані між собою

Перевизначення властивостей `Width` та `Height` у класі `Square` призводить до неочікуваної поведінки:
```csharp
class Rectangle
{
    public virtual double Height { get; set; }
    public virtual double Width { get; set; }
    
    public double Area()
    {
        return Height * Width;
    }
}

class Square : Rectangle
{
    public override double Width
    {
        set { base.Width = base.Height = value; }
    }
    
    public override double Height 
    {
        set { base.Width = base.Height = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Square();
        rectangle.Width = 4;
        rectangle.Height = 5;
        Console.WriteLine($"Area: {rectangle.Area()}");
    }
}
```
### Результат
![](https://github.com/user-attachments/assets/1ca70137-a151-4948-9a9e-a515a73571e4)
