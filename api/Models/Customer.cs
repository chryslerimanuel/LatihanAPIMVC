using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace api.Models
{
    [Table("Tb_M_Customer")]
    public class Customer
    {   
        [Key]
        public int Id { get; set; }

        public string CustomerName { get; set; }

    }
}