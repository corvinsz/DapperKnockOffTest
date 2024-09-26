using System.Data.SqlClient;

namespace DapperKnockOffTest;

public class Database
{
    private readonly SqlConnection _connection;
    public Database(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public string ConnectionString => _connection.ConnectionString;

    public IEnumerable<T> GetData<T>(string query, params SqlParameter[] sqlParameters) where T : class, new()
    {
        _connection.Open();
        SqlCommand cmd = new SqlCommand(query, _connection);

        cmd.Parameters.Clear();
        if (sqlParameters is not null)
        {
            foreach (SqlParameter parameter in sqlParameters)
            {
                cmd.Parameters.Add(parameter);
            }
        }

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            yield return reader.ConvertToObject<T>();
        }
        _connection.Close();
    }
}
