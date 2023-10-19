using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumManager.Console
{
    internal class Principal
    {
       public Principal()
        {
            var opcion = string.Empty;
            bool opcionValida = default;
            System.Console.Clear();
            System.Console.WriteLine("************************************************************************");
            System.Console.WriteLine("*                          -SCRUM MANAGER-                             *");
            System.Console.WriteLine("************************************************************************\n");
            System.Console.WriteLine();
            System.Console.WriteLine("Manú");
            System.Console.WriteLine();
            System.Console.WriteLine("1. REGISTRAR PROYECTO");
            System.Console.WriteLine("2. REGISTRAR SPRINT");
            System.Console.WriteLine("3. REPORTERIA DE CALCULOS");
            System.Console.WriteLine("4. REGISTRAR USUARIO");
            System.Console.WriteLine();
            System.Console.WriteLine("9. SALIR");
            System.Console.WriteLine("\n\nDigite el número de la opción a ejecutar: ");

           
            
            do
            {
                opcion = System.Console.ReadLine();
                switch (opcion.Trim())
                {
                    case "1":
                        System.Console.Clear();
                        opcionValida = true;
                        var registrarProyecto = new RegistrarProyecto();
                        break;
                    case "2":
                        System.Console.Clear();
                        opcionValida = true;
                        var registrarSprint = new RegistrarSprint();
                        break;
                    case "3":
                        System.Console.Clear();
                        opcionValida = true;
                        var registrarUsuario = new RegistrarUsuario();
                        break;
                    case "9":
                        System.Console.WriteLine("Presione ENTER para salir");
                        System.Console.ReadLine();
                        System.Environment.Exit(0);
                        break;
                    default:
                        System.Console.WriteLine("Opcion Invalida!");
                        opcionValida = true;
                        break;
                }
                
            } while (!opcionValida);
        }
    }
}
