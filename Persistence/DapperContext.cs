using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Persistence;
public class DapperContext {
    private readonly IConfiguration _configuration;
    private readonly string _smartSlotConnection;
    private readonly int _timeout;
    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _smartSlotConnection = _configuration.GetConnectionString("SmartSlotDWConnection") ?? string.Empty;
        _timeout = int.Parse(_configuration["Timeout"]);
    }
    public IDbConnection CreateSmartSlotConnection() {
        var connectionStringBuilder = new SqlConnectionStringBuilder(_smartSlotConnection);
        connectionStringBuilder.ConnectTimeout = _timeout;
        var connection = new SqlConnection(connectionStringBuilder.ConnectionString);
        connection.Open();
        return connection;
    }
}
