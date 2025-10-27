using System;
using System.IO;
class Report
{
    public string Text { get; set; }
    public Report(string text)
    {
        Text = text;
    }
}
class ReportPrint
{
    public void PrintToConsole(Report report)
    {
        Console.WriteLine($"Report: {report.Text}");
    }
}
class ReportSave {
    public void SaveToFile(Report report, string path)
    {
        File.WriteAllText(path, report.Text);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Report report = new Report("Example of a program violating the Single Responsiblity Principle");
        ReportPrint print = new ReportPrint();
        ReportSave save = new ReportSave();
        print.PrintToConsole(report);
        save.SaveToFile(report, "goodExample.txt");
    }
}