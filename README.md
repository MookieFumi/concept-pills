# concept-pills

Demos for the blog series on cross-cutting software concepts (OOP, domain modeling, architecture).

Every pill uses the same domain: **meeting room booking**, taken from [entry-hub](https://github.com/MookieFumi/entry-hub). Each folder has two projects:

- `before/`: the problem, written the way it often shows up in real code.
- `after/`: the same behaviour after applying the concept.

Run any of them with `dotnet run --project <folder>/before` or `<folder>/after`.

| Folder | Concept |
| --- | --- |
| `01-composition` | Composition over inheritance |

Style: one class per file, braces always, folders by feature, English names.
