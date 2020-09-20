using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_test.Models
{
    public class select_sec
    {
        public string S_num { get; set; }

        public string S_name { get; set; }

        [Key]
        public int course_id { get; set; }

        public string course_name { get; set; }
    }
}