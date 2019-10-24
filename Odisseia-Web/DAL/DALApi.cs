using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OdisseiaWeb.DAL
{
    public class DALApi
    {
        public static string ApiUri { get; private set; } = "http://ec2-18-217-240-189.us-east-2.compute.amazonaws.com:6001";
        private static Dictionary<ApiCommands, string> _command = new Dictionary<ApiCommands, string>{
            { ApiCommands.CadastarMissao, "/api/Missao" },
            { ApiCommands.ListarMaterias, "/api/Materia" },
            { ApiCommands.ListarCardMissaoProfessor, "/api/Missao/Professor/" },
            { ApiCommands.LancarMissao, "/api/Missao/Lancar" },
            { ApiCommands.CardsMissaoAluno, "/api​/Missao​/Aluno​/" },
            { ApiCommands.InfoBasicaMissao, "/api/Missao/MissaoInfo/" },
            { ApiCommands.DeletarMissao, "/api/Missao/" },
            { ApiCommands.ListarAluno, "/api/Usuario/Alunos"},
            { ApiCommands.UsuarioAluno, "/api/Usuario/" },
            { ApiCommands.AlterarUsuario, "/api/Usuario/" },
            { ApiCommands.DeletarUsuario, "/api/Usuario/" },
            { ApiCommands.LoginUsuario, "/api/Usuario/Login" },
            { ApiCommands.BasicReportClass, "/api/Relatorio/BasicReportClass" },
            { ApiCommands.BasicReportStudent, "/api/Relatorio/BasicReportStudent/" },
            { ApiCommands.CriarUsuario, "/api/Usuario" },
            { ApiCommands.LoginProfessor, "/api/Professor/Login" },
            { ApiCommands.ListarTags, "/api/Tag" }
        };

        private static HttpClient _client()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ApiUri);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async Task<HttpResponseMessage> GET(ApiCommands command)
        {
            HttpResponseMessage response = await _client().GetAsync( _command[command]);
            return response;
        }

        public static async Task<HttpResponseMessage> GET(ApiCommands command, object param)
        {
            HttpResponseMessage response = await _client().GetAsync($"{ _command[command]}{param.ToString()}");
            return response;
        }

        public static async Task<HttpResponseMessage> POST(ApiCommands command, object value)
        {
            HttpResponseMessage response = await _client().PostAsJsonAsync(_command[command], value); 
            return response;
        }

        public static async Task<HttpResponseMessage> PUT(ApiCommands command, object value)
        {
            HttpResponseMessage response = await _client().PutAsJsonAsync(_command[command], value);
            return response;
        }

        public static async Task<HttpResponseMessage> PUT(ApiCommands command, object param, object value)
        {
            HttpResponseMessage response = await _client().PutAsJsonAsync($"{_command[command]}{param.ToString()}", value);
            return response;
        }

        public static async Task<HttpResponseMessage> DELETE(ApiCommands command, object param)
        {
            HttpResponseMessage response = await _client().DeleteAsync($"{_command[command]}{param.ToString()}");
            return response;
        }
    }
}
