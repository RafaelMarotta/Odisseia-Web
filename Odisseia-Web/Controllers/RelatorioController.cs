﻿using Controllers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Models.Missao;
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
                    ViewData["error"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                result.EnsureSuccessStatusCode();

                IList<RelatorioListDTO> relatorio = JsonConvert.DeserializeObject<IList<RelatorioListDTO>>(await result.Content.ReadAsStringAsync());

                return View("_View_Relatorio_Turma", relatorio);
            }
            catch (UsetNotLoggedException ex)
            {
                return RedirectToAction("Logout", "Usuario");
            }
        }
    }
}