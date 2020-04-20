using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Showing Showing { get; set; }
    }
}
