using Microsoft.Data.SqlClient;

string connectionstring = "Data Source=(localdb)\\DemoAdonet; Database=ContactDB; Integrated Security=true";

using (SqlConnection connection = new SqlConnection(connectionstring))
{
    connection.Open();
    
    string query = "INSERT INTO test(name) VALUES(@newName)";
    SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@newName", "John Doe");
    command.ExecuteNonQuery();
}