using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public interface IShowingRepository
    {
        IEnumerable<Showing> Allshowings { get; }
        Showing GetShowingById(int showId);
    }
}
