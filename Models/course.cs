using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_test.Models
{
    public class course
    {
        [Key]
        public int course_id { get; set; }

        public string course_name { get; set; }
        public string T_num { get; set; }
    }
}
