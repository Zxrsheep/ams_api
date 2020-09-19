using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_test.Models
{
    public class leave_application
    {
        [Key]
        public int ask_for_leave_reason { get; set; }

        public int course_id { get; set; }

        public int class_date { get; set; }

        public int s_num { get; set; }
    }
}

