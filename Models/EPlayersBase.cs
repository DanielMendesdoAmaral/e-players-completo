using System.Collections.Generic;
using System.IO;

namespace e_players_completo.Models
{
    public class EPlayersBase
    {
        /// <summary>
        ///     Cria a pasta e o arquivo do bd.
        /// </summary>
        /// <param name="_path">Caminho onde se encontrará o bd.</param>
        public void CreateFolderAndFile(string _path){

            string folder   = _path.Split("/")[0];

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path)){
                File.Create(_path).Close();
            }
        }

        /// <summary>
        ///     Lê todas as linhas do bd.
        /// </summary>
        /// <param name="PATH">Caminho do bd.</param>
        /// <returns>Retorna uma lista com todas as linhas do bd.</returns>
        public List<string> ReadAllLinesCSV(string PATH){
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        /// <summary>
        ///     Reescreve o bd.
        /// </summary>
        /// <param name="PATH">Caminho do bd.</param>
        /// <param name="linhas">Lista contendo as linhas que serão escritas no bd.</param>
        public void RewriteCSV(string PATH, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}