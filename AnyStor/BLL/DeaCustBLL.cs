using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyStor.BLL
{
    internal class DeaCustBLL
    {
        public int id { get; set; }
        public String type { get; set; }
        public String name { get; set; }
        public string email { get; set; }
        public String contact { get; set; }
        public String address { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }
    }
}
