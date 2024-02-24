using ListMaker.Models;
using ListMaker.Utils;

namespace ListMaker.Respositories;

public class GroceryListRepository : BaseRepository, IGroceryListRepository
{
    public GroceryListRepository(IConfiguration configuration) : base(configuration) { }

    public List<GroceryList> GetAll(int? userId, bool? listItems, bool? open)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                var sql = @"SELECT
	                            gl.Id,
	                            gl.UserId,
	                            gl.[Name],
	                            gl.Notes,
	                            gl.DateCreated,
                                gl.DateUpdated,
	                            gl.IsOpen";

                if (listItems == true)
                {
                    sql += @",
                            gli.Id as GroceryListItemId,
                            gli.Quantity as GroceryListItemQuantity,
	                        gli.UnitMeas as GroceryListItemUnitMeas,
                            i.Id as ItemId,
	                        i.UserId as ItemUserId,
	                        i.StoreSectionId as ItemStoreSectionId,
	                        i.[Name] as ItemName,
	                        i.Notes as ItemNotes,
	                        i.DateCreated as ItemDateCreated,
	                        ss.[Name] as ItemStoreSectionName,
	                        ss.OrderPosition as ItemStoreSectionOrderPosition";
                }

                sql += @"
                        FROM GroceryList gl";

                if (listItems == true)
                {
                    sql += @"
                            JOIN GroceryListItem gli
	                            ON gl.Id = gli.GroceryListId
                            JOIN Item i
	                            ON gli.ItemId = i.Id
                            JOIN StoreSection ss
	                            ON i.StoreSectionId = ss.Id";
                }

                // there is probably a cleaner way to do this
                if (userId.HasValue || open.HasValue)
                {
                    sql += " WHERE ";

                    if (userId.HasValue)
                    {
                        sql += $"gl.UserId = {userId}";
                    }

                    if (userId.HasValue && open.HasValue)
                    {
                        sql += " AND ";
                    }

                    if (open == false)
                    {
                        sql += "IsOpen = '0'";
                    }

                    if (open == true)
                    {
                        sql += "IsOpen = '1'";
                    }


                }

                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();

                var lists = new List<GroceryList>();
                while (reader.Read())
                {
                    var listId = DbUtils.GetInt(reader, "Id");
                    var existingList = lists.FirstOrDefault(l => l.Id == listId);

                    if (existingList == null)
                    {
                        existingList = new GroceryList()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                            DateUpdated = DbUtils.GetDateTime(reader, "DateUpdated"),
                            IsOpen = DbUtils.GetBoolean(reader, "IsOpen"),
                            ListItems = new List<GroceryListItem>()
                        };

                        lists.Add(existingList);
                    }

                    if (listItems == true)
                    {
                        if (DbUtils.IsNotDbNull(reader, "GroceryListItemId"))
                        {
                            existingList.ListItems.Add(new GroceryListItem()
                            {
                                Id = DbUtils.GetInt(reader, "GroceryListItemId"),
                                GroceryListId = DbUtils.GetInt(reader, "Id"),
                                ItemId = DbUtils.GetInt(reader, "ItemId"),
                                Quantity = DbUtils.GetDouble(reader, "GroceryListItemQuantity"),
                                UnitMeas = DbUtils.GetString(reader, "GroceryListItemUnitMeas"),
                                Item = new Item()
                                {
                                    Id = DbUtils.GetInt(reader, "ItemId"),
                                    UserId = DbUtils.GetInt(reader, "ItemUserId"),
                                    StoreSectionId = DbUtils.GetInt(reader, "ItemStoreSectionId"),
                                    Name = DbUtils.GetString(reader, "ItemName"),
                                    Notes = DbUtils.GetString(reader, "ItemNotes"),
                                    DateCreated = DbUtils.GetDateTime(reader, "ItemDateCreated"),
                                    StoreSection = new StoreSection()
                                    {
                                        Id = DbUtils.GetInt(reader, "ItemStoreSectionId"),
                                        Name = DbUtils.GetString(reader, "ItemStoreSectionName"),
                                        OrderPosition = DbUtils.GetInt(reader, "ItemStoreSectionOrderPosition")
                                    }
                                }
                            });
                        }
                    }
                }

                reader.Close();
                return lists;
            }
        }
    }

    public GroceryList GetById(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT
	                                    gl.Id,
	                                    gl.UserId,
	                                    gl.[Name],
	                                    gl.Notes,
	                                    gl.DateCreated,
                                        gl.DateUpdated,
	                                    gl.IsOpen,
                                        gli.Id as GroceryListItemId,
                                        gli.Quantity as GroceryListItemQuantity,
	                                    gli.UnitMeas as GroceryListItemUnitMeas,
                                        i.Id as ItemId,
	                                    i.UserId as ItemUserId,
	                                    i.StoreSectionId as ItemStoreSectionId,
	                                    i.[Name] as ItemName,
	                                    i.Notes as ItemNotes,
	                                    i.DateCreated as ItemDateCreated,
	                                    ss.[Name] as ItemStoreSectionName,
	                                    ss.OrderPosition as ItemStoreSectionOrderPosition
                                    FROM GroceryList gl
                                    JOIN GroceryListItem gli
	                                    ON gl.Id = gli.GroceryListId
                                    JOIN Item i
	                                    ON gli.ItemId = i.Id
                                    JOIN StoreSection ss
	                                    ON i.StoreSectionId = ss.Id
                                    WHERE gl.Id = @Id";

                DbUtils.AddParameter(cmd, "@Id", id);

                var reader = cmd.ExecuteReader();

                GroceryList list = null;
                while (reader.Read())
                {
                    if (list == null)
                    {
                        list = new GroceryList()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                            DateUpdated = DbUtils.GetDateTime(reader, "DateUpdated"),
                            IsOpen = DbUtils.GetBoolean(reader, "IsOpen"),
                            ListItems = new List<GroceryListItem>()
                        };
                    }

                    if (DbUtils.IsNotDbNull(reader, "GroceryListItemId"))
                    {
                        list.ListItems.Add(new GroceryListItem()
                        {
                            Id = DbUtils.GetInt(reader, "GroceryListItemId"),
                            GroceryListId = DbUtils.GetInt(reader, "Id"),
                            ItemId = DbUtils.GetInt(reader, "ItemId"),
                            Quantity = DbUtils.GetDouble(reader, "GroceryListItemQuantity"),
                            UnitMeas = DbUtils.GetString(reader, "GroceryListItemUnitMeas"),
                            Item = new Item()
                            {
                                Id = DbUtils.GetInt(reader, "ItemId"),
                                UserId = DbUtils.GetInt(reader, "ItemUserId"),
                                StoreSectionId = DbUtils.GetInt(reader, "ItemStoreSectionId"),
                                Name = DbUtils.GetString(reader, "ItemName"),
                                Notes = DbUtils.GetString(reader, "ItemNotes"),
                                DateCreated = DbUtils.GetDateTime(reader, "ItemDateCreated"),
                                StoreSection = new StoreSection()
                                {
                                    Id = DbUtils.GetInt(reader, "ItemStoreSectionId"),
                                    Name = DbUtils.GetString(reader, "ItemStoreSectionName"),
                                    OrderPosition = DbUtils.GetInt(reader, "ItemStoreSectionOrderPosition")
                                }
                            }
                        });
                    }
                }

                reader.Close();
                return list;
            }
        }
    }
}