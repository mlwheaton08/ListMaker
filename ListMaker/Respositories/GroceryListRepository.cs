using ListMaker.Models;
using ListMaker.Utils;

namespace ListMaker.Respositories;

public class GroceryListRepository : BaseRepository, IGroceryListRepository
{
    public GroceryListRepository(IConfiguration configuration) : base(configuration) { }

    public List<GroceryList> GetAll(int userId, bool? open)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                var sql = @"SELECT
	                            Id,
	                            UserId,
	                            [Name],
	                            Notes,
	                            DateCreated,
                                DateUpdated,
	                            IsOpen
                            FROM GroceryList
                            WHERE UserId = @UserId";

                if (open == true)
                {
                    sql += $" AND IsOpen = '1'";
                }

                if (open == false)
                {
                    sql += $" AND IsOpen = '0'";
                }

                DbUtils.AddParameter(cmd, "@UserId", userId);

                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();

                var lists = new List<GroceryList>();
                while (reader.Read())
                {
                    var list = new GroceryList()
                    {
                        Id = DbUtils.GetInt(reader, "Id"),
                        UserId = DbUtils.GetInt(reader, "UserId"),
                        Name = DbUtils.GetString(reader, "Name"),
                        Notes = DbUtils.GetString(reader, "Notes"),
                        DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                        DateUpdated = DbUtils.GetDateTime(reader, "DateUpdated"),
                        IsOpen = DbUtils.GetBoolean(reader, "IsOpen")
                    };

                    lists.Add(list);
                }

                reader.Close();
                return lists;
            }
        }
    }
}