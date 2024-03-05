using ListMaker.Models;
using ListMaker.Utils;

namespace ListMaker.Respositories;

public class RecipeItemRepository : BaseRepository, IRecipeItemRepository
{
    public RecipeItemRepository(IConfiguration configuration) : base(configuration) { }

    public RecipeItem GetById(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT
	                                    Id,
	                                    RecipeId,
	                                    ItemId,
	                                    Quantity,
	                                    UnitMeas
                                    FROM RecipeItem
                                    WHERE Id = @Id";
                DbUtils.AddParameter(cmd, "@Id", id);

                var reader = cmd.ExecuteReader();
                RecipeItem recipeItem = null;

                if (reader.Read())
                {
                    recipeItem = new RecipeItem()
                    {
                        Id = id,
                        RecipeId = DbUtils.GetInt(reader, "RecipeId"),
                        ItemId = DbUtils.GetInt(reader, "ItemId"),
                        Quantity = DbUtils.GetDouble(reader, "Quantity"),
                        UnitMeas = DbUtils.GetString(reader, "UnitMeas")
                    };
                }

                reader.Close();
                return recipeItem;
            }
        }
    }

    public void Add(RecipeItem recipeItem)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO RecipeItem
	                                    (RecipeId,
	                                    ItemId,
	                                    Quantity,
	                                    UnitMeas)
                                    OUTPUT INSERTED.ID
                                    VALUES
	                                    (@RecipeId,
	                                    @ItemId,
	                                    @Quantity,
	                                    @UnitMeas)";

                DbUtils.AddParameter(cmd, "@RecipeId", recipeItem.RecipeId);
                DbUtils.AddParameter(cmd, "@ItemId", recipeItem.ItemId);
                DbUtils.AddParameter(cmd, "@Quantity", recipeItem.Quantity);
                DbUtils.AddParameter(cmd, "@UnitMeas", recipeItem.UnitMeas);

                recipeItem.Id = (int)cmd.ExecuteScalar();
            }
        }
    }

    public void Update(RecipeItem recipeItem)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE RecipeItem
	                                    SET
		                                    RecipeId = @RecipeId,
		                                    ItemId = @ItemId,
		                                    Quantity = @Quantity,
		                                    UnitMeas = @UnitMeas
                                    WHERE Id = @Id";

                DbUtils.AddParameter(cmd, "@Id", recipeItem.Id);
                DbUtils.AddParameter(cmd, "@RecipeId", recipeItem.RecipeId);
                DbUtils.AddParameter(cmd, "@ItemId", recipeItem.ItemId);
                DbUtils.AddParameter(cmd, "@Quantity", recipeItem.Quantity);
                DbUtils.AddParameter(cmd, "@UnitMeas", recipeItem.UnitMeas);

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
                cmd.CommandText = "DELETE FROM RecipeItem WHERE Id = @Id";
                DbUtils.AddParameter(cmd, "@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}