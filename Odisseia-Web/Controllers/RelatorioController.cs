using Controllers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OdisseiaWeb.DAL;
using System.Collections.Generic;
using System.Net.Http;
using Models.Relatorio;
using System.Threading.Tasks;

namespace Controllers
{
    public class RelatorioController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                UserSessionController.ValidateUser(HttpContext);

                HttpResponseMessage result = await DALApi.GET(ApiCommands.RelatorioBasico);

                if (!result.IsSuccessStatusCode)
                {
                    ViewData["error"] = true;
                    ViewData["errorMessage"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                result.EnsureSuccessStatusCode();

                IList<RelatorioListarDTO> relatorio = JsonConvert.DeserializeObject<IList<RelatorioListarDTO>>(await result.Content.ReadAsStringAsync());

                return View("_View_Relatorio_Turma", relatorio);
            }
            catch (UserNotLoggedException)
            {
                return RedirectToAction("Logout", "Usuario");
            }
        }
    }
}
