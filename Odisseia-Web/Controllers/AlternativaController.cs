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

namespace OdisseiaWeb.Controllers
{
    public class AlternativaController : Controller
    {
        public AlternativaController() { }
        
        public PartialViewResult ListAlternativas(Alternativa alternativa)
        {
            return PartialView(alternativa);
        }
        
        public bool Create(int idQuestao)
        {
            var newValue = DAOApi.POST(ApiCommands.NotImplementedCommand/*CadastarAlternativa*/, idQuestao);
            return (newValue != null);
        }

        public bool Edit(int id, [Bind("Id,FkQuestao,Texto,Correto")] Alternativa alternativa)
        {
            if (id != alternativa.Id)
            {
                throw new KeyNotFoundException("Alternativa não encontrada");
            }

            if (ModelState.IsValid)
            {
                var editedValue = DAOApi.PUT(ApiCommands.NotImplementedCommand/*EdidarAlternativa*/, id, alternativa).ReadAsAsync<object>();
                return (editedValue != null);
            }
            throw new FormatException("Erro ao construir Alternativa");
        }
        
        public HttpStatusCode Delete(int id)
        {
            return DAOApi.DELETE(ApiCommands.NotImplementedCommand/*EdidarAlternativa*/, id);
        }
    }
}
