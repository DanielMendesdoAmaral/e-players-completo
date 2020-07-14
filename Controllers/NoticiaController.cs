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
    public class NoticiaController : Controller
    {
        //Instanciamos o nosso model, assim, teremos acesso ao nosso banco de dados e todos métodos do CRUD.
        Noticia noticiaModel = new Noticia();

        /// <summary>
        ///     Este método lê nosso bd e guarda em uma ViewBag. 
        /// </summary>
        /// <returns>Retorna a nossa view.</returns>
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        /// <summary>
        ///     Cadastra no bd a partir de um form no front.
        /// </summary>
        /// <param name="form">Form do front.</param>
        /// <returns>Retorna para a mesma página após concluir a ação.</returns>
        public IActionResult Cadastrar(IFormCollection form) {

            Noticia noticia = new Noticia();
            noticia.IdNoticia = Convert.ToInt32( form["IdNoticia"] );
            noticia.Titulo = form["Titulo"];
            noticia.Texto = form["Texto"];
            noticia.Imagem = form["Imagem"];

            noticiaModel.Create(noticia); //Insere o objeto criado no bd.

            ViewBag.Noticias = noticiaModel.ReadAll(); //Lê tudo do csv e guarda em uma lista. A ViewBag recebe esta lista. A viewbag é criada aqui.
            return LocalRedirect("~/Noticia"); //Está pagina, Noticia, é criada na view, pela sintaxe Razor.
        }
    }
}