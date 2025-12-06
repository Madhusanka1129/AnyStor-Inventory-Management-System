using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyStor.BLL
{
    internal class userBLL
    {
        public int id { get; set; }
        public String fist_name { get; set; }
        public String last_name { get; set; }
        public String email { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String contact { get; set; }
        public String address { get; set; }
        public String gender { get; set; }
        public String user_type { get; set; }
        public DateTime added_date { get; set; }
        public  int added_by { get; set; }
    }
}
