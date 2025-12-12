using System;
using System.IO;

class Report
{
    public string Text { get; set; }
    
    public Report(string text)
    {
        Text = text;
    }
    
    public void PrintReport()
    {
        Console.WriteLine($"Report: {Text}");
    }
    
    public void SaveReport(string path)
    {
        File.WriteAllText(path, Text);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Report report = new Report("Example of a program violating the Single Responsiblity Principle");
        report.PrintReport();
        report.SaveReport("badExample.txt");
    }
}
