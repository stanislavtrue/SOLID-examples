using System;
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