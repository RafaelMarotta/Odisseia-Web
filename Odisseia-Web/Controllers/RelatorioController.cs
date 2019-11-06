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

namespace Controllers
{
    public class RelatorioController : OdisseiaWebBaseController
    {
        public override async Task<IActionResult> Index() 
        {
            try
            {
                UserSessionController.VerifyUser(HttpContext);
                IList<BasicReportClassDTO> relatorio = await _dataFilter<IList<BasicReportClassDTO>>(await DALApi.GET(ApiCommands.BasicReportClass));
                return View("_View_Relatorio_Turma", relatorio);
            }
            catch (Exception e)
            {
                return await _treatException(e, HttpContext);
            }
        }

        [HttpGet]
        public async Task<string> StudentsReports(int questId)
        {
            try
            {
                UserSessionController.VerifyUser(HttpContext);
                return await _dataFilter(await DALApi.GET(ApiCommands.BasicReportStudent, questId));
            }
            catch (Exception e)
            {
                await _treatException(e, HttpContext);
                return "";
            }
        }
    }
}
