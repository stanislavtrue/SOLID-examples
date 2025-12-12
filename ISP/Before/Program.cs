using System;
using System.Runtime.InteropServices;

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
