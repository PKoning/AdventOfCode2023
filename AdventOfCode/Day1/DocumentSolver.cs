namespace AdventOfCode.Day1
{
    internal record SpelledOutDigit(string Word, char Digit);

    internal class DocumentSolver : IPuzzleSolver
    {
        private readonly string _inputPath;

        private static readonly SpelledOutDigit[] SpelledOutDigits = {
            new("one", '1'),
            new("two", '2'),
            new("three", '3'),
            new("four", '4'),
            new("five", '5'),
            new("six", '6'),
            new("seven", '7'),
            new("eight", '8'),
            new("nine", '9'),
            new("zero", '0')
        };

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
        /// We want to get the first and last digit of the line.
        /// It doesn't matter if it's an actual digit character or the spelled out digit.
        /// Then we want to concatenate them to form a new number.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>A new number.</returns>
        private static int getNumber(string line)
        {
            var digits = new List<char>();
            for (var i = 0; i < line.Length; i++)
            {
                var character = line[i];
                if (char.IsDigit(character))
                {
                    digits.Add(line[i]);
                    continue;
                }

                var rest = line[i..];
                digits.AddRange(
                    SpelledOutDigits
                        .Where(spelledOutDigit => rest.StartsWith(spelledOutDigit.Word))
                        .Select(spelledOutDigit => spelledOutDigit.Digit));
            }

            var resultingDigits = new[] { digits[0], digits[^1] };

            return int.Parse(new string(resultingDigits));
        }
    }
}