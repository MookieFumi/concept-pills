# concept-pills

Demos for the blog series on cross-cutting software concepts (OOP, domain modeling, architecture).

Every pill uses the same domain: **meeting room booking**, taken from [entry-hub](https://github.com/MookieFumi/entry-hub). Each folder has two projects:

- `before/`: the problem, written the way it often shows up in real code.
- `after/`: the same behaviour after applying the concept.

Run any of them with `dotnet run --project <folder>/before` or `<folder>/after`.

| Folder | Concept |
| --- | --- |
| `01-composition` | Composition over inheritance |
| `02-coupling` | Coupling and cohesion |
| `03-tell-dont-ask` | Tell, don't ask and the Law of Demeter |
| `04-value-objects` | Primitive obsession and value objects |
| `05-rich-model` | Anemic vs rich domain model |
| `06-immutability` | Immutability |
| `07-solid` | SOLID in a real case (SRP and DIP) |
| `08-essential-complexity` | Essential vs accidental complexity |
| `09-ubiquitous-language` | Ubiquitous language |
| `10-bounded-context` | Bounded context |
| `11-identity` | Entities and identity |
| `12-aggregates` | Aggregates |
| `13-domain-events` | Domain events |
| `14-repository` | Repository |
| `15-anti-corruption-layer` | Anti-corruption layer |
| `16-layers-vs-slices` | Layers vs vertical slices |
| `17-modular-monolith` | Modular monolith |
| `18-cqrs` | CQRS |
| `19-eventual-consistency` | Eventual consistency |
| `20-idempotency` | Idempotency |

Style: one class per file, braces always, folders by feature, English names.
