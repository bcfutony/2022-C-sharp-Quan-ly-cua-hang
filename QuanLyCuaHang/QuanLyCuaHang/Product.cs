using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class Product
    {
        //mã, tên hàng, hạn dùng, công ty sản xuất, năm sản xuất, loại hàng
        public int Id_Product { get; set; }
        public string Name_Product { get; set; }
        public string Handung { get; set; }
        public string Name_Company { get; set; }
        public int Nam_SX { get; set; }
        public string Name_Category { get; set; }


    }
}
