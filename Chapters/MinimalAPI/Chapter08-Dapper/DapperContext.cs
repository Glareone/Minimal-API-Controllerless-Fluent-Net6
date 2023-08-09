namespace Chapter08_Dapper;
using System.Data;
using Microsoft.Data.SqlClient;


public class DapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("SqlConnection");

    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

}
