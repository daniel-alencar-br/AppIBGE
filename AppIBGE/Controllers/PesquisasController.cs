﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AppIBGE.Models;

// Namespaces para conexão com API
using System.Net.Http;
using System.Net.Http.Headers;

// Namespaces para uso dos dados da API
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Text;

namespace AppIBGE.Controllers
{
    public class PesquisasController : Controller
    {
        // objeto de acesso a API
        HttpClient client;

        // constructor para conexão com a API
        public PesquisasController()
        {
            // endereço da API e o tipo de resposta dela

            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://servicodados.ibge.gov.br/api/v2/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> ListarNome()
        {
            string API = "censos/nomes/enzo";

            var response = await client.GetAsync(API);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();

                // List<Pedidos>  <=====  JSon
                var Lista = JsonConvert.DeserializeObject<NomesIBGE[]>(resultado).ToList();

                return View(Lista);
            }
            else
                return View();
        }



        // GET: Pesquisas
        public ActionResult Index()
        {
            return View();
        }
    }
    
}