using Before.Ownership;

// The files that "reserve with catering" touched in the layered demo (pill 16).
string[] changed =
[
    "Controllers/BookingsController.cs",
    "Dtos/ReserveWithCateringRequest.cs",
    "Models/Booking.cs",
    "Services/BookingService.cs",
    "Services/IBookingService.cs",
    "Program.cs",
];

var owners = new CodeOwners(File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "CODEOWNERS")));
var teams = owners.TeamsFor(changed);

Console.WriteLine($"Teams that must review this change: {teams.Count} ({string.Join(", ", teams)})");
