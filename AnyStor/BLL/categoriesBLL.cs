using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyStor.BLL
{
    internal class categoriesBLL
    {
        internal object name;

        public int id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }
    }
}
