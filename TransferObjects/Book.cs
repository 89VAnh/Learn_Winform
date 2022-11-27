using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.TransferObjects
{
    public class Book
    {
        public string MaSach { get; set; }
        public string MaLoaiSach { get; set; }
        public string TieuDe { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
    }
}
