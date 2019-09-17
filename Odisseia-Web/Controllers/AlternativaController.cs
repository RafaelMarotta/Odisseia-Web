using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdisseiaWeb.Models;
using OdisseiaWeb.DAL;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace OdisseiaWeb.Controllers
{
    public class AlternativaController : Controller
    {
        public AlternativaController() { }

        [HttpPost]
        public async Task<IActionResult> Listar(IEnumerable<Alternativa> alternativas)
        {
            return View(alternativas);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int questaoId)
        {
            var result = DALApi.POST(ApiCommands.NotImplementedCommand/*CadastarAlternativa*/, questaoId);
            if (result != null)
            {
                return RedirectToAction("Listar", "Questao");
            }
            throw new Exception("No result");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int altId, int altFkQuestao, string altTexto, bool altCorreto)
        {
            Alternativa value = new Alternativa
            {
                Id = altId,
                FkQuestao = altFkQuestao,
                Texto = altTexto,
                Correto = altCorreto
            };
            var result = DALApi.PUT(ApiCommands.NotImplementedCommand/*EdidarAlternativa*/, value.Id, value).ReadAsAsync<object>();
            result.Wait();
            if (!result.IsCompletedSuccessfully && result.Exception != null)
            {
                return BadRequest($"{result.Status.ToString()}: {result.Exception.Message}");
            }
            return Ok();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int altId)
        {
            DALApi.DELETE(ApiCommands.NotImplementedCommand/*DeletarAlternativa*/, altId);
            return RedirectToAction("Listar", "Questao");
        }
    }
}
