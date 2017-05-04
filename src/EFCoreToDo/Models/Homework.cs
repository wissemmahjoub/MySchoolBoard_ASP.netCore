using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
  public  class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        public String Label { get; set; }

        [DataType(DataType.MultilineText)]

        public String HomeworkDescription { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateLimit { get; set; }
        public String difficulty { get; set; }

        [ForeignKey("Modulee")]
        public Nullable<int> idmodule { get; set; }

        //Relation with "Module" class
        public virtual Module Modulee { get; set; }


    }
}
