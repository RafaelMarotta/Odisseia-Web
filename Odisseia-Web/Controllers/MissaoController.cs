using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdisseiaWeb.Models;
using Newtonsoft.Json;
using OdisseiaWeb.DAL;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Odisseia_Web.Controllers
{
    public class MissaoController : Controller
    {

        public MissaoController() { }

        // GET: Missaos
        public IActionResult Index()
        {
            var result = DALApi.GET(ApiCommands.NotImplementedCommand/*ListarMissao*/, 1/*Id do usuario da sessão*/);
            IList<Missao> missoes = JsonConvert.DeserializeObject<IList<Missao>>(result.ReadAsStringAsync().ToString());
            return View(missoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id)
        {
            var result = DALApi.GET(ApiCommands.NotImplementedCommand/*PegarMissao*/, id);
            Missao missao = JsonConvert.DeserializeObject<Missao>(result.ReadAsStringAsync().ToString());

            result = DALApi.GET(ApiCommands.NotImplementedCommand/*ListarMaterias*/, 1/*Id do usuario da sessão*/);
            IList<Materia> materias = JsonConvert.DeserializeObject<IList<Materia>>(result.ReadAsStringAsync().ToString());
            TempData.Add("Materias", materias);

            if (missao == null)
            {
                return NotFound();
            }

            return View("_View_MIssao_Edit", missao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Lancado(int missaoId)
        {
            var result = DALApi.POST(ApiCommands.NotImplementedCommand/*MudarLançarMissao*/, missaoId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(IFormCollection collection)
        {
            var result = DALApi.GET(ApiCommands.NotImplementedCommand/*PegarMissao*/, int.Parse(collection["idMissao"].ToString()));
            Missao missao = JsonConvert.DeserializeObject<Missao>(result.ReadAsStringAsync().ToString());

            missao.titulo = collection["txtTitulo"].ToString();
            missao.fkMateria = int.Parse(collection["cbxMateria"].ToString());
            missao.descricao = collection["txaDescricao"].ToString();
            missao.dataPrazo = DateTime.Parse(collection["datePrazo"]);

            DALApi.POST(ApiCommands.NotImplementedCommand/*SalvarMissao*/, missao);

            return Index();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            var result = DALApi.POST(ApiCommands.NotImplementedCommand/*CriarMissao*/, 1/*Id do usuario da sessão*/);
            Missao missao = JsonConvert.DeserializeObject<Missao>(result.ReadAsStringAsync().ToString());

            return Edit(missao.id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var result = DALApi.DELETE(ApiCommands.DeletarMissao, id);

            return Index();
        }
    }
}
