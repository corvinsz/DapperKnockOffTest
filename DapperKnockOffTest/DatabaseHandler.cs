using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DapperKnockOffTest;

internal static class DatabaseHandler
{
    private const string _connectionString = @"Data Source=(localdb)\Local;Initial Catalog=TestDB;Integrated Security=True";
    private static readonly Database _db = new Database(_connectionString);

    internal static IEnumerable<Person> GetPersons()
    {
        return _db.GetData<Person>("select * from Person where ID = @ID", new System.Data.SqlClient.SqlParameter("@ID", 2));
    }

    //internal static object[] GetPersons()
    //{
    //    object[] result = new object[10];

    //    SqlConnection con = new SqlConnection(_connectionString);
    //    string query = "select * from Person";

    //    con.Open();
    //    SqlCommand cmd = new SqlCommand(query, con);
    //    var reader = cmd.ExecuteReader();
    //    while (reader.Read())
    //    {
    //        reader.GetValues(result);
    //    }
    //    return result;
    //}

}
