﻿using ListMaker.Models;
using ListMaker.Utils;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Security.Cryptography;

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

    public Item GetById(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT
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
	                                    ON i.StoreSectionId = ss.Id
                                    WHERE i.Id = @Id";
                DbUtils.AddParameter(cmd, "@Id", id);

                Item item = null;
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new Item()
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
                }

                reader.Close();
                return item;
            }
        }
    }

    public void Add(Item item)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO [Item]
	                                    (UserId,
	                                    StoreSectionId,
	                                    [Name],
	                                    Notes,
	                                    DateCreated)
                                    OUTPUT INSERTED.ID
                                    VALUES
	                                    (@UserId,
	                                    @StoreSectionId,
	                                    @Name,
	                                    @Notes,
	                                    @DateCreated)";

                DbUtils.AddParameter(cmd, "@UserId", item.UserId);
                DbUtils.AddParameter(cmd, "@StoreSectionId", item.StoreSectionId);
                DbUtils.AddParameter(cmd, "@Name", item.Name);
                DbUtils.AddParameter(cmd, "@Notes", item.Notes);
                DbUtils.AddParameter(cmd, "@DateCreated", item.DateCreated);

                item.Id = (int)cmd.ExecuteScalar();
            }
        }
    }

    public void Update(Item item)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Item
                                        SET
                                            UserId = @UserId,
                                            StoreSectionId = @StoreSectionId,
                                            [Name] = @Name,
                                            Notes = @Notes,
		                                    DateCreated = @DateCreated
                                    WHERE Id = @Id";
                DbUtils.AddParameter(cmd, "@Id", item.Id);
                DbUtils.AddParameter(cmd, "@UserId", item.UserId);
                DbUtils.AddParameter(cmd, "@StoreSectionId", item.StoreSectionId);
                DbUtils.AddParameter(cmd, "@Name", item.Name);
                DbUtils.AddParameter(cmd, "@Notes", item.Notes);
                DbUtils.AddParameter(cmd, "@DateCreated", item.DateCreated);

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
                cmd.CommandText = "DELETE FROM Item WHERE Id = @Id";
                DbUtils.AddParameter(cmd, "@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
