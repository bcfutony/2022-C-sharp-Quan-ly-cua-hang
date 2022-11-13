using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class Product_Manage
    {
        //tao list kieu Product
        private List<Product> ListProduct = null;
        public Product_Manage()
        {
            ListProduct = new List<Product>();
        }
        

        /*
         * Ham tao Id tang dan cho Product
         */
        public int GenerateID_Product()
        {
            int max = 1;
            if(ListProduct != null && ListProduct.Count > 0)
            {
                max = ListProduct[0].Id_Product;
                foreach(Product p in ListProduct)
                {
                    if (max < p.Id_Product)
                        max = p.Id_Product;
                }
                max++;
            }
            return max;
        }
        /*
         * 6. Ham nhap product moi
         */
        public void NhapProduct()
        {
            Product p = new Product();           

            p.Id_Product = GenerateID_Product();

            Console.Write("nhap ten Product moi: ");
            p.Name_Product = Convert.ToString(Console.ReadLine());

            Console.Write("nhap han dung: ");
            p.Handung = Convert.ToString(Console.ReadLine());

            Console.Write("nhap cong ty san xuat: ");
            p.Name_Company = Convert.ToString(Console.ReadLine());

            Console.Write("nam san xuat: ");
            p.Nam_SX = int.Parse(Console.ReadLine());

            Console.Write("Loai hang (category): ");
            p.Name_Category = Convert.ToString(Console.ReadLine());
                     
            //them product moi vao ListProduct
            ListProduct.Add(p);
            
        }
        public int SoLuongProduct()
        {
            int dem = 0;

            if (ListProduct != null)
            {
                dem = ListProduct.Count;
            }
            return dem;
        }
        /*
         * Ham show
         */

        public void ShowProduct(List<Product> listPro)
        {
            //tieu de cot
            Console.WriteLine("{0, -5} {1, -20} {2, -10} {3, -10} {4, -10} {5, -10}",
                  "ID", "Name", "Han dung", "cong ty SX", "nam SX", "loai hang");
            // hien thi danh sach Category
            if (listPro != null && listPro.Count > 0)
            {
                foreach (Product p in listPro)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -10} {3, -10} {4, -10} {5, -10}",
                                      p.Id_Product, p.Name_Product, p.Handung, p.Name_Company, p.Nam_SX, p.Name_Category);
                }
            }
        }
        /*
        * Hàm trả về danh sách product hiện tại
        */
        public List<Product> getListProduct()
        {
            return ListProduct;
        }

        /*
         * Hàm cap nhat Product theo Id
         */
        public void UpdateProduct(int id)
        {
            Product prod = FindProductByID(id);
            if (prod != null)
            {
                Console.WriteLine("nhap ten Product MOI: ");
                string name = Convert.ToString(Console.ReadLine());
                if (name != null && name.Length > 0)
                {
                    prod.Name_Product = name;
                }
            }
            else
            {
                Console.Write("Product ko ton tai");
            }
        }

        public Product FindProductByID(int id)
        {
            Product searchRS = null;
            if (ListProduct != null && ListProduct.Count > 0)
            {
                foreach (Product pro in ListProduct)
                {
                    if (pro.Id_Product == id)
                        searchRS = pro;
                }
            }
            return searchRS;
        }
    }
}
