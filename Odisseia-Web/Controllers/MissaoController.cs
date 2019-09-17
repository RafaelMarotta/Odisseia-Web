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

namespace Odisseia_Web.Controllers
{
    public class MissaoController : Controller
    {

        public MissaoController() { }

        // GET: Missaos
        public async Task<IActionResult> Index()
        {
            return View(DALApi.GET(ApiCommands.NotImplementedCommand/*listarMissao*/));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var result = DALApi.GET(ApiCommands.NotImplementedCommand/*PegarMissao*/, id);
            Missao missao = JsonConvert.DeserializeObject<Missao>(result.ReadAsStringAsync().ToString());

            if (missao == null)
            {
                return NotFound();
            }

            return View("_View_MIssao_Edit", missao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Lancado(int missaoId)
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
        public async Task<IActionResult> Salvar(IFormCollection collection)
        {

        }

        // GET: Missaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missao = await _context.Missao
                .FirstOrDefaultAsync(m => m.id == id);
            if (missao == null)
            {
                return NotFound();
            }

            return View(missao);
        }

        // GET: Missaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Missaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titulo,descricao,fkMateria,fkCriador,dataCriacao,dataPrazo,lancada,excluido")] Missao missao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(missao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(missao);
        }

        // GET: Missaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missao = await _context.Missao.FindAsync(id);
            if (missao == null)
            {
                return NotFound();
            }
            return View(missao);
        }

        // POST: Missaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,titulo,descricao,fkMateria,fkCriador,dataCriacao,dataPrazo,lancada,excluido")] Missao missao)
        {
            if (id != missao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(missao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissaoExists(missao.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(missao);
        }

        // GET: Missaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missao = await _context.Missao
                .FirstOrDefaultAsync(m => m.id == id);
            if (missao == null)
            {
                return NotFound();
            }

            return View(missao);
        }

        // POST: Missaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var missao = await _context.Missao.FindAsync(id);
            _context.Missao.Remove(missao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MissaoExists(int id)
        {
            return _context.Missao.Any(e => e.id == id);
        }
    }
}
