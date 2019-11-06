using Microsoft.AspNetCore.Http;
using Models.Usuario;
using Newtonsoft.Json;
using Controllers.Exceptions;
using System;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                return JsonConvert.DeserializeObject<UsuarioDTO>(context.Session.GetString(_userKey));
            }
            catch(ArgumentNullException)
            {
                throw new UserNotLoggedException("Usuário não logado ou tempo expirado");
            }
        }

        public static void CleanUser(HttpContext context)
        {
            context.Session.Remove(_userKey);
        }

        public static void VerifyUser(HttpContext context)
        {
            GetUser(context);
        }
    }
}