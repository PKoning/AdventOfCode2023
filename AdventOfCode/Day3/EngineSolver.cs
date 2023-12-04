namespace AdventOfCode.Day3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    internal class NumberMatch(string Number, int LineIndex, int Index, int Length)
    {
        //public 
    }

    internal sealed class EngineSolver : IPuzzleSolver
    {
        private readonly string _inputPath;
        private readonly Regex _numberRegex;

        public EngineSolver(string inputPath)
        {
            _inputPath = inputPath;
            _numberRegex = new Regex("\\d+");
        }

        public async Task<string> SolvePuzzleAsync()
        {
            // We keep a list of the lines
            var lines = new List<string>();

            // We also keep a list of all matches we find
            var numberMatches = new List<NumberMatch>();

            var index = 0;
            // For each line, we save the line and keep track of the number matches
            await foreach (var line in File.ReadLinesAsync(_inputPath))
            {
                lines.Add(line);
                var matches = _numberRegex.Matches(line);
                var lineNumberMatches = matches.Select(match => new NumberMatch(match.Value, index, match.Index, match.Length)).ToList();
                if (lineNumberMatches.Count > 0)
                {
                    numberMatches.AddRange(lineNumberMatches);
                }

                index++;
            }

            // Once all has settled, we want to determine if the matches are 'touching' another character

            return null;
        }
    }
}
