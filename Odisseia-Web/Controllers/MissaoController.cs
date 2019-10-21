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
using Models.Tag;
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

                HttpResponseMessage result = await DALApi.GET(ApiCommands.ListarCardMissaoProfessor, UserSessionController.GetUser(HttpContext).id);

                if (!result.IsSuccessStatusCode)
                {
                    ViewData["error"] = true;
                    ViewData["errorMessage"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Logout", "Usuario");
                }

                result.EnsureSuccessStatusCode();

                IList<MissaoListarDTO> missoes = JsonConvert.DeserializeObject<IList<MissaoListarDTO>>(await result.Content.ReadAsStringAsync());

                return View("_View_Missao_Index", missoes);
            }
            catch (UserNotLoggedException)
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
                    ViewData["error"] = true;
                    ViewData["errorMessage"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                result.EnsureSuccessStatusCode();

                IList<MateriaListarDTO> materias = JsonConvert.DeserializeObject<IList<MateriaListarDTO>>(await result.Content.ReadAsStringAsync());

                if (materias == null)
                {
                    ViewData["error"] = true;
                    ViewData["errorMessage"] = "Erro de conexão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                return View("_View_Missao_Create", materias);
            }
            catch (UserNotLoggedException)
            {
                return RedirectToAction("Logout", "Usuario");
            }
        }

        /* 
         Rules for Create:
            -> The name of the inputs: 
                "{ value1 }{ value2 { value2.1 } }{ value3 }{ value4 }"
                * value1 (Optional) = The Id auto-generated of the input class;
                * value2 (Optional) = The class who the input class belongs;
                    * value2.1 (Optional) = That class Id;
                * value3 = The class name;
                * value4 = The input name;
            Obs: all values starts in upper case;
            Ex:
            name = "3Questao2AlternativaTexto",
            name = "1QuestaoEnunciado", etc...
        */
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateConfirmed(IFormCollection collection)
        {
            try
            {
                UserSessionController.ValidateUser(HttpContext);

                //Questao
                    //Get list of Questao params from inputs
                    List<KeyValuePair<string, StringValues>> questoesEnunciado = collection.Where(q => q.Key.ToString().Contains("QuestaoEnunciado")).ToList<KeyValuePair<string, StringValues>>();
                    List<KeyValuePair<string, StringValues>> questoesDificuldade = collection.Where(q => q.Key.ToString().Contains("QuestaoDificuldade")).ToList<KeyValuePair<string, StringValues>>();

                    //Create a Questao list
                    List<QuestaoCreateDTO> questoesList = new List<QuestaoCreateDTO>();

                    //Bind inputs into Questao list 
                    foreach(KeyValuePair<string, StringValues> qstE in questoesEnunciado)
                    {
                        //Find Questao Id in the input
                        int idQ = int.Parse(qstE.Key.ToString()[0].ToString());
                        //Find others inputs of the same Questao
                        KeyValuePair<string, StringValues> qstD = questoesDificuldade.First(q => int.Parse(q.Key.ToString()[0].ToString()) == idQ);

                        if(qstD.Key != null)
                        {
                            //Alternativa
                                //Get list of Alternativa params from inputs
                                List<KeyValuePair<string, StringValues>> alternativasTexto = collection.Where(a => a.Key.ToString().Contains($"Questao{idQ}AlternativaTexto")).ToList<KeyValuePair<string, StringValues>>();
                                List<KeyValuePair<string, StringValues>> alternativasCorreto = collection.Where(a => a.Key.ToString().Contains($"Questao{idQ}AlternativaCorreto")).ToList<KeyValuePair<string, StringValues>>();

                                //Create a Alternativa list
                                List<AlternativaCreateDTO> alternativasList = new List<AlternativaCreateDTO>();

                                //Bind inputs into Alternativa list 
                                foreach (KeyValuePair<string, StringValues> altT in alternativasTexto)
                                {
                                    //Find Alternativa Id in the input
                                    int idA = int.Parse(altT.Key.ToString()[0].ToString());
                                    //Find others inputs of the same Alternativa
                                    KeyValuePair<string, StringValues> altC = alternativasCorreto.First(a => int.Parse(a.Key.ToString()[0].ToString()) == idA);
                        
                                    if(altC.Key != null)
                                    {
                                        //Add a Alternativa in the Alternativa list
                                        alternativasList.Add(new AlternativaCreateDTO { texto = altT.Value, correto = bool.Parse(altC.Value) });
                                    }
                                }
                            //End Alternativa

                            //Tag
                                //Get list of Tag params from inputs
                                List<KeyValuePair<string, StringValues>> tagNome = collection.Where(a => a.Key.ToString().Contains($"Questao{idQ}TagNome")).ToList<KeyValuePair<string, StringValues>>();
                                List<KeyValuePair<string, StringValues>> tagColor = collection.Where(a => a.Key.ToString().Contains($"Questao{idQ}TagColor")).ToList<KeyValuePair<string, StringValues>>();

                                //Create a Tag list
                                List<TagCreateDTO> tagsList = new List<TagCreateDTO>();

                                //Bind inputs into Tag list 
                                foreach (KeyValuePair<string, StringValues> tagN in tagNome)
                                {
                                    //Find Tag Id in the input
                                    int idT = int.Parse(tagN.Key.ToString()[0].ToString());
                                    //Find others inputs of the same Tag
                                    KeyValuePair<string, StringValues> tagC = tagColor.First(a => int.Parse(a.Key.ToString()[0].ToString()) == idT);

                                    if (tagC.Key != null)
                                    {
                                        //Add a Alternativa in the Tag list
                                        tagsList.Add(new TagCreateDTO { Nome = tagN.Value, Color = tagC.Value });
                                    }
                                }
                            //End Tag

                            //Add a Questao in the Questao list
                            questoesList.Add(new QuestaoCreateDTO { alternativas = alternativasList, tags = tagsList,  dificuldade = int.Parse(qstD.Value), enunciado = qstE.Value });
                        }
                    }
                //End Questao

                //Bind inputs into a Missao 
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
                    ViewData["error"] = true;
                    ViewData["errorMessage"] = "Erro ao criar missão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                return await Index();
            }
            catch (UserNotLoggedException)
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
                    DataPrazo = DateTime.Parse(collection["MissaoPrazo"].ToString()).Ticks,
                    MissaoId = int.Parse(collection["MissaoId"])
                };

                HttpResponseMessage result = await DALApi.PUT(ApiCommands.LancarMissao, missao);

                if (!result.IsSuccessStatusCode)
                {
                    ViewData["error"] = true;
                    ViewData["errorMessage"] = "Erro ao lançar missão, Tente novamente mais tarde";
                    return RedirectToAction("Index", "Missao");
                }

                return await Index();
            }
            catch (UserNotLoggedException)
            {
                return RedirectToAction("Logout", "Usuario");
            }
        }
    }
}