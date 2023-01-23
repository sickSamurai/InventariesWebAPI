namespace InventariesWebAPI.Database {
  
  using Microsoft.SqlServer.Management.Smo;
  using Microsoft.SqlServer.Management.Common;
  using System.IO;
  using Microsoft.Data.SqlClient;

  public class DatabaseLoader {
    private IConfiguration Configuration;
    
    public DatabaseLoader(IConfiguration configuration) {
      this.Configuration = configuration;
    }
    
    public void LoadScript() {

      var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\InventariesDb.sql"));

      string? sqlConnectionString = Configuration.GetConnectionString("SqlServer");

      string script = File.ReadAllText(path);

      var connection = new SqlConnection(sqlConnectionString);
      
      Server server = new Server(new ServerConnection(connection));           
      
      server.ConnectionContext.ExecuteNonQuery(script);
    }
  }
}
