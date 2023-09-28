using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grid.Models
{
    [Table("CourseData")]
    public class CourseData
    {
        public int Id { get; set; }
        public int CSId { get; set; }
        public string Course { get; set; }
        public string Branch { get; set; }
        public DateTime Date { get; set; }

    }
}