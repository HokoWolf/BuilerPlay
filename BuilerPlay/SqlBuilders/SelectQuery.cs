namespace BuilerPlay.SqlBuilders;

internal class SelectQuery(string table)
{
    public string Table { get; } = table;

    public List<string> Columns { get; init; } = [];

    public List<string> Conditions { get; init; } = [];

    public List<string> Orderings { get; init; } = [];

    public int? Limit { get; set; }

    public int? Offset { get; set; }

    public string ToSql()
    {
        var columnsString = Columns.Any() ? string.Join(", ", Columns) : "*";

        var sql = $"SELECT {columnsString} FROM {Table}";
        
        if (Conditions.Any())
        {
            sql += $"\nWHERE {string.Join(" AND ", Conditions)}";
        }
        
        if (Orderings.Any())
        {
            sql += $"\nORDER BY {string.Join(", ", Orderings)}";
        }

        if (Limit.HasValue)
        {
            sql += $"\nLIMIT {Limit.Value}";
        }

        if (Offset.HasValue)
        {
            sql += $" OFFSET {Offset.Value}";
        }

        return sql;
    }
}
