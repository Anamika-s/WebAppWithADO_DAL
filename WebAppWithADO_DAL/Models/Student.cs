using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithADO_DAL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Batch { get; set; }
        public DateTime StartDate { get; set; }
    }
}
