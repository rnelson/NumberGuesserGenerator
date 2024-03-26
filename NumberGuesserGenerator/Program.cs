// NumberGuesserGenerator
// © 2024 Ross Nelson
// Licensed under the MIT license
using NumberGuesserGenerator;

const string templateFile = "app.py";
const string outputFolder = "output";

// Ensure the template exists
if (!File.Exists(templateFile))
{
    Console.Error.WriteLine($"error: missing {templateFile}");
    Environment.Exit(-1);
}

// Ensure the output directory exists
if (!Directory.Exists(outputFolder))
{
    Directory.CreateDirectory(outputFolder);
}

// Read in the template
var template = await File.ReadAllLinesAsync(templateFile);

// Start generating games
var (start, end) = Util.GetBounds(args);
Console.WriteLine($"Generating games {start}-{end}. Please wait...");

for (var gameNumber = start; gameNumber <= end; gameNumber++)
{
    var outputFilename = $"{outputFolder}/ng{gameNumber.ToString()}.py";
    var seed = Util.GenerateSeed(gameNumber);

    var file = template
        .Select(line => line
            .Replace("{{NGVERSION}}", gameNumber.ToString())
            .Replace("{{NGSEED}}", seed.ToString())
            .Replace("{{NGGVERSION}}", Util.GetVersion())
        ).ToList();
    await File.WriteAllLinesAsync(outputFilename, file);
}

Console.WriteLine($"Done generating games {start}-{end}");