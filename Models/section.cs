using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_test.Models
{
    public class section
    {
        [Key]
        public int sec_id { get; set; }
        public int course_id { get; set; }
        public string semester { get; set; }
        public string year { get; set; }
        public string time_slot_id { get; set; }
        public string classroom_id { get; set; }


    }
}

