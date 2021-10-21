using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Contexts;
using DataModel.Storages.Word;
using DataModel.Storages.Word.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordsGetter.Tests
{
    [TestClass]
    public class WordServiceTests
    {
        /// <summary>
        /// ???????? ????, ??? ????? ?????? ?? ????? ???? ??????????? ???? ? ?????? ???????.
        /// </summary>
        [TestMethod]
        public async Task GetMostMentionedWordsAsync_ShouldReturnAtMostFive()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "WordsDatabase")
                .Options;

            await using (var context = new ApplicationContext(options))
            {
                await context.Words.AddAsync(new WordModel("word", 4));
                await context.Words.AddAsync(new WordModel("wand", 6));
                await context.Words.AddAsync(new WordModel("war", 5));
                await context.Words.AddAsync(new WordModel("wallet", 4));
                await context.Words.AddAsync(new WordModel("well", 8));
                await context.Words.AddAsync(new WordModel("will", 4));
                await context.SaveChangesAsync();
            }

            // Act
            List<WordModel> words;
            await using (var context = new ApplicationContext(options))
            {
                var repository = new WordRepository(context);
                words = await repository.GetMostMentionedWordsAsync("w");
            }

            // Assert
            Assert.AreEqual("well", words[0].Word);
            Assert.AreEqual("wand", words[1].Word);
            Assert.AreEqual("war", words[2].Word);
            Assert.AreEqual("wallet", words[3].Word);
            Assert.AreEqual("will", words[4].Word);
            Assert.AreEqual(5, words.Count);
        }

        /// <summary>
        /// ???????? ????, ??? ????? ?????? ?????? ???? ?????.
        /// </summary>
        [TestMethod]
        public async Task GetMostMentionedWordsAsync_ShouldReturnOne()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "AnotherWordsDatabase")
                .Options;

            await using (var context = new ApplicationContext(options))
            {
                await context.Words.AddAsync(new WordModel("word", 4));
                await context.Words.AddAsync(new WordModel("wand", 6));
                await context.Words.AddAsync(new WordModel("war", 5));
                await context.Words.AddAsync(new WordModel("wallet", 4));
                await context.Words.AddAsync(new WordModel("well", 8));
                await context.Words.AddAsync(new WordModel("will", 4));
                await context.SaveChangesAsync();
            }

            // Act
            List<WordModel> words;
            await using (var context = new ApplicationContext(options))
            {
                var repository = new WordRepository(context);
                words = await repository.GetMostMentionedWordsAsync("wan");
            }

            // Assert
            Assert.AreEqual("wand", words[0].Word);
            Assert.AreEqual(1, words.Count);
        }
    }
}
