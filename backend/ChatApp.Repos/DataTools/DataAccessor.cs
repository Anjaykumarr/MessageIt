using Microsoft.Extensions.Configuration;



namespace ChatApp.Repos.DataTools;

public static class DataAccessor
{
    private static string _connectionstring;

    public static void Initialize(IConfiguration configuraton)
    {
        _connectionstring = configuraton.GetConnectionString("Database".ToString());
    }
}
