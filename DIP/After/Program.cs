using System;
using System.IO.Compression;
interface Database
{
    void SaveData(string data);
}
class PostgreSqlDatabase : Database
{
    public void SaveData(string data)
    {
        Console.WriteLine($"Saving '{data}' into PostgreSQL database...");
    }
}
class MySqlDatabase : Database
{
    public void SaveData(string data)
    {
        Console.WriteLine($"Saving '{data}' into MySQL database...");
    }
}
class DataService
{
    private readonly Database _database;
    public DataService(Database database)
    {
        _database = database;
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
        Database db = new PostgreSqlDatabase();
        DataService service = new DataService(db);
        service.ProcessData("User info");
        Console.WriteLine();
        Database db1 = new MySqlDatabase();
        DataService service1 = new DataService(db1);
        service.ProcessData("User info");
    }
}