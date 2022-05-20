using CommandDotNet;

namespace Refactor.App;

[Command("refactor")]
public class AppCommands
{
    [Command("lambdatobrackets")]
    public async void AppInfo(FileArgs model)
    {
        Console.WriteLine($"FilePath: {model.FilePath}");
        if(string.IsNullOrWhiteSpace(model.FilePath))
            throw new ArgumentException(nameof(model.FilePath));
        var text = await File.ReadAllLinesAsync(model.FilePath);
        var lines = text.ToList();
        var line = lines.FirstOrDefault(l => l.Contains("() =>"));
         if(string.IsNullOrWhiteSpace(line))
            throw new ArgumentException(nameof(line));
        var lineIndex = lines.IndexOf(line);
        Console.WriteLine($"FoundLine: {text[lineIndex]}");
        var lineToRefactor = lines[lineIndex];
        var split = lineToRefactor.Split("() =>");
        var methodName = split[0];
        var methodBody = split[1];
        Console.WriteLine("RefactoredLine:");
        Console.WriteLine(lines[lineIndex]);
        lines.RemoveAt(lineIndex);
        lines.Insert(lineIndex, "\t}");
        lines.Insert(lineIndex, "\t\t" + methodBody.Trim());
        lines.Insert(lineIndex, "\t{");
        lines.Insert(lineIndex, methodName);
        await File.WriteAllLinesAsync(model.FilePath, lines);
    }
}