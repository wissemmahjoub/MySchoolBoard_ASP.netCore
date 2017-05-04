using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
   public  class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Publication_Date { get; set; }


        //Relations with "Comment" class
        public virtual ICollection<Comment> Comments { get; set; }

        //Relations with "Student" class
        public virtual User Users { get; set; }


      

    }
}
