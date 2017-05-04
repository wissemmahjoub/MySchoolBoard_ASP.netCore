using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
    public class Classs
    {
        [Key]
        public int ClasssId { get; set; }


        public int NbreEtudiants { get; set; }
        public string Speciality { get; set; }

        public string ClasseName { get; set; }
        public string Level { get; set; }

        //Relation with "Student" class fef
        public virtual ICollection<Student> Students { get; set; }


        ////Relation with "Modules" class
        //public virtual ICollection<Module> Modules { get; set; }


        //Relation with "ModulsClass" classAssociation ____ many
        public virtual ICollection<ModulsClass> ModulsClasss { get; set; }

    }
}
