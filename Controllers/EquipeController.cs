using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using e_players_completo.Models;
using Microsoft.AspNetCore.Http;

namespace e_players_completo.Controllers
{
    public class EquipeController : Controller
    {
        //Instanciamos o nosso model, assim, teremos acesso ao nosso banco de dados e todos métodos do CRUD.
        Equipe equipeModel = new Equipe();

        /// <summary>
        ///     Este método lê nosso bd e guarda em uma ViewBag. 
        /// </summary>
        /// <returns>Retorna a nossa view.</returns>
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        /// <summary>
        ///     Cadastra no bd a partir de um form no front.
        /// </summary>
        /// <param name="form">Form do front.</param>
        /// <returns>Retorna para a mesma página após concluir a ação..</returns>
        public IActionResult Cadastrar(IFormCollection form) {

            Equipe equipe   = new Equipe();
            equipe.IdEquipe = Int32.Parse( form["IdEquipe"] ); //Pega o valor do form que tem este name e joga na variável IdEquipe do objeto.
            equipe.Nome     = form["Nome"];
            equipe.Imagem   = form["Imagem"];

            equipeModel.Create(equipe); //Insere o objeto criado no bd.

            ViewBag.Equipes = equipeModel.ReadAll(); //Lê tudo do csv e guarda em uma lista. A ViewBag recebe esta lista. A viewbag é criada aqui.
            return LocalRedirect("~/Equipe"); //Esta página, Equipe, é criada na view, com a sintaxe Razor.
        }
    }
}