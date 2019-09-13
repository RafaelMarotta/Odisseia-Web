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
        public async Task<IActionResult> Create(int id)
        {
            var result = DAOApi.POST(ApiCommands.NotImplementedCommand/*CadastarAlternativa*/, id);
            if (result != null)
            {
                return RedirectToAction("Listar", "Questao");
            }
            throw new Exception("No result");
        }

        public void Edit(int id, Alternativa alternativa)
        {
            var result = DAOApi.PUT(ApiCommands.NotImplementedCommand/*EdidarAlternativa*/, id, alternativa).ReadAsAsync<object>();
            result.Wait();
            if (!result.IsCompletedSuccessfully && result.Exception != null)
            {
                throw new Exception($"{result.Status.ToString()}: {result.Exception.Message}");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            DAOApi.DELETE(ApiCommands.NotImplementedCommand/*DeletarAlternativa*/, id);
            return RedirectToAction("Listar", "Questao");
        }
    }
}
