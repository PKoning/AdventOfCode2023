namespace AdventOfCode
{
    using System.Threading.Tasks;

    internal interface IPuzzleSolver
    {
        /// <summary>
        /// Solves a puzzle.
        /// </summary>
        /// <returns>The answer to the puzzle.</returns>
        internal Task<string> SolvePuzzleAsync();
    }
}
