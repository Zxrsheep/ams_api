using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_test.Models
{
    public class classroom_info
    {
        [Key]
        public string classroom_id { get; set; }
    }
}
