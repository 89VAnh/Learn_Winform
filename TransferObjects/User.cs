﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.TransferObjects
{
    public class User
    {
        public short UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}