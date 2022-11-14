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
       //
        List<Category> ListCategory = new List<Category>();




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
            Category cate = new Category();

            p.Id_Product = GenerateID_Product();

            Console.Write("nhap ten Product moi: ");
            p.Name_Product = Convert.ToString(Console.ReadLine());

            Console.Write("nhap han dung: ");
            p.Handung = Convert.ToString(Console.ReadLine());

            Console.Write("nhap cong ty san xuat: ");
            p.Name_Company = Convert.ToString(Console.ReadLine());

            Console.Write("nam san xuat: ");
            p.Nam_SX = int.Parse(Console.ReadLine());

            Category category = new Category();

            Console.Write("Loai hang (category): ");
            //category.Name_Category = Convert.ToString(Console.ReadLine());
            p.Name_Category = Convert.ToString(Console.ReadLine());

            //can kiem tra category da ton tai chua, neu co thi ko them nua            
            if (ListCategory != null && ListCategory.Count > 0)
            {                
                bool dacoCate = false;
                foreach (Category c in ListCategory)
                {
                    //da co category nay
                   
                    if (c.Name_Category.ToLower().Trim() == p.Name_Category.ToLower().Trim())
                    {
                        dacoCate = true;           
                    }
                    
                }
                if (!dacoCate)
                {
                    cate.Name_Category = p.Name_Category;
                    cate.Id_Category = GenerateID_Category();
                    ListCategory.Add(cate);
                   
                }
            }
            
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
                Console.Write("nhap ten Product MOI: ");
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
        /*
         * ham Xoa Category theo Id
         */
        public void DeleteProduct(int id)
        {
            Product prod = FindProductByID(id);
            if(prod != null)
            {
                ListProduct.Remove(prod);
            }
            else
            {
                Console.Write("Product ko ton tai");
            }
        }
        
        /*
         * Ham tim kiem product theo ten 
         */
        public List<Product> FindByNameProduct(string name)
        {
            List<Product> kq = new List<Product>();
            if(ListProduct.Count > 0 && ListProduct != null)
            {
                foreach(Product pro in ListProduct)
                {
                    if (pro.Name_Product.ToLower().Contains(name.ToLower()))
                    {
                        kq.Add(pro);
                    }
                }
            }
            return kq;
        }
        

        public int GenerateID_Category()
        {
            //tao bien max la Id cua Category moi
            //max kieu nguyen tang dan tu 1, 2, 3...
            int max = 1;
            if (ListCategory.Count > 0 && ListCategory != null)
            {
                max = ListCategory[0].Id_Category;
                for (int i = 0; i < ListCategory.Count; i++)
                {
                    if (max < ListCategory[i].Id_Category)
                    {
                        max = ListCategory[i].Id_Category;
                    }
                }
                max++;
            }
            return max;
        }

        /*
         * 1. Ham tao Category moi.
         */
        public void NhapCategory()
        {
            //khoi tao category moi
            Category cate = new Category();

            //nhap ten Category moi
            Console.Write("Nhap ten Category: ");
            cate.Name_Category = Convert.ToString(Console.ReadLine());

            //can kiem tra category da ton tai chua, neu co thi ko them nua            
            if (ListCategory != null && ListCategory.Count > 0)
            {
                bool dacoCate = false;
                foreach (Category c in ListCategory)
                {
                    //da co category nay
                    if (c.Name_Category.ToLower().Trim() == cate.Name_Category.ToLower().Trim())
                    {
                        dacoCate = true;
                        Console.WriteLine("Category da ton tai, vui long nhap ten khac: ");
                    }

                }
                if (!dacoCate)
                {
                    //cate.Name_Category = p.Name_Category;
                    cate.Id_Category = GenerateID_Category();
                    ListCategory.Add(cate);
                    Console.WriteLine("\nThem Category thanh cong!");

                }
            }
            else
            {
                cate.Id_Category = GenerateID_Category();
                ListCategory.Add(cate);
                Console.WriteLine("\nThem Category thanh cong!");
            }
        }

        public int SoLuongCategory()
        {
            int dem = 0;

            if (ListCategory != null)
            {
                dem = ListCategory.Count;
            }
            return dem;
        }

        /*
         * Ham show
         */

        public void ShowCategory(List<Category> listCate)
        {
            //tieu de cot
            Console.WriteLine("{0, -5} {1, -20}",
                  "ID", "Name");
            // hien thi danh sach Category
            if (listCate != null && listCate.Count > 0)
            {
                foreach (Category c in listCate)
                {
                    Console.WriteLine("{0, -5} {1, -20}",
                                      c.Id_Category, c.Name_Category);
                }
            }
        }
        /*
         * 2. ham cap nhat Category theo Id
         */
        public void UpdateCategory(int id)
        {
            Category cate = FindCateByID(id);
            if (cate != null)
            {
                Console.Write("nhap ten Category MOI: ");
                string name = Convert.ToString(Console.ReadLine());
                if (name != null && name.Length > 0)
                {
                    cate.Name_Category = name;
                }
            }
            else
            {
                Console.Write("Cate ko ton tai");
            }
        }

        public Category FindCateByID(int id)
        {
            Category searchRS = null;
            if (ListCategory != null && ListCategory.Count > 0)
            {
                foreach (Category c in ListCategory)
                {
                    if (c.Id_Category == id)
                        searchRS = c;
                }
            }
            return searchRS;
        }

        /*
         * 3. ham Xoa Category theo Id
         */
        public void DeleteCategory(int id)
        {
            Category cate = FindCateByID(id);
            if (cate != null)
            {
                ListCategory.Remove(cate);
                Console.WriteLine($"da xoa thanh cong id: {id}");
            }
            else
            {
                Console.Write("Category ko ton tai");
            }
        }
        /*
         * 4. ham tim kiem Category theo ten
         */
        public List<Category> FindByNameCategory(string name)
        {
            List<Category> kq = new List<Category>();
            if (ListCategory.Count > 0 && ListCategory != null)
            {
                foreach (Category c in ListCategory)
                {
                    if (c.Name_Category.ToLower().Contains(name.ToLower()))
                    {
                        kq.Add(c);
                    }
                }
            }
            return kq;
        }

        /*
         * Hàm trả về danh sách category hiện tại
         */
        public List<Category> getListCategory()
        {
            return ListCategory;
        }
    }
}
