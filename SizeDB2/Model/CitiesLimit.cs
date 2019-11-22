using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeDB2.Model
{
  public  class CitiesLimit
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Limit { get; set; }
        public int CityId { get; set; }
        public Cities City { get; set; }
    }
}
