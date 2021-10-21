using System.Collections.Generic;
using DataModel.Storages.Word.Models;

namespace WordsGetter.PresentationLayer
{
    /// <summary>
    /// Интерфейс вывода информации.
    /// </summary>
    interface IOutput
    {
        /// <summary>
        /// Метод для вывода списка объектов класса WordModel.
        /// </summary>
        /// <param name="words"> Список слов, который надо вывести. </param>
        void PrintWords(List<WordModel> words);
    }
}