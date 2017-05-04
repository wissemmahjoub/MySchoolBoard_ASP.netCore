using System;
using System.Collections.Generic;

using System.Text;


namespace EFCoreToDo.Models
{
  public  class Student : User
    {
        public String SecretCode { get; set; }



        //Relation with "Classs" class
        public virtual Classs classs1 { get; set; }

       

        //Relations with "Mark" class
        public virtual ICollection<Mark> Marks { get; set; }

        






    }
}
