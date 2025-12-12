# Single Responsibility Principle
**SRP (Single Responsibility Principle)** - це принцип єдиної відповідальності, що кожен окремий клас повинен бути спеціалізованим лише на розв'язанні одного вузького завдання. Іншими словами, клас відповідає лише за одну складову програми, реалізуючи його логіку.
## Приклад з порушення SRP
У поганому прикладі клас `Report` виконує одразу три задачі:
- зберігає текст звіту
- виводить звіт в консоль
- зберігає звіт у файл

Клас одночасно відповідає і за дані, і за вивід, і за збереження, що робить його надто залежним від змін. Зміна способу друку або способу збереження вимагатиме зміни самого класу `Report`, що порушує **SRP**.
```csharp
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
```
## Виправлений код
У виправленому варіанті відповідальності чітко розділені:
- `Report` - тільки зберігає дані, та описує сутність звіту.
- `ReportPrint` - відповідає за вивід на екран звіту.
- `ReportSave` - відповідає за збереження звіту у файл.

Кожен клас має лише одну причину для зміни, що відповідає принципу **SRP** та робить код більш гнучким, розширюваним і простим для тестування.
```csharp
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
```
