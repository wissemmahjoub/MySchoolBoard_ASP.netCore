using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreToDo.Models
{
    public class Test
    {
        [Key]
        public int idTest { get; set; }
        public string nom { get; set; }
        public int age { get; set; }
    }
}
