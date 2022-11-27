using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.TransferObjects
{
    public class Student
    {
        public int STT { get; set; }
        public string MaSV { get; set; }
        public string MaLop { get; set; }

        public string HoTen { get; set; }

        public string QueQuan { get; set; }
        public DateTime NgaySinh { get; set; }
    }
}
