using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_test.Models
{
    public class time_slot
    {
        [Key]
        public string time_slot_id { get; set; }
        public string day { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
    }
}
