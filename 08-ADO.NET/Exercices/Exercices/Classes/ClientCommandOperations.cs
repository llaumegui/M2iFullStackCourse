/*using Microsoft.Data.SqlClient;

namespace Exercices.Classes;

public struct Client(
    string firstName,
    string lastName,
    string adress,
    string postalCode,
    string city,
    string phoneNumber,
    int id = -1);

public struct Command(int clientId, DateTime date, decimal cost, int id = -1);

public class ClientCommandOperations
{
    private static string connectionString =
        "Data Source=(localdb)\\DemoAdonet; Database=ContactDB; Integrated Security=true";

    #region Clients
    public static List<Client> GetClients()
    {
        List<Client> clients = new();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "";
            query = "SELECT * FROM [clients]";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new Client(reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(1)));
            }
        }

        return clients;
    }

    public static Client GetClient(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM [student] WHERE id=@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Client(reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                    reader.GetInt32(1));
            }

            return new Client();
        }
    }

    public static bool EditClient(Client client)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE [clients] " +
                           "SET first_name=@first_name," +
                           "last_name=@last_name," +
                           "adress = @adress," +
                           "postal_code=@postal_code," +
                           "city=@city," +
                           "telephone=@telephone " +
                           "WHERE id = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", client.id);
            command.Parameters.AddWithValue("@first_name", client.firstName);
            command.Parameters.AddWithValue("@last_name", client.lastName);
            command.Parameters.AddWithValue("@adress", client.adress);
            command.Parameters.AddWithValue("@postal_code", client.postalCode);
            command.Parameters.AddWithValue("@city", client.city);
            command.Parameters.AddWithValue("@telephone", client.phoneNumber);
            return command.ExecuteNonQuery() > 0;
        }
    }
    #endregion

    #region Commands
    #endregion
}*/