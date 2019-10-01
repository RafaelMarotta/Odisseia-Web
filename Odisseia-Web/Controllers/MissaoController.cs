using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Missao;
using Microsoft.Extensions.Primitives;
using Models.Alternativa;
using Models.Questao;
using System.Text;
using OdisseiaWeb.DAL;
using System.Net.Http;
using Newtonsoft.Json;
using Controllers.Exceptions;
using Models.Materia;
using System.Globalization;

namespace Controllers
{
    public class MissaoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                UserSessionController.ValidateUser(HttpContext);

                HttpResponseMessage result = await DALApi.GET(ApiCommands.ListarCardMissao);

                if (!result.IsSuccessStatusCode)
                {
                    ViewData["error"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Logout", "Usuario");
                }

                result.EnsureSuccessStatusCode();

                IList<MissaoListarDTO> missoes = JsonConvert.DeserializeObject<IList<MissaoListarDTO>>(await result.Content.ReadAsStringAsync());

                return View("_View_Missao_Index", missoes);
            }
            catch (UsetNotLoggedException ex)
            {
                return RedirectToAction("Logout", "Usuario");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                UserSessionController.ValidateUser(HttpContext);

                HttpResponseMessage result = await DALApi.GET(ApiCommands.ListarMaterias);

                if (!result.IsSuccessStatusCode)
                {
                    ViewData["error"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                result.EnsureSuccessStatusCode();

                IList<MateriaListarDTO> materias = JsonConvert.DeserializeObject<IList<MateriaListarDTO>>(await result.Content.ReadAsStringAsync());

                if (materias == null)
                {
                    ViewData["error"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                return View("_View_Missao_Create", materias);
            }
            catch (UsetNotLoggedException ex)
            {
                return RedirectToAction("Logout", "Usuario");
            }
        }
        
        /* 
         Rules for Create:
            -> The name of the inputs:
                "{ value1 }{ value2 { value2.1 } }{ value3 }{ value4 }"
                * value1 = The Id auto-generated of the input class;
                * value2 (Optional) = The class who the input class belongs;
                    * value2.1 = That class Id;
                * value3 = The class name;
                * value4 = The input name;
            Obs: all values starts in upper case;
            Ex:
            name = "Id3Questao2AlternativaTexto",
            name = "Id1QuestaoEnunciado", etc...
        */
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateConfirmed(IFormCollection collection)
        {
            try
            {
                UserSessionController.ValidateUser(HttpContext);

                //Add Questões
                List<KeyValuePair<string, StringValues>> questoesEnunciado = collection.Where(q => q.Key.ToString().Contains("QuestaoEnunciado")).ToList<KeyValuePair<string, StringValues>>();
                List<KeyValuePair<string, StringValues>> questoesDificuldade = collection.Where(q => q.Key.ToString().Contains("QuestaoDificuldade")).ToList<KeyValuePair<string, StringValues>>();

                List<QuestaoCreateDTO> questoesList = new List<QuestaoCreateDTO>();

                foreach(KeyValuePair<string, StringValues> qstE in questoesEnunciado)
                {
                    int idQ = int.Parse(qstE.Key.ToString()[0].ToString());
                    KeyValuePair<string, StringValues> qstD = questoesDificuldade.First(q => int.Parse(q.Key.ToString()[0].ToString()) == idQ);

                    if(qstD.Key != null)
                    {
                        List<KeyValuePair<string, StringValues>> alternativasTexto = collection.Where(a => a.Key.ToString().Contains($"Questao{idQ}AlternativaTexto")).ToList<KeyValuePair<string, StringValues>>();
                        List<KeyValuePair<string, StringValues>> alternativasCorreto = collection.Where(a => a.Key.ToString().Contains($"Questao{idQ}AlternativaCorreto")).ToList<KeyValuePair<string, StringValues>>();

                        List<AlternativaCreateDTO> alternativasList = new List<AlternativaCreateDTO>();

                        foreach(KeyValuePair<string, StringValues> altT in alternativasTexto)
                        {
                            int idA = int.Parse(altT.Key.ToString()[0].ToString());
                            KeyValuePair<string, StringValues> altC = alternativasCorreto.First(a => int.Parse(a.Key.ToString()[0].ToString()) == idA);
                        
                            if(altC.Key != null)
                            {
                                alternativasList.Add(new AlternativaCreateDTO { texto = altT.Value, correto = bool.Parse(altC.Value) });
                            }
                        }

                        questoesList.Add(new QuestaoCreateDTO { alternativas = alternativasList, dificuldade = int.Parse(qstD.Value), enunciado = qstE.Value });
                    }
                }

                MissaoCreateDTO missao = new MissaoCreateDTO
                {
                    titulo = collection["MissaoTitulo"],
                    descricao = collection["MissaoDescricao"],
                    fkCriador = UserSessionController.GetUser(HttpContext).id,
                    fkMateria = int.Parse(collection["MissaoMateria"]),
                    questoes = questoesList
                };

                HttpResponseMessage result = await DALApi.POST(ApiCommands.CadastarMissao, missao);

                if (!result.IsSuccessStatusCode)
                {
                    ViewData["error"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                return await Index();
            }
            catch (UsetNotLoggedException ex)
            {
                return RedirectToAction("Logout", "Usuario");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Lancar(IFormCollection collection)
        {
            try
            { 
                UserSessionController.ValidateUser(HttpContext);

                MissaoLancarDTO missao = new MissaoLancarDTO
                {
                    DataPrazo = DateTime.ParseExact(collection["MissaoPrazo"], "yyyy-MM-ddThh:mm", CultureInfo.InvariantCulture).Ticks,
                    MissaoId = int.Parse(collection["MissaoId"])
                };

                HttpResponseMessage result = await DALApi.PUT(ApiCommands.LancarMissao, missao);

                if (!result.IsSuccessStatusCode)
                {
                    ViewData["error"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                return await Index();
            }
            catch (UsetNotLoggedException ex)
            {
                return RedirectToAction("Logout", "Usuario");
            }
        }
    }
}