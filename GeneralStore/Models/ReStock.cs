using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStore.Models
{
    public class ReStock
    {
        [Required]

        public int NewStock { get; set; }
    }
}