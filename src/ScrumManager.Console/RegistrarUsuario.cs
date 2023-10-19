using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumManager.Console
{
    internal class RegistrarUsuario
    {
        DataTable dtUsuario;
        string opcion = "0";
        string email = "", nombre = "", apellido = "", contrasena = "";
        public RegistrarUsuario()
        {
            dtUsuario = new DataTable();
            dtUsuario.Columns.Add("Email");
            dtUsuario.Columns.Add("Nombre");
            dtUsuario.Columns.Add("Apellidos");
            dtUsuario.Columns.Add("Contrasena");

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
            System.Console.WriteLine("                          REGISTRAR USUARIO ");
            System.Console.WriteLine("\nSELECCIONE LA OPCION A EJECUTAR: ");
            System.Console.WriteLine("1. Agregar Usuario");
            System.Console.WriteLine("2. Modificar Usuario");
            System.Console.WriteLine("3. Eliminar Usuario");
            System.Console.WriteLine("4. Ver Usuarios\n");
            bool opcionValida = false;
            do
            {
                opcion = System.Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        System.Console.Clear();
                        AgregarUsuario();
                        opcionValida = true;
                        break;
                    case "2":
                        System.Console.Clear();
                        ModificarUsuario();
                        opcionValida = true;
                        break;
                    case "3":
                        System.Console.Clear();
                        EliminarUsuario();
                        opcionValida = true;
                        break;
                    case "4":
                        System.Console.Clear();
                        VerUsuarios();
                        opcionValida = true;
                        break;
                    default:
                        opcionValida = false;
                        System.Console.WriteLine("Opcion Invalida");
                        break;
                }
            } while (opcionValida == false);
        }

        public void VerUsuarios()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          USUARIOS REGISTRADOS ");

            if (dtUsuario.Rows.Count > 0)
            {

                for (int i = 0; i < dtUsuario.Rows.Count; i++)
                {
                    System.Console.WriteLine(dtUsuario.Rows[i]["Email"].ToString().PadRight(25) + "|" +
                        dtUsuario.Rows[i]["Nombre"].ToString() + "|" +
                        dtUsuario.Rows[i]["Apellidos"].ToString() );

                }

                System.Console.WriteLine("\n\nEnter para volver al menu anterior...");
                System.Console.ReadLine();
                CargarMenu();
            }
            else
            {
                System.Console.WriteLine("No hay usuarios registrados");
                System.Console.ReadLine();
                CargarMenu();
            }
            
        }
        public void AgregarUsuario()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          NUEVO USUARIO ");
            System.Console.Write("Email: ");
            email = System.Console.ReadLine();
            System.Console.Write("Nombre: ");
            nombre = System.Console.ReadLine();
            System.Console.Write("Apellido: ");
            apellido = System.Console.ReadLine();
            System.Console.Write("Contrasena: ");
            contrasena = System.Console.ReadLine();
            DataRow row = dtUsuario.NewRow();
            row["Email"] = email;
            row["Nombre"] = nombre;
            row["Apellidos"] = apellido;
            row["Contrasena"] = contrasena;
            dtUsuario.Rows.Add(row);
            System.Console.WriteLine("\n\nUSUARIO REGISTRADO CORRECTAMENTE!\n Enter para continuar...");
            System.Console.ReadLine();
            CargarMenu();

        }
        public void ModificarUsuario()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          MODIFICAR USUARIO ");
            if (dtUsuario.Rows.Count > 0)
            {

                for (int i = 0; i < dtUsuario.Rows.Count; i++)
                {
                    System.Console.WriteLine((i+1).ToString() + "- " +dtUsuario.Rows[i]["Email"].ToString().PadRight(25) + "|" +
                        dtUsuario.Rows[i]["Nombre"].ToString() + "|" +
                        dtUsuario.Rows[i]["Apellidos"].ToString());

                }
                
            }
            bool numeroValido = false;
            string numero = "0";
            do
            {
                System.Console.WriteLine("\nSELECCIONE EL NUMERO DEL USUARIO A MODIFICAR ");
                numero = System.Console.ReadLine();
                try
                {
                    int index = Convert.ToInt32(numero) - 1;
                    if (index >= 0 && index < dtUsuario.Rows.Count)
                    {
                        numeroValido = true;
                        System.Console.WriteLine(dtUsuario.Rows[index]["Email"].ToString().PadRight(25) + "|" +
                      dtUsuario.Rows[index]["Nombre"].ToString() + "|" +
                      dtUsuario.Rows[index]["Apellidos"].ToString());

                        System.Console.Write("Nuevo Nombre: ");
                        nombre = System.Console.ReadLine();
                        System.Console.Write("Nuevo Apellido: ");
                        apellido = System.Console.ReadLine();
                        System.Console.Write("Nueva Contrasena: ");
                        contrasena = System.Console.ReadLine();

                        dtUsuario.Rows[index]["Nombre"] = nombre;
                        dtUsuario.Rows[index]["Apellidos"] = apellido;
                        dtUsuario.Rows[index]["Contrasena"] = contrasena;
                        System.Console.WriteLine("\n\nUSUARIO ACTUALIZADO CORRECTAMENTE!\n Enter para continuar...");
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
        public void EliminarUsuario()
        {
            CargarEncabezado();
            System.Console.WriteLine("                          ELIMINAR USUARIO ");
            if (dtUsuario.Rows.Count > 0)
            {

                for (int i = 0; i < dtUsuario.Rows.Count; i++)
                {
                    System.Console.WriteLine((i + 1).ToString() + "- " + dtUsuario.Rows[i]["Email"].ToString().PadRight(25) + "|" +
                        dtUsuario.Rows[i]["Nombre"].ToString() + "|" +
                        dtUsuario.Rows[i]["Apellidos"].ToString());

                }

            }
            bool numeroValido = false;
            string numero = "0";
            do
            {
                System.Console.WriteLine("\nSELECCIONE EL NUMERO DEL USUARIO A ELIMINAR ");
                numero = System.Console.ReadLine();
                try
                {
                    int index = Convert.ToInt32(numero) - 1;
                    if (index >= 0 && index < dtUsuario.Rows.Count)
                    {
                        numeroValido = true;
                        System.Console.WriteLine(dtUsuario.Rows[index]["Email"].ToString().PadRight(25) + "|" +
                      dtUsuario.Rows[index]["Nombre"].ToString() + "|" +
                      dtUsuario.Rows[index]["Apellidos"].ToString());
                        dtUsuario.Rows[index].Delete();
                        System.Console.WriteLine("Usuario Eliminado!");
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
