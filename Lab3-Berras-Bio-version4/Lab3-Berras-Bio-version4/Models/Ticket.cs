using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Lab3_Berras_Bio_version4.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual Showing Showing { get; set; }
    }
}
