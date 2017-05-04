using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
   public class Mark
    {
        [Key]
        public int MarkId { get; set; }
        public float CC { get; set; }
        public float DS { get; set; }
        public float Exam { get; set; }

        public float Moyenne { get; set; }

        //Relation with "Module" class
        public virtual Module Modulee { get; set; }

        //Relation with "Student" class
        public virtual Student sutdents { get; set; }


    }
}
