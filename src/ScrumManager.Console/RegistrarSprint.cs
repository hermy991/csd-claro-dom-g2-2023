using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumManager.Console
{
    internal class RegistrarSprint
    {
        DataTable dtSprint;
        string opcion = "0";
        public RegistrarSprint()
        {
            dtSprint = new DataTable();
            dtSprint.Columns.Add("Nombre");
            dtSprint.Columns.Add("DuracionCantidad");
            dtSprint.Columns.Add("DuracionUnidad");
            dtSprint.Columns.Add("Regular");
            dtSprint.Columns.Add("Puntos");
            dtSprint.Columns.Add("Desde");
            dtSprint.Columns.Add("Hasta");
            dtSprint.Columns.Add("PuntosTerminados");
            dtSprint.Columns.Add("Desarrolladores");

            CargarMenu();
        }
        public void CargarEncabezado()
        {
            System.Console.Clear();
            System.Console.WriteLine("************************************************************************");
            System.Console.WriteLine("*                          -SCRUM MANAGER-                             *");
            System.Console.WriteLine("************************************************************************\n\n");
        }
        public void CargarMenu()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          REGISTRAR SPRINT ");
            System.Console.WriteLine("\nSELECCIONE LA OPCION A EJECUTAR: ");
            System.Console.WriteLine("1. Agregar Sprint");
            System.Console.WriteLine("2. Ver Sprints\n");
            bool opcionValida;
            do
            {
                opcion = System.Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        System.Console.Clear();
                        AgregarSprint();
                        opcionValida = true;
                        break;
                    case "2":
                        System.Console.Clear();
                        VerSprints();
                        opcionValida = true;
                        break;
                    default:
                        opcionValida = false;
                        System.Console.WriteLine("Opcion Invalida");
                        break;
                }
            } while (!opcionValida);
        }
        public void AgregarSprint()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          NUEVO SPRINT");
            System.Console.Write("Nombre: ");
            var name = System.Console.ReadLine();

            System.Console.Write("Cantidad de duracion: ");
            var durationQuantity = int.Parse(System.Console.ReadLine());

            System.Console.Write("Unidad de duracion: ");
            var durationUnit = System.Console.ReadLine();

            System.Console.Write("Regular [Y/N]: ");
            var regular = System.Console.ReadLine() == "Y";

            System.Console.Write("Puntos: ");
            var points = int.Parse(System.Console.ReadLine());

            System.Console.Write("Desde: ");
            var startDate = DateTime.Parse(System.Console.ReadLine());

            System.Console.Write("Hasta : ");
            var endDate = DateTime.Parse(System.Console.ReadLine());

            System.Console.Write("Puntos terminados: ");
            var finalPoints = int.Parse(System.Console.ReadLine());

            System.Console.Write("Desarrolladores: ");
            var developers = System.Console.ReadLine();

            DataRow row = dtSprint.NewRow();
            row["Nombre"] = name;
            row["DuracionCantidad"] = durationQuantity;
            row["DuracionUnidad"] = durationUnit;
            row["Regular"] = regular;
            row["Puntos"] = points;
            row["Desde"] = startDate;
            row["Hasta"] = endDate;
            row["PuntosTerminados"] = finalPoints;
            row["Desarrolladores"] = developers;

            dtSprint.Rows.Add(row);
            System.Console.WriteLine("\n\nSPRINT REGISTRADO CORRECTAMENTE!\n Enter para continuar...");
            System.Console.ReadLine();
            CargarMenu();
        }
        public void VerSprints()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          SPRINTS REGISTRADOS ");

            if (dtSprint.Rows.Count > 0)
            {

                for (int i = 0; i < dtSprint.Rows.Count; i++)
                {
                    System.Console.WriteLine(
                        $"{dtSprint.Rows[i]["Nombre"]} | " +
                        $"{dtSprint.Rows[i]["DuracionCantidad"]} | " +
                        $"{dtSprint.Rows[i]["DuracionUnidad"]} | " +
                        $"{dtSprint.Rows[i]["Regular"]} | " +
                        $"{dtSprint.Rows[i]["Puntos"]} | " +
                        $"{dtSprint.Rows[i]["Desde"]} | " +
                        $"{dtSprint.Rows[i]["Hasta"]} | " +
                        $"{dtSprint.Rows[i]["PuntosTerminados"]} | " +
                        $"{dtSprint.Rows[i]["Desarrolladores"]} | "
                    );

                }

                System.Console.WriteLine("\n\nEnter para volver al menu anterior...");
                System.Console.ReadLine();
                CargarMenu();
            }
            else
            {
                System.Console.WriteLine("No hay sprints registrados");
                System.Console.ReadLine();
                CargarMenu();
            }
        }
    }
}
