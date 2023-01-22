namespace InventariesWebAPI.Database {
  
  using Microsoft.SqlServer.Management.Smo;
  using Microsoft.SqlServer.Management.Common;
  using System.IO;
  using Microsoft.Data.SqlClient;

  public class ScriptLoader {
    private IConfiguration Configuration;
    
    public ScriptLoader(IConfiguration configuration) {
      this.Configuration = configuration;
    }
    
    public void LoadScript() {
      
      string? sqlConnectionString = Configuration.GetConnectionString("Inventaries");

      string script = File.ReadAllText(@"C:\InventariesDB.sql");

      var connection = new SqlConnection(sqlConnectionString);
      
      Server server = new Server(new ServerConnection(connection));

      server.ConnectionContext.ExecuteNonQuery(script);
    }
  }
}
