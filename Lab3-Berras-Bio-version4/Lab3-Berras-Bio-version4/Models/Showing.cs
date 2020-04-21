using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class Showing
    {
        public int Id { get; set; }
        public DateTime StartHour { get; set; }
        public Movie Movie { get; set; }
        public int TotalSeats { get; set; } = 50;
        public int OccupiedSeats { get; set; }

    }
}
