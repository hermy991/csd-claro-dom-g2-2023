using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScrumManager.Console
{
    internal class RegistrarProyecto
    {
        DataTable dtProyecto;
        string opcion = "0";
        string proyectName = "", description = "", sprintQuantity = "", devQuantity = "";
        public RegistrarProyecto()
        {
            dtProyecto = new DataTable();
            dtProyecto.Columns.Add("Nombre Proyecto");
            dtProyecto.Columns.Add("Descripción");
            dtProyecto.Columns.Add("Cantidad Sprints");
            dtProyecto.Columns.Add("Cantidad Developers");
            dtProyecto.Columns.Add("Product Owner");
            dtProyecto.Columns.Add("Scrum Master");

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
            System.Console.WriteLine("                          REGISTRAR PROYECTO ");
            System.Console.WriteLine("\nSELECCIONE LA OPCION A EJECUTAR: ");
            System.Console.WriteLine("1. Agregar Proyecto");
            System.Console.WriteLine("2. Modificar Proyecto");
            System.Console.WriteLine("3. Eliminar Proyecto");
            System.Console.WriteLine("4. Ver Proyectos\n");
            bool opcionValida = false;
            do
            {
                opcion = System.Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        System.Console.Clear();
                        AgregarProyecto();
                        opcionValida = true;
                        break;
                    case "2":
                        System.Console.Clear();
                        ModificarProyecto();
                        opcionValida = true;
                        break;
                    case "3":
                        System.Console.Clear();
                        EliminarProyecto();
                        opcionValida = true;
                        break;
                    case "4":
                        System.Console.Clear();
                        VerProyectos();
                        opcionValida = true;
                        break;
                    default:
                        opcionValida = false;
                        System.Console.WriteLine("Opcion Invalida");
                        break;
                }
            } while (opcionValida == false);
        }

        public void VerProyectos()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          PROYECTOS REGISTRADOS ");

            if (dtProyecto.Rows.Count > 0)
            {

                for (int i = 0; i < dtProyecto.Rows.Count; i++)
                {
                    System.Console.WriteLine(dtProyecto.Rows[i]["Nombre Proyecto"].ToString().PadRight(25) + "|" +
                        dtProyecto.Rows[i]["Product Owner"].ToString() + "|" +
                        dtProyecto.Rows[i]["Scrum Master"].ToString() );

                }

                System.Console.WriteLine("\n\nEnter para volver al menu anterior...");
                System.Console.ReadLine();
                CargarMenu();
            }
            else
            {
                System.Console.WriteLine("No hay proyectos registrados");
                System.Console.ReadLine();
                CargarMenu();
            }
            
        }
        public void AgregarProyecto()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          NUEVO PROYECTO ");
            System.Console.Write("Nombre Proyecto: ");
            proyectName = System.Console.ReadLine();
            System.Console.Write("Descripción: ");
            description = System.Console.ReadLine();
            System.Console.Write("Cantidad Sprints: ");
            sprintQuantity = System.Console.ReadLine();
            System.Console.Write("Cantidad Developers: ");
            devQuantity = System.Console.ReadLine();
            System.Console.Write("Product Owner: ");
            var productOwner = System.Console.ReadLine();
            System.Console.Write("Scrum Master: ");
            var scrumMaster = System.Console.ReadLine();
            DataRow row = dtProyecto.NewRow();
            row["Nombre Proyecto"] = proyectName;
            row["Descripción"] = description;
            row["Cantidad Sprints"] = sprintQuantity;
            row["Cantidad Developers"] = devQuantity;
            row["Product Owner"] = productOwner;
            row["Scrum Master"] = scrumMaster;
            dtProyecto.Rows.Add(row);
            System.Console.WriteLine("\n\nPROYECTO REGISTRADO CORRECTAMENTE!\n Enter para continuar...");
            System.Console.ReadLine();
            CargarMenu();

        }
        public void ModificarProyecto()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          MODIFICAR PROYECTO ");
            if (dtProyecto.Rows.Count > 0)
            {

                for (int i = 0; i < dtProyecto.Rows.Count; i++)
                {
                    System.Console.WriteLine((i+1).ToString() + "- " +dtProyecto.Rows[i]["Email"].ToString().PadRight(25) + "|" +
                        dtProyecto.Rows[i]["Nombre"].ToString() + "|" +
                        dtProyecto.Rows[i]["Apellidos"].ToString());

                }
                
            }
            bool numeroValido = false;
            string numero = "0";
            do
            {
                System.Console.WriteLine("\nSELECCIONE EL NUMERO DEL PROYECTO A MODIFICAR ");
                numero = System.Console.ReadLine();
                try
                {
                    int index = Convert.ToInt32(numero) - 1;
                    if (index >= 0 && index < dtProyecto.Rows.Count)
                    {
                        numeroValido = true;
                        System.Console.WriteLine(dtProyecto.Rows[index]["Nombre Proyecto"].ToString().PadRight(25) + "|" +
                            dtProyecto.Rows[index]["Product Owner"].ToString() + "|" +
                            dtProyecto.Rows[index]["Scrum Master"].ToString());


                        System.Console.Write("Descripción: ");
                        description = System.Console.ReadLine();
                        System.Console.Write("Cantidad Sprints: ");
                        sprintQuantity = System.Console.ReadLine();
                        System.Console.Write("Cantidad Developers: ");
                        devQuantity = System.Console.ReadLine();

                        dtProyecto.Rows[index]["Descripción"] = description;
                        dtProyecto.Rows[index]["Cantidad Sprints"] = sprintQuantity;
                        dtProyecto.Rows[index]["Cantidad Developers"] = devQuantity;
                        dtProyecto.Rows[index]["Product Owner"] = devQuantity;
                        dtProyecto.Rows[index]["Scrum Master"] = devQuantity;
                        System.Console.WriteLine("\n\nPROYECTO ACTUALIZADO CORRECTAMENTE!\n Enter para continuar...");
                        System.Console.ReadLine();
                        CargarMenu();
                    }
                    else
                    {
                        System.Console.WriteLine("Numero Invalido!");
                        numeroValido = false;
                        System.Console.ReadLine();
                    }
                }
                catch
                {
                    System.Console.WriteLine("Numero Invalido!");
                    numeroValido = false;
                    System.Console.ReadLine();
                }
            } while (numeroValido == false);
        }
        public void EliminarProyecto()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          ELIMINAR PROYECTO ");
            if (dtProyecto.Rows.Count > 0)
            {

                for (int i = 0; i < dtProyecto.Rows.Count; i++)
                {
                    System.Console.WriteLine(dtProyecto.Rows[i]["Nombre Proyecto"].ToString().PadRight(25) + "|" +
                        dtProyecto.Rows[i]["Product Owner"].ToString() + "|" +
                        dtProyecto.Rows[i]["Scrum Master"].ToString());

                }

            }
            bool numeroValido = false;
            string numero = "0";
            do
            {
                System.Console.WriteLine("\nSELECCIONE EL NUMERO DEL PROYECTO A ELIMINAR ");
                numero = System.Console.ReadLine();
                try
                {
                    int index = Convert.ToInt32(numero) - 1;
                    if (index >= 0 && index < dtProyecto.Rows.Count)
                    {
                        numeroValido = true;
                        System.Console.WriteLine(dtProyecto.Rows[index]["Nombre Proyecto"].ToString().PadRight(25) + "|" +
                            dtProyecto.Rows[index]["Product Owner"].ToString() + "|" +
                            dtProyecto.Rows[index]["Scrum Master"].ToString());
                        dtProyecto.Rows[index].Delete();
                        System.Console.WriteLine("Proyecto Eliminado!");
                        System.Console.ReadLine();
                        CargarMenu();
                    }
                    else
                    {
                        System.Console.WriteLine("Numero Invalido!");
                        numeroValido = false;
                        System.Console.ReadLine();
                    }
                }
                catch
                {
                    System.Console.WriteLine("Numero Invalido!");
                    numeroValido = false;
                    System.Console.ReadLine();
                }
            } while (numeroValido == false);
        }
    }
}
