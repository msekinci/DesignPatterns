namespace DesignPatterns.Strategy.Models
{
    public class Settings
    {
        public static string ClaimDatabaseType = "database_type";

        public EDatabaseType DatabaseType;

        public EDatabaseType GetDefaultDatabaseType => EDatabaseType.SqlServer;
    }
}
