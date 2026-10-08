
using ParallelFileProcessingSabir;

var fileStatistics = new FileStatistics();

for (int i = 1; i <= 10; i++)
{
    string text = File.ReadAllText($"../../../Files/file{i}.txt");

    fileStatistics.Characters += text.Length;
    
    fileStatistics.Lines += text.Split('\n').Length;
    
    var words = text.Split
    (
        ['\n', ' ', '\r', '\t'],
        StringSplitOptions.RemoveEmptyEntries
    );
    fileStatistics.Words += words.Length;

    fileStatistics.Errors += words
        .Where(x => x.Contains("error", StringComparison.OrdinalIgnoreCase))
        .Count();

    fileStatistics.FilesProcessed++;
    Thread.Sleep(1000);
}

Console.WriteLine($"==== OVERALL STATISTICS =====\n{fileStatistics}");