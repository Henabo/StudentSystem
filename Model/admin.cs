﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin
    {
        public int id { get; set; }
        public string admin_name { get; set; }
        public string password { get; set; }
        public DateTime add_time{ get; set; }
        public DateTime update_time { get; set; }
        public int deleted { get; set; }
    }
}
