using System;
using RawSqlHelper.LinqLikeExtension.Enhancers;

namespace RawSqlHelper.LinqLikeExtension.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestDB();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }

        private static void TestDB()
        {
            var dbContext = new MyDbContext("DataSource=:memory:");
            dbContext.Open();
            dbContext.CreateDatabase();
            var sql = LinqLikeBuilder
                .Select("t1.Id as Id, t1.Name as Name, t2.Address as Address")
                .From("test", "t1")
                .Join("test2", "t2").On("t1.Id = t2.Id")
                .OrderByDesc("Id")
                .SqlQuery;
            dbContext.ExecuteQuery(sql);
            //Console.WriteLine($"Result = {result}");
        }
    }
}
