using ListMaker.Models;
using ListMaker.Utils;

namespace ListMaker.Respositories;

public class ItemRepository : BaseRepository, IItemRepository
{
    public ItemRepository(IConfiguration configuration) : base(configuration) { }

    public List<Item> GetAll(int? userId)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                var sql = @"SELECT
	                            i.Id,
	                            i.UserId,
	                            i.StoreSectionId,
	                            i.[Name],
	                            i.Notes,
	                            i.DateCreated,
	                            ss.[Name] as StoreSectionName,
	                            ss.OrderPosition as StoreSectionOrderPosition
                            FROM Item i
                            JOIN StoreSection ss
	                            ON i.StoreSectionId = ss.Id";

                if (userId.HasValue)
                {
                    sql += $" WHERE i.UserId = {userId}";
                }

                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();

                var items = new List<Item>();
                while (reader.Read())
                {
                    var item = new Item()
                    {
                        Id = DbUtils.GetInt(reader, "Id"),
                        UserId = DbUtils.GetInt(reader, "UserId"),
                        StoreSectionId = DbUtils.GetInt(reader, "StoreSectionId"),
                        Name = DbUtils.GetString(reader, "Name"),
                        Notes = DbUtils.GetString(reader, "Notes"),
                        DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                        StoreSection = new StoreSection()
                        {
                            Id = DbUtils.GetInt(reader, "StoreSectionId"),
                            Name = DbUtils.GetString(reader, "StoreSectionName"),
                            OrderPosition = DbUtils.GetInt(reader, "StoreSectionOrderPosition")
                        }
                    };

                    items.Add(item);
                }

                reader.Close();
                return items;
            }
        }
    }
}
