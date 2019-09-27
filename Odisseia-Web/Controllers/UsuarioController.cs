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
        public async Task<IActionResult> LoginWrong(){
            ViewData["error"] = "Login ou senha inválidos ! ";
            return await Task.Run(() => View("_View_Usuario_Login"));
        }

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
                login = collection["UsuarioLogin"].ToString().ToLower(),
                senha = collection["UsuarioSenha"]
            };

            HttpResponseMessage result = await DALApi.POST(ApiCommands.LoginProfessor, usuarioLogin);

            if (!result.IsSuccessStatusCode)
            {
                return RedirectToAction("LoginWrong","Usuario");
            }

            result.EnsureSuccessStatusCode();

            UsuarioDTO usuario = JsonConvert.DeserializeObject<UsuarioDTO>(await result.Content.ReadAsStringAsync());

            if (usuario == null)
            {
                return RedirectToAction("LoginWrong","Usuario");
            }

            UserSessionController.SetUser(HttpContext, usuario);

            return RedirectToAction("Index", "Missao");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            UserSessionController.CleanUser(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}