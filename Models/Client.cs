using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grid.Models
{
    [Table("Client")]
    public class Client
    {
        public int Id { get; set; }
        public string Clients { get; set; }
        public string ClientCode { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}