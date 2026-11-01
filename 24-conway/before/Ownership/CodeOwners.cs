namespace Before.Ownership;

// Reads a CODEOWNERS-style file: "path-prefix team". The last matching line wins, as in GitHub.
public sealed class CodeOwners(IEnumerable<string> lines)
{
    private readonly List<(string Prefix, string Team)> _rules = lines
        .Select(l => l.Trim())
        .Where(l => l.Length > 0 && !l.StartsWith('#'))
        .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        .Select(parts => (parts[0], parts[1]))
        .ToList();

    public string OwnerOf(string path)
    {
        return _rules.Last(r => r.Prefix == "*" || path.StartsWith(r.Prefix, StringComparison.Ordinal)).Team;
    }

    public IReadOnlyCollection<string> TeamsFor(IEnumerable<string> paths)
    {
        return paths.Select(OwnerOf).Distinct().Order().ToList();
    }
}
