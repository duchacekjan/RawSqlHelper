using System;
using System.Linq;
using RawSqlHelper.LinqLikeExtension.Enhancers;

namespace RawSqlHelper.LinqLikeExtension.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var db = args.FirstOrDefault();
                TestDB(db);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }

        private static void TestDB(string fileName)
        {
            var dataSource = string.IsNullOrEmpty(fileName)
                ? ":memory:"
                : fileName;
            var dbContext = new MyDbContext($"DataSource={dataSource}");
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
