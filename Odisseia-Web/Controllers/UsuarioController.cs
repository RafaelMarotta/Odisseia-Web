using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Usuario;
using OdisseiaWeb.DAL;
using Newtonsoft.Json;
using Models.Usuario.Enum;

namespace Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View("_View_Usuario_Login");
        }

        [HttpPost]
        [ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginConfirmed(IFormCollection collection)
        {
            UsuarioLoginDTO usuarioLogin = new UsuarioLoginDTO
            {
                login = collection["UsuarioLogin"],
                senha = collection["UsuarioSenha"]
            };

            HttpResponseMessage result = await DALApi.POST(ApiCommands.LoginUsuario, usuarioLogin);

            if (!result.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            result.EnsureSuccessStatusCode();

            UsuarioDTO usuario = JsonConvert.DeserializeObject<UsuarioDTO>(await result.Content.ReadAsStringAsync());

            if (usuario == null)
            {
                return BadRequest();
            }

            if (usuario.tipo == TipoUsuarioEnum.Aluno)
            {
                return BadRequest();
            }

            UserSessionController.SetUser(HttpContext, usuario);

            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            UserSessionController.CleanUser(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}