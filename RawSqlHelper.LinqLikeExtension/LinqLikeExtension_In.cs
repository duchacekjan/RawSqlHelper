using RawSqlHelper.LinqLikeExtension.Enhancers;

namespace RawSqlHelper.LinqLikeExtension
{
    public partial class LinqLikeExtension
    {
        public static InBuilder Fields(this SqlQueryBuilder builder, params string[] fields)
        {
            return new InBuilder(builder, fields);
        }

        public static void Test()
        {
            var sb = SqlQueryBuilder.Create()
                .Select("typ, rok, cislo")
                .From("vz")
                .OuterJoin("ptpvz", "p").On("p.a=x.b and p.b=x")
                .Where("1=1 and")
                .Fields("typ, rok, cislo")
                .InValues(
                    new object[] { "VZM", 2019, 123 },
                    new object[] { "VZM", 2019, 124 },
                    new object[] { "VZM", 2019, 125 },
                    new object[] { "VZM", 2019, 126 },
                    new object[] { "VZM", 2019, 127 })
                .ToSqlQueryBuilder().SqlQuery;
        }
    }
}
