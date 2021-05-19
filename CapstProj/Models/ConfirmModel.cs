using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstProj.Models
{
    
    public class ConfirmModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string UID { get; set; }
        public string P_Name { get; set; }
        public int Cost { get; set; }
        public string ProductImagePath { get; set; }
        public int qty { get; set; }

    }
}
