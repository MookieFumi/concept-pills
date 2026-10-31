namespace After.Calendar;

// The shape the provider gives us. We do not control it.
// Stat: 1 confirmed, 2 tentative, 3 cancelled, 9 deleted by an admin. Dt: yyyyMMddHHmm in UTC. Dur: minutes.
public sealed record ExternalEvent(string Id, string Room, int Stat, string Dt, int Dur);
