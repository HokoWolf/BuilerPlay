namespace BuilerPlay.SqlBuilders;

internal class SelectQueryBuilder
{
    private SelectQuery _query = null!;

    public SelectQueryBuilder(string table)
    {
        Table(table);
    }

    public SelectQueryBuilder Table(string table)
    {
        _query = new SelectQuery(table);
        return this;
    }

    public SelectQueryBuilder Fields(string[] fields)
    {
        _query.Columns.AddRange(fields);
        return this;
    }

    public SelectQueryBuilder Where(string condition)
    {
        _query.Conditions.Add(condition);
        return this;
    }

    public SelectQueryBuilder OrderBy(string field)
    {
        _query.Orderings.Add(field);
        return this;
    }

    public SelectQueryBuilder OrderByDescending(string field)
    {
        _query.Orderings.Add(field + " DESC");
        return this;
    }

    public SelectQueryBuilder Skip(int number)
    {
        _query.Offset = number;
        return this;
    }

    public SelectQueryBuilder Take(int number)
    {
        _query.Limit = number;
        return this;
    }

    public SelectQuery Build()
    {
        return _query;
    }
}
