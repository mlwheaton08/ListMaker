using ListMaker.Models;
using ListMaker.Utils;

namespace ListMaker.Respositories;

public class StoreSectionRepository : BaseRepository, IStoreSectionRepository
{
    public StoreSectionRepository(IConfiguration configuration) : base(configuration) { }

    public List<StoreSection> GetAll()
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT
	                                    Id,
	                                    [Name],
	                                    OrderPosition
                                    FROM StoreSection";

                var reader = cmd.ExecuteReader();
                var storeSections = new List<StoreSection>();

                while (reader.Read())
                {
                    var storeSection = new StoreSection()
                    {
                        Id = DbUtils.GetInt(reader, "Id"),
                        Name = DbUtils.GetString(reader, "Name"),
                        OrderPosition = DbUtils.GetInt(reader, "OrderPosition")
                    };

                    storeSections.Add(storeSection);
                }

                reader.Close();
                return storeSections;
            }
        }
    }
}