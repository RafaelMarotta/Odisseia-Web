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
using System.Net;

namespace Controllers
{
    public class UsuarioController : OdisseiaWebBaseController
    {
        public override async Task<IActionResult> Index()
        {
            return Login();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("_View_Usuario_Login");
        }

        [HttpPost]
        [ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginConfirmed(IFormCollection collection)
        {
            try
            {
                UsuarioLoginDTO usuarioLogin = new UsuarioLoginDTO
                {
                    login = collection["UsuarioLogin"].ToString().ToLower(),
                    senha = collection["UsuarioSenha"]
                };
                
                UsuarioDTO usuario = await _dataFilter<UsuarioDTO>(await DALApi.POST(ApiCommands.LoginProfessor, usuarioLogin));
                UserSessionController.SetUser(HttpContext, usuario);
                return RedirectToAction("Index", "Relatorio");
            }
            catch(Exception e)
            {
                return await _treatException(e, HttpContext);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            UserSessionController.CleanUser(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        protected override void _httpRequestExceptionThrower(HttpStatusCode status)
        {
            switch (status)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.BadRequest:
                    throw new HttpRequestException("Erro ao tentar executar a ação, por favor tente mais tarde");
                case HttpStatusCode.NotFound:
                    throw new HttpRequestException("Login ou senha incorretos!");
                case HttpStatusCode.InternalServerError:
                    throw new HttpRequestException("Estamos com problemas em estabelecer uma conexão, por favor tente mais tarde");
                default:
                    throw new HttpRequestException("Problema inesperado, por favor tente mais tarde");
            }
        }
    }
}