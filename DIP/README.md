# Dependency Inversion Principle
**DIP (Dependency Inversion Principle)** — це принцип інверсії залежностей, який стверджує, що компоненти верхнього рівня не повинні залежати від компонентів нижчого рівня. Іншими словами, абстракції не повинні залежати від деталей. Деталі повинні залежати від абстракцій.
## Приклад з порушення DIP
У поганому варіанті клас `DataService` напряму залежить від конкретної реалізації бази даних, і це призводить до проблем:
- `DataService` жорстко прив’язаний до `PostgreSQL`
- Заміна бази даних вимагає зміни коду `DataService`
- Складно тестувати клас без реальної бази даних
```csharp
using System;
using System.ComponentModel.Design.Serialization;

class PostgreSqlDatabase
{
    public void SaveData(string data)
    {
        Console.WriteLine($"Saving '{data}' into PostgreSQL database...");
    }
}

class DataService
{
    private PostgreSqlDatabase _database;
    
    public DataService()
    {
        _database = new PostgreSqlDatabase();
    }
    
    public void ProcessData(string data)
    {
        Console.WriteLine($"Processing: {data}");
        _database.SaveData(data);
    }
}

class Program
{
    static void Main(string[] args)
    {
        DataService service = new DataService();
        service.ProcessData("User info");
    }
}
```
