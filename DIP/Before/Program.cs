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
