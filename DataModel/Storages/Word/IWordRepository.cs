using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Storages.Word.Models;

namespace DataModel.Storages.Word
{
    /// <summary>
    /// Интерфейс репозитория для возможности тестирования без необходимости подключения к БД.
    /// </summary>
    public interface IWordRepository : IDisposable
    {
        /// <summary>
        /// Метод, получающий список слов из БД.
        /// </summary>
        /// <param name="word"> Слово, упоминания которого требуется найти в БД. </param>>
        Task<List<WordModel>> GetMostMentionedWordsAsync(string word);
    }
}