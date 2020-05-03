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
        public virtual Movie Movie { get; set; }
        public virtual Auditorium Auditorium { get; set; }
        public int OccupiedSeats { get; set; }

    }
}
