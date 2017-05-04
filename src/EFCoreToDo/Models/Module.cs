
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
  public  class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public String ModuleName { get; set; }
        public double ModuleCoeif { get; set; }




        //Relation with "Mark" class
        public virtual ICollection<Mark> Marks { get; set; }

        //Relation with "Homework" class
        public virtual ICollection<Homework> Homeworks { get; set; }


       // //Relation with "Class" class ss
       //public virtual ICollection<Classs> Classs1 { get; set; }


        //Relation with "Teacher" class
        public virtual ICollection<Teacher> Teachers { get; set; }

        //Relation with "ModulsCours" classAssociation
        public virtual ICollection<ModulsCours> ModulsCoursss { get; set; }


        //Relation with "ModulsClass" classAssociation
        public virtual ICollection<ModulsClass> ModulsClasss { get; set; }


        //Relation with "ModulsTeacher" classAssociation
        public virtual ICollection<ModulsTeacher> ModulsTeachers { get; set; }

    }
}
