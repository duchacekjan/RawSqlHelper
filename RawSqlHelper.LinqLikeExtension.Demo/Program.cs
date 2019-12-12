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
            var join = LinqLikeBuilder.Select("Count(*)")
                .From("test", "t1")
                .Join("test2", "t2");
            var sql = join.On("t1.Id = t2.Id")
                .Where("t2.Id > 1")
                .SqlQuery;
            var result = dbContext.ExecuteScalar(sql);
            Console.WriteLine($"Result = {result}");
        }
    }
}
