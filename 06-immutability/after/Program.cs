using System.Collections.Immutable;
using After.Bookings;

var start = new DateTimeOffset(2026, 1, 12, 10, 0, 0, TimeSpan.Zero);
var original = new Booking("Planning", start, ["ana"]);

// Every change returns a new value. Whoever holds the original keeps what they read.
var changed = original.Reschedule(start.AddHours(3)).AddAttendee("luis");

Console.WriteLine($"Original: {original.StartAt:HH:mm}, {string.Join(",", original.Attendees)}");
Console.WriteLine($"Changed:  {changed.StartAt:HH:mm}, {string.Join(",", changed.Attendees)}");

// A caller that keeps its own List can still change what an IReadOnlyList exposes. An ImmutableArray is a copy.
var mine = new List<string> { "ana" };
#pragma warning disable CA1859 // The point of the demo is the interface type
IReadOnlyList<string> view = mine;
#pragma warning restore CA1859
var snapshot = mine.ToImmutableArray();
mine.Add("intruder");
Console.WriteLine($"IReadOnlyList sees {view.Count} people, ImmutableArray sees {snapshot.Length}");
