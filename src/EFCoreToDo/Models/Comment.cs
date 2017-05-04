using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
   public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public DateTime Comment_Date { get; set; }
        public String Content { get; set; }


        //Relation with "Subject" class
        public virtual Subject Subjects { get; set; }
        public virtual User Users { get; set; }
        



    }
}
