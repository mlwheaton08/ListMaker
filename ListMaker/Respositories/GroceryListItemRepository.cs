using ListMaker.Models;
using ListMaker.Utils;

namespace ListMaker.Respositories;

public class GroceryListItemRepository : BaseRepository, IGroceryListItemRepository
{
    public GroceryListItemRepository(IConfiguration configuration) : base(configuration) { }

    public GroceryListItem GetById(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT
	                                    Id,
	                                    GroceryListId,
	                                    ItemId,
	                                    Quantity,
	                                    UnitMeas
                                    FROM GroceryListItem
                                    WHERE Id = @Id";
                DbUtils.AddParameter(cmd, "@Id", id);

                var reader = cmd.ExecuteReader();
                GroceryListItem groceryListItem = null;

                if (reader.Read())
                {
                    groceryListItem = new GroceryListItem()
                    {
                        Id = id,
                        GroceryListId = DbUtils.GetInt(reader, "GroceryListId"),
                        ItemId = DbUtils.GetInt(reader, "ItemId"),
                        Quantity = DbUtils.GetDouble(reader, "Quantity"),
                        UnitMeas = DbUtils.GetString(reader, "UnitMeas")
                    };
                }

                reader.Close();
                return groceryListItem;
            }
        }
    }

    public void Add(GroceryListItem groceryListItem)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO GroceryListItem
	                                    (GroceryListId,
	                                    ItemId,
	                                    Quantity,
	                                    UnitMeas)
                                    OUTPUT INSERTED.ID
                                    VALUES
	                                    (@GroceryListId,
	                                    @ItemId,
	                                    @Quantity,
	                                    @UnitMeas)";

                DbUtils.AddParameter(cmd, "@GroceryListId", groceryListItem.GroceryListId);
                DbUtils.AddParameter(cmd, "@ItemId", groceryListItem.ItemId);
                DbUtils.AddParameter(cmd, "@Quantity", groceryListItem.Quantity);
                DbUtils.AddParameter(cmd, "@UnitMeas", groceryListItem.UnitMeas);

                groceryListItem.Id = (int)cmd.ExecuteScalar();
            }
        }
    }

    public void Update(GroceryListItem groceryListItem)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE GroceryListItem
	                                    SET
		                                    GroceryListId = @GroceryListId,
		                                    ItemId = @ItemId,
		                                    Quantity = @Quantity,
		                                    UnitMeas = @UnitMeas
                                    WHERE Id = @Id";

                DbUtils.AddParameter(cmd, "@Id", groceryListItem.Id);
                DbUtils.AddParameter(cmd, "@GroceryListId", groceryListItem.GroceryListId);
                DbUtils.AddParameter(cmd, "@ItemId", groceryListItem.ItemId);
                DbUtils.AddParameter(cmd, "@Quantity", groceryListItem.Quantity);
                DbUtils.AddParameter(cmd, "@UnitMeas", groceryListItem.UnitMeas);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Delete(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM GroceryListItem WHERE Id = @Id";
                DbUtils.AddParameter(cmd, "@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}