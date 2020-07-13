using System;
using System.Collections.Generic;
using System.IO;
using e_players_completo.Interfaces;

namespace e_players_completo.Models
{
    public class Noticia : EPlayersBase, INoticia
    {
        //PROPRIEDADES/ATRIBUTOS
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public const string PATH = "Database/noticia.cs";

        //CONSTRUTOR
        public Noticia() {
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        ///     Formata cada linha do csv.
        /// </summary>
        /// <param name="_noticia">Objeto que terá seus dados separados por ";".</param>
        /// <returns>Retorna uma string com os dados separados por ";".</returns>
        private string PrepararLinha(Noticia _noticia) {
            return $"{_noticia.IdNoticia};{_noticia.Titulo};{_noticia.Texto};{_noticia.Imagem}";
        }

        /// <summary>
        ///     Adiciona no bd.
        /// </summary>
        /// <param name="_noticia">Objeto a ser adicionado no bd.</param>
        public void Create(Noticia _noticia)
        {
            var linhas = new string[] {PrepararLinha(_noticia)};
            File.AppendAllLines(PATH, linhas);
        }

        /// <summary>
        ///     Lê todos os cadastros do bd.
        /// </summary>
        /// <returns>Retorna uma lista de todos os objetos cadastrados no bd.</returns>
        public List<Noticia> ReadAll()
        {
            List<Noticia> noticias = new List<Noticia>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticia noticia = new Noticia();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }

        /// <summary>
        ///     Atualiza um cadastro do bd.
        /// </summary>
        /// <param name="_noticia">Objeto a ser atualizado.</param>
        public void Update(Noticia _noticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == _noticia.IdNoticia.ToString());
            linhas.Add( PrepararLinha(_noticia) );
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        ///     Deleta um cadastro do bd.
        /// </summary>
        /// <param name="_idNoticia">Id do cadastro a ser deletado.</param>
        public void Delete(int _idNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == _idNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}