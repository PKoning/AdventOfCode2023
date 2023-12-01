namespace AdventOfCode.Day1
{
    internal class DocumentSolver : IPuzzleSolver
    {
        private readonly string _inputPath;

        internal DocumentSolver(string inputPath)
        {
            _inputPath = inputPath;
        }

        public async Task<string> SolvePuzzleAsync()
        {
            var totalSum = 0;
            await foreach (var line in File.ReadLinesAsync(_inputPath))
            {
                totalSum += getNumber(line);
            }

            return totalSum.ToString();
        }

        /// <summary>
        /// We want to get the first and last digit of the line
        /// Then we want to concatenate them to form a new number
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>A new number.</returns>
        private int getNumber(string line)
        {
            var numbers = line.Where(char.IsDigit).ToList();
            if (numbers.Count == 0)
            {
                return 0;
            }

            var digits = new[] { numbers[0], numbers[^1] };

            return int.Parse(new string(digits));
        }
    }
}