using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileProcessingSabir;

class FileStatistics
{
    public int FilesProcessed { get; set; } = 0;
    public int Characters { get; set; } = 0;
    public int Words { get; set; } = 0;
    public int Lines { get; set; } = 0;
    public int Errors { get; set; } = 0;

    public override string ToString() =>
        $"Files Processed {FilesProcessed}\nCharacters {Characters}\nWord {Words}\nLines {Lines}\nError word count {Errors}";
}
