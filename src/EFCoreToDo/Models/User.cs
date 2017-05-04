using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EFCoreToDo.Models
{
    public class User
    {

        [Key]
        [Required]
        public int CIN { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String Adress { get; set; }
        public String Password { get; set; }

        [Required]
        public String E_mail { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

    }
}
