using BuilerPlay.SqlBuilders;

namespace BuilerPlay;

internal class Program
{
    static void Main()
    {
        var query = new SelectQueryBuilder("Users")
            .Fields(["Id", "Name", "Age", "Email"])
            .Where("Age > 18")
            .Where("IsActive = 1")
            .OrderBy("Name")
            .OrderByDescending("Id")
            .Skip(10)
            .Take(5)
            .Build();

        Console.WriteLine(query.ToSql());
    }
}
