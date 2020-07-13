using System.Collections.Generic;
using e_players_completo.Models;

namespace e_players_completo.Interfaces
{
    public interface IEquipe
    {
        /// <summary>
        ///     Adiciona no bd.
        /// </summary>
        /// <param name="_equipe">Objeto a ser adicionado no bd.</param>
        void Create(Equipe _equipe);

        /// <summary>
        ///     Lê todos os cadastros do bd.
        /// </summary>
        /// <returns>Retorna uma lista de todos os objetos cadastrados no bd.</returns>
        List<Equipe> ReadAll();

        /// <summary>
        ///     Atualiza um cadastro do bd.
        /// </summary>
        /// <param name="_equipe">Objeto a ser atualizado.</param>
        void Update(Equipe _equipe);

        /// <summary>
        ///     Deleta um cadastro do bd.
        /// </summary>
        /// <param name="_idEquipe">Id do cadastro a ser deletado.</param>
        void Delete(int _idEquipe);
    }
}