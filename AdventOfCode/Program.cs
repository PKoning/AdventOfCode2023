using AdventOfCode;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using Spectre.Console;

var day = AnsiConsole.Prompt(
    new SelectionPrompt<int>()
        .AddChoices(Enumerable.Range(1, 2))
        .Title("Day")
        .MoreChoicesText("More days available down below")
);

var puzzleSolver = CreatePuzzleSolver(day);
var answer = await puzzleSolver.SolvePuzzleAsync();

AnsiConsole.MarkupLineInterpolated($"Answer to the puzzle of day {day}: {answer}");

IPuzzleSolver CreatePuzzleSolver(int dayInput)
{
    var currentDirectory = Directory.GetCurrentDirectory();
    var path = Path.Combine(currentDirectory, $"Day{dayInput}/input.txt");

    switch (dayInput)
    {
        case 1:
            return new DocumentSolver(path);
        case 2:
            return new CubeGameSolver(path, 12, 13, 14);
        default:
            throw new ArgumentOutOfRangeException(nameof(dayInput), $"We haven't implemented day {dayInput} yet");
    }
}