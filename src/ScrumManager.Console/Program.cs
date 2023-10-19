using ScrumManager.Core.Entities;
using System.Data;
using System.IO;
using ScrumManager.Console;


string usuario = "", contrasena = "";
Console.WriteLine("************************************************************************");
Console.WriteLine("*                          -SCRUM MANAGER-                             *");
Console.WriteLine("************************************************************************");
Console.Write("\nIntroduzca su Usuario: ");
usuario = Console.ReadLine();
Console.Write("\nContraseña: ");
contrasena = Console.ReadLine();

Login login = new Login(usuario, contrasena);


//ShowMenu();

//static void ShowMenu()
//{
//    int choice;

//    do
//    {
//        Console.Clear();

//        Console.WriteLine("Scrum Manager Menu");
//        Console.WriteLine("1. Add Sprint");
//        Console.WriteLine("2. Sprint List");
//        Console.WriteLine("3. Exit");
//        Console.Write("Enter your choice: ");

//        if (int.TryParse(Console.ReadLine(), out choice))
//        {
//            switch (choice)
//            {
//                case 1:
//                    AddSprint();
//                    break;
//                case 2:
//                    ShowSprints();
//                    break;
//                case 3:
//                    Console.WriteLine("Exiting the program...");
//                    break;
//                default:
//                    Console.WriteLine("Invalid choice. Please enter a valid option.");
//                    break;
//            }
//        }
//        else
//        {
//            Console.WriteLine("Invalid input. Please enter a valid option.");
//        }

//    } while (choice != 3);
//}

//static void AddSprint()
//{
//    var sprintService = new SprintServices();

//    Console.Write("Nombre: ");
//    var name = Console.ReadLine();

//    Console.Write("Cantidad de duracion: ");
//    var durationQuantity = int.Parse(Console.ReadLine());

//    Console.Write("Unidad de duracion: ");
//    var durationUnit = Console.ReadLine();

//    Console.Write("Regular [Y/N]: ");
//    var regular = Console.ReadLine() == "Y";

//    Console.Write("Puntos: ");
//    var points = int.Parse(Console.ReadLine());

//    Console.Write("Desde: ");
//    var startDate = DateTime.Parse(Console.ReadLine());

//    Console.Write("Hasta : ");
//    var endDate = DateTime.Parse(Console.ReadLine());

//    Console.Write("Puntos terminados: ");
//    var finalPoints = int.Parse(Console.ReadLine());

//    Console.Write("Desarrolladores: ");
//    var developers = Console.ReadLine();

//    var newSprint = new Sprint
//    {
//        Name = name,
//        DurationQuantity = durationQuantity,
//        DurationUnit = durationUnit,
//        Regular = regular,
//        Points = points,
//        StartDate = startDate,
//        EndDate = endDate,
//        FinalPoints = finalPoints,
//        Developers = developers
//    };

//    sprintService.Add(newSprint);
//}

//static void ShowSprints()
//{
//    var sprintService = new SprintServices();
//    Console.WriteLine("Nombre | Duracion | Regular | Puntos | Desde | Hasta | Puntos terminados | Desarrolladores");


//}