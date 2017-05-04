using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
    public class TimeTable
    {

        [Key]
        public int TimeTableId { get; set; }

        [DataType(DataType.DateTime)]

        public DateTime DateDebut { get; set; }

        [DataType(DataType.DateTime)]

        public DateTime DateFin { get; set; }

        [ForeignKey("Classee")]
        public Nullable<int> idclassee { get; set; }

        //Relation with "Module" classs
        public virtual  Classs Classee { get; set; }

        public string filenamee { get; set; }

        public string filecode { get; set; }


    }
}
