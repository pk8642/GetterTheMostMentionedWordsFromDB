using System;
using System.Collections.Generic;
using DataModel.Storages.Word.Models;

namespace WordsGetter.PresentationLayer
{
    /// <summary>
    /// Класс для вывода полученных данных.
    /// </summary>
    public class Output : IOutput
    {
        /// <summary>
        /// Метод, выполняющий вывод списка слов на консоль.
        /// </summary>
        /// <param name="words"> Полученный список слов </param>
        public void PrintWords(List<WordModel> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word.Word);
            }
        }
    }
}