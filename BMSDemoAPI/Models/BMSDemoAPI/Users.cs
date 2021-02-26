using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BMSDemoAPI.Models
{
    public class Users
    {
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "nvarchar(15)")]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "nvarchar(20)")]
        public string UserPassword { get; set; }

        [Column(TypeName = "char(1)")]
        public string IsActive { get; set; }
    }
}
