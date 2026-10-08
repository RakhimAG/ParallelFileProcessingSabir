using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileProcessingSabir;

class FileStatistics
{
    private int filesProcessed = 0;
    public int FilesProcessed
    {
        get { return filesProcessed; }
        set { filesProcessed = value; }
    }

    private int characters = 0;
    public int Characters
    {
        get { return characters; }
        set { characters = value; }
    }

    private int words = 0;
    public int Words
    {
        get { return words; }
        set { words = value; }
    }

    private int lines = 0;
    public int Lines 
    {
        get {  return lines; }
        set { lines = value; }
    }

    private int errors = 0;
    public int Errors
    {
        get { return errors; }
        set { errors = value; }
    }

    public void IncrementFilesCountSafely() =>
        Interlocked.Increment(ref filesProcessed);

    public void AddCharactersCountSafely(int count) =>
        Interlocked.Add(ref characters, count);

    public void AddWordsCountSafely(int wordsCount) =>
        Interlocked.Add(ref words, wordsCount);

    public void AddLinesCountSafely(int linesCount) =>
        Interlocked.Add(ref lines, linesCount);

    public void AddErrorsCountSafely(int errorsCount) =>
        Interlocked.Add(ref errors, errorsCount);
    public override string ToString() =>
        $"Files Processed {FilesProcessed}\nCharacters {Characters}\nWord {Words}\nLines {Lines}\nError word count {Errors}";
}
