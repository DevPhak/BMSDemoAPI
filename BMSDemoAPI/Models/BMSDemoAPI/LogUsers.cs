using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMSDemoAPI.Models.BMSDemoAPI
{
    public class LogUsers
    {
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Column(TypeName = "int")]
        public int RefID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime SessionDateTime { get; set; }

        [Column(TypeName = "char(15)")]
        public string IPAddress { get; set; }
    }
}
