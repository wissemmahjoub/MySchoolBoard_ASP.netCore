﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
    public class ModulsClass
    {
        //[Key]
        //public int idModulsClass { get; set; }
        public int ModuleId { get; set; }

        
        public int ClasssId { get; set; }


        // prop navigation
        public virtual Module Modulee { get; set; }
        public virtual Classs Classss { get; set; }




    }
}
