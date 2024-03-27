namespace Api.Infrastructure
{
    using System.Data.Common;
    using System.Data.SqlClient;

    public class Database
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            // var connectionString = "Data Source=LOCALHOST;Initial Catalog=BrainWare;Integrated Security=SSPI";
            var mdf = @"D:\BrainWere\BrainWare.mdf";
            //var connectionString = $"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename={mdf}";
            var connectionString = $"Data Source=DESKTOP-ADU4H54\\MSSQL2022;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename={mdf}";

            _connection = new SqlConnection(connectionString);

            _connection.Open();
        }

        public DbDataReader ExecuteReader(string query)
        {
           

            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteNonQuery();
        }

    }
}