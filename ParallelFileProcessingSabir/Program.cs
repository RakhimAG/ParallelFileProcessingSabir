
using ParallelFileProcessingSabir;

var fileStatistics = new FileStatistics();

#region NON PARALLEL VERSION
//for (int i = 1; i <= 10; i++)
//{
//    string text = File.ReadAllText($"../../../Files/file{i}.txt");

//    fileStatistics.Characters += text.Length;

//    fileStatistics.Lines += text.Split('\n').Length;

//    var words = text.Split
//    (
//        ['\n', ' ', '\r', '\t'],
//        StringSplitOptions.RemoveEmptyEntries
//    );
//    fileStatistics.Words += words.Length;

//    fileStatistics.Errors += words
//        .Where(x => x.Contains("error", StringComparison.OrdinalIgnoreCase))
//        .Count();

//    fileStatistics.FilesProcessed++;
//    Thread.Sleep(1000);
//}
#endregion


#region PARALLEL VERSION
void AnylizeFileStats(string path)
{
    string text = File.ReadAllText(path);

    fileStatistics.AddCharactersCountSafely(text.Length);

    fileStatistics.AddLinesCountSafely(text.Split('\n').Length);

    var words = text.Split
    (
        ['\n', ' ', '\r', '\t'],
        StringSplitOptions.RemoveEmptyEntries
    );
    fileStatistics.AddWordsCountSafely(words.Length);

    fileStatistics.AddErrorsCountSafely(
         words
        .Where(x => x.Contains("error", StringComparison.OrdinalIgnoreCase))
        .Count()
     );

    fileStatistics.IncrementFilesCountSafely();
    Thread.Sleep(1000);
}
Parallel.For(1, 11, i => AnylizeFileStats($"../../../Files/file{i}.txt"));
#endregion
Console.WriteLine($"==== OVERALL STATISTICS =====\n{fileStatistics}");