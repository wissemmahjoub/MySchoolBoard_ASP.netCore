using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
    public class ModulsCours
    {
        //[Key]
        //public int idModulsCours { get; set; }
        public int ModuleId { get; set; }

        public int id_cours { get; set; }


        // prop navigation
        public virtual Module Modulee { get; set; }
        public virtual Courss Coursss { get; set; }


    }
}
