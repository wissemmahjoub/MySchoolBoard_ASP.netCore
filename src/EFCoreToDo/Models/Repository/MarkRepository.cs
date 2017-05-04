using EFCoreToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreToDo.Repository
{
    public class IMarkRepository
    {
        private readonly ToDoDbContext _context;

        public IMarkRepository(ToDoDbContext context)
        {
            _context = context;

            if (_context.Marks.Count() == 0)
                Add(new Mark { MarkId=1 });
        }

        public IEnumerable<Mark> GetAll()
        {
            return _context.Marks.ToList();
        }

        public void Add(Mark mark)
        {
            _context.Marks.Add(mark);
            _context.SaveChanges();
        }

        public Mark Find(int MarkId)
        {
            return _context.Marks.FirstOrDefault(t => t.MarkId == MarkId);
        }

        public void Remove(int MarkId)
        {
            var entity = _context.Marks.First(t => t.MarkId == MarkId);
            _context.Marks.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Mark mark)
        {
            
              _context.Update(mark);
            _context.SaveChanges();
        }
    }
}

