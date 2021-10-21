using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Storages.Word;
using DataModel.Storages.Word.Models;

namespace WordsGetter.Services
{
    /// <summary>
    /// Класс сервиса, выполняющий необходимые операции с БД.
    /// </summary>
    public class WordService
    {
        // private readonly WordRepository _wordRepository;
        private readonly IWordRepository _wordRepository;

        /// <summary>
        /// Конструктор сервиса.
        /// </summary>
        /// <param name="wordRepository"> Контекст данных, содержащий множества объектов, хранящихся в БД. </param>
        //public WordService(ApplicationContext context)
        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
            //_wordRepository = new WordRepository(context);
        }

        public async Task<List<WordModel>> GetMostMentionedWordsAsync(string word)
        {
            return await _wordRepository.GetMostMentionedWordsAsync(word);
        }
    }
}