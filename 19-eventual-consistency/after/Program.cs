using After.Read;
using After.Write;

var outbox = new Queue<BookingReserved>();
var store = new BookingStore();
var screen = new MyDayScreen();
var projector = new Projector(outbox, screen);

var id = store.Add("Planning", outbox);

// The list is a copy: it lags behind the write, and the design says so.
Console.WriteLine($"List right after reserving: {screen.Count}");

// The booking the user just made is read from the source of truth, so they always see it.
Console.WriteLine($"Own booking right after reserving: {store.Find(id)}");

projector.RunOnce();
Console.WriteLine($"List after the projector runs: {screen.Count}");
