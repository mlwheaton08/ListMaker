using ListMaker.Models;
using ListMaker.Utils;

namespace ListMaker.Respositories;

public class RecipeRepository : BaseRepository, IRecipeRepository
{
    public RecipeRepository(IConfiguration configuration) : base(configuration) { }

    public List<Recipe> GetAll(int? userId, bool listItems = false)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                var sql = @"SELECT
	                            r.Id,
	                            r.UserId,
	                            r.[Name],
	                            r.Notes,
	                            r.DateCreated";

                if (listItems)
                {
                    sql += @",
                            ri.Id as RecipeItemId,
	                        ri.Quantity as RecipeItemQuantity,
                            ri.UnitMeas as RecipeItemUnitMeas,
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
                        FROM Recipe r";

                if (listItems)
                {
                    sql += @"
                            JOIN RecipeItem ri
	                            ON r.Id = ri.RecipeId
                            JOIN Item i
	                            ON i.Id = ri.ItemId
                            JOIN StoreSection ss
	                            ON i.StoreSectionId = ss.Id";
                }

                if (userId.HasValue)
                {
                    sql += $" WHERE r.UserId = {userId}";
                }

                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();

                var recipes = new List<Recipe>();
                while (reader.Read())
                {
                    var recipeId = DbUtils.GetInt(reader, "Id");
                    var existingRecipe = recipes.FirstOrDefault(r => r.Id == recipeId);

                    if (existingRecipe == null)
                    {
                        existingRecipe = new Recipe()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                            RecipeItems = new List<RecipeItem>()
                        };

                        recipes.Add(existingRecipe);
                    }

                    if (listItems)
                    {
                        if (DbUtils.IsNotDbNull(reader, "RecipeItemId"))
                        {
                            existingRecipe.RecipeItems.Add(new RecipeItem()
                            {
                                Id = DbUtils.GetInt(reader, "RecipeItemId"),
                                RecipeId = DbUtils.GetInt(reader, "Id"),
                                ItemId = DbUtils.GetInt(reader, "ItemId"),
                                Quantity = DbUtils.GetDouble(reader, "RecipeItemQuantity"),
                                UnitMeas = DbUtils.GetString(reader, "RecipeItemUnitMeas"),
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
                return recipes;
            }
        }
    }
}