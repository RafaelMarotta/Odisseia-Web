﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace OdisseiaWeb.DAL
{
    public class DALApi
    {
        public static string ApiUri { get; private set; } = "http://ec2-18-217-240-189.us-east-2.compute.amazonaws.com:6001";

        public DALApi() { }

        private static string _getCommand(ApiCommands command)
        {
            switch (command)
            {
                case ApiCommands.CadastarMissao: return "/api/Missao";
                case ApiCommands.LancarMissao: return "/api/Missao/Lancar";
                case ApiCommands.CardsMissaoAluno: return "/api​/Missao​/Aluno​/";
                case ApiCommands.InfoBasicaMissao: return "/api/Missao/MissaoInfo/";
                case ApiCommands.DeletarMissao: return "/api/Missao/";
                case ApiCommands.ListarAluno: return "/api/Usuario/Alunos";
                case ApiCommands.UsuarioAluno: return "/api/Usuario/";
                case ApiCommands.AlterarUsuario: return "/api/Usuario/";
                case ApiCommands.DeletarUsuario: return "/api/Usuario/";
                case ApiCommands.LoginUsuario: return "/api/Usuario/Login";
                case ApiCommands.CriarUsuario: return "/api/Usuario";
                default: throw new NotImplementedException();
            }
        }

        private static HttpClient _getClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ApiUri);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static HttpContent GET(ApiCommands command)
        {
            HttpResponseMessage response = _getClient().GetAsync(_getCommand(command)).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            return response.Content;
        }

        public static HttpContent GET(ApiCommands command, int id)
        {
            HttpResponseMessage response = _getClient().GetAsync(_getCommand(command)).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            return response.Content;
        }

        public static object POST(ApiCommands command, object value)
        {
            HttpResponseMessage response = _getClient().PostAsJsonAsync(_getCommand(command), value).Result;
            response.EnsureSuccessStatusCode();
            using (WebClient wc = new WebClient())
            {
                return JsonConvert.DeserializeObject(wc.DownloadString(response.Headers.Location));
            }
        }

        public static HttpContent PUT(ApiCommands command, int id, object value)
        {
            HttpResponseMessage response = _getClient().PostAsJsonAsync($"{_getCommand(command)}{id}", value).Result;
            response.EnsureSuccessStatusCode();
            return response.Content;
        }

        public static HttpStatusCode DELETE(ApiCommands command, int id)
        {
            HttpResponseMessage response = _getClient().DeleteAsync($"{_getCommand(command)}{id}").Result;
            return response.StatusCode;
        }
    }
}