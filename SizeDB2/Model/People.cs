using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeDB2.Model
{
    public class People
    {
      public int  Id {get;set;}
        public string Fio { get; set; }
        public string Phone { get; set; }
        public DateTime? Date { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public Cities City { get; set; }

    }
}
