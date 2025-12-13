# Interface Segregation Principle
**ISP (Interface Segregation Principle)** — принцип розділення інтерфейса, говорить що, класи програми не повинні залежати від тих методів, які вони не використовують.
## Приклад з порушенням ISP
У першому прикладі створено один великий інтерфейс `User`, і клас `SimpleUser` змушений реалізовувати методи:
- `BanUser()`
- `DeleteSystem()`

Хоча звичайний користувач не повинен мати таких прав.
```csharp
interface User
{
    void ReadData();
    void WriteData();
    void BanUser();
    void DeleteSystem();
}

class SimpleUser : User
{
    public void ReadData()
    {
        Console.WriteLine("User reads data.");
    }
    
    public void WriteData()
    {
        Console.WriteLine("User writes data.");
    }
    
    public void BanUser()
    {
        Console.WriteLine("User bans someone.");
        // But a simple user shouldn't have the right to ban other users
    }
    
    public void DeleteSystem()
    {
        Console.WriteLine("User deletes the system.");
        // A simple user shouldn't have the right to delete the system
    }
}

class Program
{
    static void Main(string[] args)
    {
        SimpleUser simpleUser = new SimpleUser();
        simpleUser.DeleteSystem();
    }
}
```
## Виправлений код
У виправленому варіанті великий інтерфейс розділений на декілька вузьких інтерфейсів, кожен з яких відповідає за одну відповідальність:
- `Reader` - читання даних
- `Writer` - запис даних
- `Moderator` - блокування користувачів
- `Administrator` - адміністративні дії
```csharp
interface Reader
{
    void ReadData();
}

interface Writer
{
    void WriteData();
}

interface Moderator
{
    void BanUser(string username);
}

interface Administrator
{
    void DeleteSystem();
}

class User : Reader, Writer
{
    public void WriteData()
    {
        Console.WriteLine("User reads data.");
    }
    
    public void ReadData()
    {
        Console.WriteLine("User writes data.");
    }
}

class Moder : Reader, Writer, Moderator
{
    public void WriteData()
    {
        Console.WriteLine("Moderator writes data.");
    }
    
    public void ReadData()
    {
        Console.WriteLine("Moderator reads data.");
    }
    
    public void BanUser(string username)
    {
        Console.WriteLine($"Moderator bans user {username}");
    }
}

class Admin : Reader, Writer, Moderator, Administrator
{
    public void WriteData()
    {
        Console.WriteLine("Admin writes data.");
    }
    
    public void ReadData()
    {
        Console.WriteLine("Admin reads data.");
    }
    
    public void BanUser(string username)
    {
        Console.WriteLine($"Admin bans user \"{username}\".");
    }
    
    public void DeleteSystem()
    {
        Console.WriteLine("Admin deletes the system.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User();
        Moder moder = new Moder();
        Admin admin = new Admin();
        user.ReadData();
        moder.BanUser("user");
        admin.DeleteSystem();
    }
}
```
