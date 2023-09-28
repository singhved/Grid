using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grid.Models
{
    [Table("Dept")]
    public class Dept
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}