using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumManager.Console
{
    internal class Login
    {
        public Login(string usuario, string contrasena)
        {
            if(usuario == "scrum" &&  contrasena =="scrum")
            {
                System.Console.Clear();
                Principal principal = new Principal();
            }
            else
            {
                System.Console.WriteLine("Usuario y Contraseña Inválidos");
            }
            System.Console.ReadLine();
        }
    }
}
