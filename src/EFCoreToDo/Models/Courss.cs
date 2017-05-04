
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
    public class Courss
    {
        [Key]
        public int id_cours { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }
        public string Title { get; set; }



        //Relation with "ModulsCours" classAssociation
        public virtual ICollection<ModulsCours> ModulsCoursss { get; set; }

    }
}
