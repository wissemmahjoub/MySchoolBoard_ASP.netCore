using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
    public class ModulsTeacher
    {
        //[Key]
        //public int idModulsTeacher { get; set; }
        public int ModuleId { get; set; }


        public int Id_Teacher { get; set; }


        // prop navigation
        public virtual Module Modulee { get; set; }
        public virtual Teacher Teachers { get; set; }


    }
}
