using Cuf.infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuf.infrastructure.Repositories
{
    public interface IWordRepository
    {
        void Add(Word word);

        void Edit(Word word);

        void Remove(int Id);

        IEnumerable<Word> GetWords();

        Word FindById(int Id);
    }
}
