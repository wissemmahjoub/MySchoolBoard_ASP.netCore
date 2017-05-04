using EFCoreToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreToDo.Repository
{
    interface IMarkRespository
    {
        void Add(Mark mark);
        IEnumerable<Mark> GetAll();
        Mark Find(int MarkId);
        void Remove(int MarkId);
        void Update(Mark mark);
    }
}
