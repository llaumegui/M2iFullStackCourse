/*using Exercices.Classes;
using Microsoft.Data.SqlClient;

/*using (SqlConnection connection = new SqlConnection(connectionstring))
{
    connection.Open();

    string query = "";
    SqlCommand command = new SqlCommand(query, connection);
    command.ExecuteNonQuery();
}#1#

Menu mainMenu = new Menu("Menu principal", new Dictionary<string, ConditionValue>
{
    { "1", new ConditionValue("Afficher tous les étudiants") },
    { "2", new ConditionValue("Afficher les étudiants d'une classe") },
    { "3", new ConditionValue("Ajouter un étudiant") },
    { "4", new ConditionValue("Mettre à jour un étudiant") },
    { "5", new ConditionValue("Supprimer un étudiant") },
    { "0", new ConditionValue("Quitter") },
});
string menuKey = "";
while (true)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"=== {mainMenu.Title} ===");

        foreach (KeyValuePair<string, ConditionValue> kvp in mainMenu.MenuItems)
            Console.WriteLine($"{kvp.Key}. {kvp.Value}");

        Console.Write("Votre choix: ");
        if (mainMenu.TryKey(Console.ReadLine(), out menuKey))
            break;
    }

    Console.Clear();

    if (menuKey == "0")
        break;


    string firstName = "";
    string lastName = "";
    string studentIdStr = "";
    int? studentId = null;
    int? classNbr = null;
    bool operationSuccess = false;

    switch (menuKey)
    {
        case "1":
        case "2":
            if (menuKey == "2")
            {
                Console.Write("Selectionner une classe: ");
                classNbr = Convert.ToInt32(Console.ReadLine());
            }

            foreach (Student student in Student.GetStudents(classNbr))
                Console.WriteLine(student);
            break;
        case "3":
        case "4":
            if (menuKey == "4")
            {
                Console.Write("Selectionner l'id de l'élève\n(ne rien mettre pour chercher par son prénom): ");
                studentIdStr = Console.ReadLine() ?? string.Empty;
                studentId = studentIdStr == string.Empty ? null : Convert.ToInt32(studentIdStr);
            }

            if (studentId == null)
            {
                Console.Write($"Prénom de l'élève à {(menuKey == "3" ? "ajouter" : "chercher")}: ");
                firstName = Console.ReadLine();
                Console.Write($"Nom de l'élève à {(menuKey == "3" ? "ajouter" : "chercher")}: ");
                lastName = Console.ReadLine();
            }

            Console.Write(
                $"Classe à {(menuKey == "3" ? "ajouter" : "modifier\n(ne rien mettre pour ne pas modifier)")}: ");
            string gradeStr = Console.ReadLine() ?? string.Empty;
            classNbr = gradeStr == string.Empty ? null : int.Parse(gradeStr);
            Console.Write(
                $"(YYYY-MM-DD) | Date d'obtention du diplôme à {(menuKey == "3" ? "ajouter" : "modifier\n(ne rien mettre pour ne pas modifier)")}: ");
            string dateStr = Console.ReadLine() ?? string.Empty;
            DateTime? date = dateStr == string.Empty ? null : DateTime.Parse(dateStr);
            if (menuKey == "3")
                operationSuccess = Student.AddStudent(new Student(firstName, lastName, classNbr, date));
            else
            {
                if (studentId == null)
                    operationSuccess = Student.EditStudent(new Student(firstName, lastName, classNbr, date));
                else
                    operationSuccess =
                        Student.EditStudent((int)studentId, new Student(firstName, lastName, classNbr, date));
            }

            Console.WriteLine(operationSuccess ? "Opération Réussie" : "Opération Échouée");
            break;

        case "5":

            Console.Write("Selectionner l'id de l'élève\n(ne rien mettre pour chercher par son prénom): ");
            studentIdStr = Console.ReadLine() ?? string.Empty;
            studentId = studentIdStr != string.Empty ? Convert.ToInt32(studentIdStr) : 0;

            if (studentId == null)
            {
                Console.Write($"Prénom de l'élève à {(menuKey == "3" ? "Supprimer" : "chercher")}: ");
                firstName = Console.ReadLine();
                Console.Write($"Nom de l'élève à {(menuKey == "3" ? "Supprimer" : "chercher")}: ");
                lastName = Console.ReadLine();

                operationSuccess =
                    Student.RemoveStudent(new Student(firstName, lastName, 0, DateTime.Parse("1999-04-05")));
            }
            else
                operationSuccess = Student.RemoveStudent((int)studentId);

            Console.WriteLine(operationSuccess ? "Opération Réussie" : "Opération Échouée");
            break;
    }

    Console.Write("Appuyez sur Entrée pour continuer");
    Console.ReadLine();
}*/