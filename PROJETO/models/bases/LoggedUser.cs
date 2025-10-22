using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.models.bases
{
    public static class LoggedUser
    {
        public static Usuarios user { get; private set; }

        public static void Login(Usuarios usuario)
        {
            user = usuario;
        }

        public static void Logout()
        {
            user = null;
        }

        public static bool IsLoggedIn()
        {
            return user != null;
        }
    }
}
