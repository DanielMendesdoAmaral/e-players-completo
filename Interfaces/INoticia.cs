using System.Collections.Generic;
using e_players_completo.Models;

namespace e_players_completo.Interfaces
{
    public interface INoticia
    {
        /// <summary>
        ///     Adiciona no bd.
        /// </summary>
        /// <param name="_noticia">Objeto a ser adicionado no bd.</param>
        void Create(Noticia _noticia);

        /// <summary>
        ///     Lê todos os cadastros do bd.
        /// </summary>
        /// <returns>Retorna uma lista de todos os objetos cadastrados no bd.</returns>
        List<Noticia> ReadAll();

        /// <summary>
        ///     Atualiza um cadastro do bd.
        /// </summary>
        /// <param name="_noticia">Objeto a ser atualizado.</param>
        void Update(Noticia _noticia);

        /// <summary>
        ///     Deleta um cadastro do bd.
        /// </summary>
        /// <param name="_idNoticia">Id do cadastro a ser deletado.</param>
        void Delete(int _idNoticia);
    }
}