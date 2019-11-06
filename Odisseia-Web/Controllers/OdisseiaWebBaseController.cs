using Controllers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OdisseiaWeb.DAL;
using System.Collections.Generic;
using System.Net.Http;
using Models.Relatorio;
using System.Threading.Tasks;
using System.Web;
using System;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Reflection;

namespace Controllers
{
    public abstract class OdisseiaWebBaseController : Controller
    {
        public abstract Task<IActionResult> Index();

        protected async Task<IActionResult> _treatException(Exception e, HttpContext context)
        {
            if (e is UserNotLoggedException)
            {
                TempData["status"] = "danger";
                TempData["message"] = e.Message;
                return RedirectToAction("Index", "Usuario");
            }
            else if (e is HttpRequestException)
            {
                TempData["status"] = "danger";
                TempData["message"] = e.Message;
                return await Index();
            }
            else
            {
                TempData["status"] = "danger";
                TempData["message"] = "Erro inesperado, por favor tente mais tarde";
                UserSessionController.CleanUser(context);
                return RedirectToAction("Index", "Usuario");
            }
        }

        protected void _verifyUser(HttpContext context)
        {
            UserSessionController.VerifyUser(context);
        }

        protected virtual void _httpRequestExceptionThrower(HttpStatusCode status)
        {
            switch (status)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.BadRequest:
                    throw new HttpRequestException("Erro ao tentar executar a ação, por favor tente mais tarde");
                case HttpStatusCode.NotFound:
                    throw new HttpRequestException("Página não encontrada ou não existe");
                case HttpStatusCode.InternalServerError:
                    throw new HttpRequestException("Estamos com problemas em estabelecer uma conexão, por favor tente mais tarde");
                default:
                    throw new HttpRequestException("Problema inesperado, por favor tente mais tarde");
            }
        }

        protected async Task<T> _dataFilter<T>(HttpResponseMessage data) where T : class
        {
            _httpRequestExceptionThrower(data.StatusCode);
            data.EnsureSuccessStatusCode();
            T result = JsonConvert.DeserializeObject<T>(await data.Content.ReadAsStringAsync());
            if(result == null)
            {
                throw new HttpRequestException("Erro ao tentar executar a ação, por favor tente mais tarde");
            }
            return result;
        }

        protected async Task<string> _dataFilter(HttpResponseMessage data)
        {
            _httpRequestExceptionThrower(data.StatusCode);
            data.EnsureSuccessStatusCode();
            string result = JsonConvert.DeserializeObject(await data.Content.ReadAsStringAsync()).ToString();
            if (result == null)
            {
                throw new HttpRequestException("Erro ao tentar executar a ação, por favor tente mais tarde");
            }
            return result;
        }
    }
}

