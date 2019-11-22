using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeDB2.Model
{
   public class Cities
    {
        public int Id { get; set; }
        public string CityName { get; set; }
       // public DateTime DateZamer { get; set; }
       // public int Limit { get; set; }
        public ICollection<People> Peoples { get; set; }
        public ICollection<CitiesLimit> CitiesLimits { get; set; }

        public Cities()
        {
           Peoples = new List<People>();
           CitiesLimits = new List<CitiesLimit>();

        }
    }
}
