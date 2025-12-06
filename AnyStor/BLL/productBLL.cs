using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyStor.BLL
{
    internal class productBLL
    {
        public int id { get; set; }
        public String name { get; set; }
        public String category { get; set; }
        public String description { get; set; }
        public decimal rate { get; set; }
        public decimal qty { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }

    }
}
