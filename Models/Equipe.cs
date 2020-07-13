using System;
using System.Collections.Generic;
using System.IO;
using e_players_completo.Interfaces;

namespace e_players_completo.Models
{
    //HERANÇA DE DUAS CLASSES
    public class Equipe : EPlayersBase, IEquipe
    {
        //PROPRIEDADES/ATRIBUTOS
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/equipe.csv";

        //CONSTRUTOR
        public Equipe() {
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        ///     Formata cada linha do csv.
        /// </summary>
        /// <param name="_equipe">Objeto que terá seus dados separados por ";".</param>
        /// <returns>Retorna uma string com os dados separados por ";".</returns>
        private string PrepararLinha(Equipe _equipe) {
            return $"{_equipe.IdEquipe};{_equipe.Nome};{_equipe.Imagem}";
        }

        /// <summary>
        ///     Adiciona no bd.
        /// </summary>
        /// <param name="_equipe">Objeto a ser adicionado no bd.</param>
        public void Create(Equipe _equipe)
        {
            var linhas = new string[] {PrepararLinha(_equipe)};
            File.AppendAllLines(PATH, linhas);
        }

        /// <summary>
        ///     Deleta um cadastro do bd.
        /// </summary>
        /// <param name="_idEquipe">Id do cadastro a ser deletado.</param>
        public void Delete(int _idEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == _idEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        ///     Lê todos os cadastros do bd.
        /// </summary>
        /// <returns>Retorna uma lista de todos os objetos cadastrados no bd.</returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        /// <summary>
        ///     Atualiza um cadastro do bd.
        /// </summary>
        /// <param name="_equipe">Objeto a ser atualizado.</param>
        public void Update(Equipe _equipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == _equipe.IdEquipe.ToString());
            linhas.Add( PrepararLinha(_equipe) );
            RewriteCSV(PATH, linhas);
        }
    }
}