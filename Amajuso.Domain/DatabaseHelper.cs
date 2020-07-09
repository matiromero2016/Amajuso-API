namespace Amajuso.Domain
{
    public class DatabaseHelper
    {
        public static void Configure(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public static string ConnectionString { get; private set; }
    }
}