using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grid.Models
{
    [Table("Faculty")]
    public class Faculty
    {
        public int Id { get; set; }
        public int DId { get; set; }
        public string Name { get; set; }
    }
}