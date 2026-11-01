using After.Ownership;

// The files that "reserve with catering" touched in the vertical-slice demo (pill 16).
string[] changed =
[
    "Features/ReserveWithCatering/ReserveWithCateringHandler.cs",
    "Features/ReserveWithCatering/ReserveWithCateringRequest.cs",
    "Program.cs",
];

var owners = new CodeOwners(File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "CODEOWNERS")));
var teams = owners.TeamsFor(changed);

Console.WriteLine($"Teams that must review this change: {teams.Count} ({string.Join(", ", teams)})");
