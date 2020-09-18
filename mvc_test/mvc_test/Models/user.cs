using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_test.Models
{
    public class user
    {
      //  [Required, Display(Name = "账号")]
        public string ID { get; set; }
        //[Required, Display(Name = "密码")]
        public string password { get; set; }
       // [Required, Display(Name = "类型")]
        public string type { get; set; }
        // public string Rating { get; set; }
    }

}
