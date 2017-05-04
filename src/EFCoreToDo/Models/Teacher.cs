using System;
using System.Collections.Generic;

using System.Text;


namespace EFCoreToDo.Models
{
  public  class Teacher : User
    {
        public int ServiceCode { get; set; }
        public String Grade { get; set; }





        //Relation with "ModulsTeacher" classAssociation
        public virtual ICollection<ModulsTeacher> ModulsTeachers { get; set; }



    }
}
