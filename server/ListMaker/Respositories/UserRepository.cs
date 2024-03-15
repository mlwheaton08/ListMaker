using ListMaker.Models;
using ListMaker.Utils;

namespace ListMaker.Respositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IConfiguration configuration) : base(configuration) { }

    public User GetByFirebaseId(string firebaseId)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT
	                                    Id,
	                                    FirebaseId,
	                                    FirstName,
	                                    LastName,
	                                    FullName,
	                                    Email,
	                                    RegisterDate
                                    FROM [User]
                                    WHERE FirebaseId = @FirebaseId";

                DbUtils.AddParameter(cmd, "@FirebaseId", firebaseId);

                var reader = cmd.ExecuteReader();

                User user = null;
                if (reader.Read())
                {
                    user = new User()
                    {
                        Id = DbUtils.GetInt(reader, "Id"),
                        FirebaseId = firebaseId,
                        FirstName = DbUtils.GetString(reader, "FirstName"),
                        LastName = DbUtils.GetString(reader, "LastName"),
                        FullName = DbUtils.GetString(reader, "FullName"),
                        Email = DbUtils.GetString(reader, "Email"),
                        RegisterDate = DbUtils.GetDateTime(reader, "RegisterDate")
                    };
                }

                reader.Close();
                return user;
            }
        }
    }
}