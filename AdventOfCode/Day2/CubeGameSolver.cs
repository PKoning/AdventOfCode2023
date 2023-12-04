namespace AdventOfCode.Day2
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class CubeHand
    {
        internal int? Red { get; set; }

        internal int? Green { get; set; }

        internal int? Blue { get; set; }

        internal bool IsValid(int maxRed, int maxGreen, int maxBlue)
        {
            return 
                (Red ?? 0) <= maxRed &&
                (Green ?? 0) <= maxGreen &&
                (Blue ?? 0) <= maxBlue;
        }

        public override string ToString()
        {
            return $"R{Red ?? 0}:G{Green ?? 0}:B{Blue ?? 0}";
        }
    }

    internal sealed class CubeGameSolver : IPuzzleSolver
    {
        private readonly string _inputPath;
        private readonly int _maxRed;
        private readonly int _maxGreen;
        private readonly int _maxBlue;

        public CubeGameSolver(string inputPath, int maxRed, int maxGreen, int maxBlue)
        {
            _inputPath = inputPath;
            _maxRed = maxRed;
            _maxGreen = maxGreen;
            _maxBlue = maxBlue;
        }

        public async Task<string> SolvePuzzleAsync()
        {
            var result = 0;
            await foreach (var line in File.ReadLinesAsync(_inputPath))
            {
                Console.WriteLine($"Processing line - {line}");
                var lineSplit = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(lineSplit[0].Replace("Game ", string.Empty));
                if (AreHandsValid(lineSplit[1]))
                {
                    Console.WriteLine($"Line {line} is valid, adding {id} to the result");
                    result += id;
                }
            }

            return result.ToString();
        }

        private bool AreHandsValid(string handsLine)
        {
            var hands = handsLine.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var hand in hands)
            {
                var cubeHand = ToCubeHand(hand);
                Console.WriteLine($"Processing hand - {hand} to {cubeHand}");
                if (!cubeHand.IsValid(_maxRed, _maxGreen, _maxBlue))
                {
                    Console.WriteLine($"Cube hand: {hand} is not valid");
                    return false;
                }
            }

            return true;
        }

        private CubeHand ToCubeHand(string hand)
        {
            var colors = hand.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var cubeHand = new CubeHand();
            foreach (var color in colors)
            {
                var colorSplit = color.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var numberOfBlocks = int.Parse(colorSplit[0]);
                switch (colorSplit[1].ToLowerInvariant())
                {
                    case "red":
                        cubeHand.Red = numberOfBlocks;
                        break;
                    case "green":
                        cubeHand.Green = numberOfBlocks;
                        break;
                    case "blue":
                        cubeHand.Blue = numberOfBlocks;
                        break;
                }
            }
            return cubeHand;
        }
    }
}
