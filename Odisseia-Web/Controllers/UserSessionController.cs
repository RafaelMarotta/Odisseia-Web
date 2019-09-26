using Microsoft.AspNetCore.Http;
using Models.Usuario;
using Newtonsoft.Json;
using System;

namespace Controllers
{
    public static class UserSessionController
    {
        private static string _userKey = "User";

        public static void SetUser(HttpContext context, UsuarioDTO value)
        {
            value.senha = null;
            context.Session.SetString(_userKey, JsonConvert.SerializeObject(value));
        }

        public static UsuarioDTO GetUser(HttpContext context)
        {
            return JsonConvert.DeserializeObject<UsuarioDTO>(context.Session.GetString(_userKey));
        }

        public static void CleanUser(HttpContext context)
        {
            context.Session.Remove(_userKey);
        }

        public static void ValidateUser(HttpContext context)
        {
            if (GetUser(context) == null)
            {
                throw new Exception("User not logged in");
            }
        }
    }
}