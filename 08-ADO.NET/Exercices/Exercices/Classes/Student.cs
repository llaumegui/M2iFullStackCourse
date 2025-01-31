using Microsoft.Data.SqlClient;

namespace Exercices.Classes;

public struct Student
{
    private static string connectionString =
        "Data Source=(localdb)\\DemoAdonet; Database=ContactDB; Integrated Security=true";

    public string FirstName { get; }
    public string LastName { get; }
    public int ClassId { get; }
    public DateTime DateOfDiploma { get; }

    public Student(string firstName, string lastName, int? classId, DateTime? dateOfDiploma)
    {
        FirstName = firstName;
        LastName = lastName;
        ClassId = classId ?? -1;
        DateOfDiploma = dateOfDiploma ?? DateTime.Parse("9999-01-01");
    }

    public static List<Student> GetStudents(int? classNumber = null)
    {
        List<Student> students = new List<Student>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "";
            if (classNumber.HasValue)
                query = "SELECT * FROM [student] WHERE class=@classNumber";
            else
                query = "SELECT * FROM [student]";

            SqlCommand command = new SqlCommand(query, connection);
            if (classNumber.HasValue)
                command.Parameters.AddWithValue("@classNumber", classNumber);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student(reader.GetString(1), reader.GetString(2), reader.GetInt32(3),
                    reader.GetDateTime(4)));
            }
        }

        return students;
    }

    public static Student? GetStudent(int id)
    {
        Student students;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM [student] WHERE id=@id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return new Student(reader.GetString(1), reader.GetString(2), reader.GetInt32(3),
                    reader.GetDateTime(4));
            }

            return null;
        }
    }

    public static bool AddStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO [student] VALUES (@firstName, @lastName, @classId, @dateOfDiploma)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstName", student.FirstName);
            command.Parameters.AddWithValue("@lastName", student.LastName);
            command.Parameters.AddWithValue("@classId", student.ClassId);
            command.Parameters.AddWithValue("@dateOfDiploma", student.DateOfDiploma);
            if (command.ExecuteNonQuery() == 1)
                return true;
        }

        return false;
    }

    public static bool EditStudent(Student student)
    {/*
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE [student]" +
                           "SET classId = @classId, dateOfDiploma = @dateOfDiploma" +
                           " WHERE first_name = @firstName AND last_name = @lastName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@classId", student.ClassId!=-1 ? student.ClassId :);
            command.Parameters.AddWithValue("@dateOfDiploma", student.DateOfDiploma!=DateTime.Parse("9999-01-01")?student.DateOfDiploma:DBNull.Value);
            if (command.ExecuteNonQuery() > 1)
                return true;
        }
        */

        return false;
    }
    public static bool EditStudent(int id, Student student)
    {/*
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE [student]" +
                           "SET classId = @classId, dateOfDiploma = @dateOfDiploma" +
                           "WHERE id = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@classId", student.ClassId);
            command.Parameters.AddWithValue("@dateOfDiploma", student.DateOfDiploma);
            command.Parameters.AddWithValue("@id", id);
            if (command.ExecuteNonQuery() > 1)
                return true;
        }*/

        return false;
    }
    
    public static bool RemoveStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM [student]" +
                           "WHERE first_name = @firstName AND last_name = @lastName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstName", student.FirstName);
            command.Parameters.AddWithValue("@lastName", student.LastName);
            if (command.ExecuteNonQuery() > 1)
                return true;
        }

        return false;
    }
    
    public static bool RemoveStudent(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM [student]" +
                           "WHERE id = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            if (command.ExecuteNonQuery() > 1)
                return true;
        }

        return false;
    }

    public override string ToString() => "Name: " + FirstName + " " + LastName;
}