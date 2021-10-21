using System.Threading.Tasks;
using WordsGetter.Configuration;
using WordsGetter.PresentationLayer;

namespace WordsGetter
{
    public class Program
    {
        /// <summary>
        /// Основной метод программы, запускает само приложение.
        /// </summary>
        /// <param name="args"> Аргументы, переданные с запуском приложения из консоли. </param>
        public static async Task Main(string[] args)
        {
            var input = args[0];

            var logic = Configurator.Configure();
            var wordsList = await logic.GetMostMentionedWordsAsync(input);
            var output = new Output();

            output.PrintWords(wordsList);
        }
    }
}