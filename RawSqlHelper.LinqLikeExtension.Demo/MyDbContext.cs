using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace RawSqlHelper.LinqLikeExtension.Demo
{
    public class MyDbContext
    {
        private readonly SqliteConnection m_connection;

        public MyDbContext(string connectionString)
        {
            m_connection = new SqliteConnection(connectionString);
        }

        public void Open() => m_connection.Open();

        public void Close() => m_connection.Close();

        public void CreateDatabase()
        {
            ExecuteNonQuery("CREATE TABLE test (Id int PRIMARY KEY, Name varchar(255))");
            ExecuteNonQuery("INSERT INTO test(Id, Name) VALUES (1, 'test')");
            ExecuteNonQuery("INSERT INTO test(Id, Name) VALUES (2, 'test2')");
            ExecuteNonQuery("INSERT INTO test(Id, Name) VALUES (3, 'test3')");
            ExecuteNonQuery("CREATE TABLE test2 (Id int PRIMARY KEY, Address varchar(255))");
            ExecuteNonQuery("INSERT INTO test2(Id, Address) VALUES (1, 'address')");
            ExecuteNonQuery("INSERT INTO test2(Id, Address) VALUES (2, 'address2')");
            ExecuteNonQuery("INSERT INTO test2(Id, Address) VALUES (4, 'address4')");
            Console.WriteLine("DatabaseCreated\r\n");
        }

        public int ExecuteNonQuery(string query)
        {
            using var cmd = CreateCmd(query);
            return cmd.ExecuteNonQuery();
        }

        public object ExecuteScalar(string query)
        {
            using var cmd = CreateCmd(query);
            return cmd.ExecuteScalar();
        }

        public void ExecuteQuery(string query)
        {
            using var cmd = CreateCmd(query);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var row = new List<string>(reader.FieldCount);
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    row.Add($"{reader[i]}");
                }

                Console.WriteLine(string.Join("\t", row));
            }
        }

        private SqliteCommand CreateCmd(string query)
        {
            var result = new SqliteCommand(query, m_connection);
            Log(query);
            return result;
        }

        private void Log(string sql)
        {
            Console.WriteLine($"SQL: {sql}");
        }
    }
}
