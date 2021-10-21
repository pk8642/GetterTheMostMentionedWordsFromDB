using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Contexts;
using DataModel.Storages.Word.Models;
using Microsoft.EntityFrameworkCore;

namespace DataModel.Storages.Word
{
    /// <summary>
    /// Класс репозитория модели класса WordModel, реализующий методы интерфейса IWordRepository. 
    /// </summary>
    public class WordRepository : IWordRepository
    {
        private readonly ApplicationContext _db;
        private bool _disposed;

        /// <summary>
        /// Конструктор данного класса.
        /// Использует переданный контекст данных для совершения операций с БД.
        /// </summary>
        /// <param name="context"> Контекст данных </param>
        public WordRepository(ApplicationContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Метод, получающий слово из БД по переданному ключу.
        /// </summary>
        /// <param name="word"> Слово, упоминания которого требуется найти в БД. </param>
        public async Task<List<WordModel>> GetMostMentionedWordsAsync(string word)
        {
            return await _db.Words
                .Where(w => w.Word.StartsWith(word))
                .OrderByDescending(w => w.Count)
                .ThenBy(w => w.Word)
                .Take(5)
                .ToListAsync();
        }

        /// <summary>
        /// Освобождает неиспользующиеся ресурсы
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Метод, освобождающий неиспользующиеся ресурсы
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
