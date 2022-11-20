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

        //tao list kieu Category
        List<Category> ListCategory = new List<Category>();

        /*
        * 1. Ham tao Category moi.
        */
        public void NhapCategory()
        {
            //khoi tao category moi
            Category cate = new Category();

            //nhap ten Category moi
            Console.Write("Nhap ten Category (bat buoc - khong de trong): ");

            string name = Console.ReadLine();
            //validate ten vao
            while (name == null || name.Trim().Length <= 0)
            {
                Console.Write("   !Vui long nhap lai ten Category (khong de trong): ");
                name = Console.ReadLine();
            }           

            cate.Name_Category = name;

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
                        Console.WriteLine("Category da ton tai, vui long nhap ten khac");
                    }

                }
                if (!dacoCate)
                {
                    
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
         * 2 ham cap nhat Category theo Id
         */
        public void UpdateCategory(int id)
        {
            Category cate = FindCateByID(id);
            if (cate != null)
            {
                Console.Write("nhap ten Category MOI: ");
                string name = Console.ReadLine();
                //validate ten vao
                while (name == null || name.Trim().Length <= 0)
                {
                    Console.Write("   !Vui long nhap lai ten Category (khong de trong): ");
                    name = Console.ReadLine();
                }

                cate.Name_Category = name;

            }
            else
            {
                Console.Write("\nCategory ko ton tai \n");
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
         * 3 ham Xoa Category theo Id
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
                Console.Write("\nCategory ko ton tai \n");
            }
        }
        /*
         * 4 ham tim kiem Category theo ten
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
         * 5 Ham show
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
         * Hàm trả về danh sách category hiện tại
         */
        public List<Category> getListCategory()
        {
            return ListCategory;
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
            int min = 0;
            int max = 2022;

            Product p = new Product();  
            Category cate = new Category();

            p.Id_Product = GenerateID_Product();

            Console.Write("Nhap ten Product moi (bat buoc): ");
            string name = Console.ReadLine();
            //validate ten vao
            while(name == null || name.Trim().Length<=0)
            {
                Console.Write("   !Nhap ten Product moi nhe (bat buoc): ");
                name = Console.ReadLine();              
            }            
            p.Name_Product = name;


            Console.Write("Nhap han dung (mm/dd/yy): ");
            string datetime = Console.ReadLine();
            //valide datetime
            DateTime temp;
            bool successDT= DateTime.TryParse(datetime, out temp);
            while (!successDT)
            {
                Console.Write("   !vui long nhap han dung (mm/dd/yy): ");
                datetime = Console.ReadLine();
                successDT = DateTime.TryParse(datetime, out temp);
            }
            p.Handung = temp.ToShortDateString();



            Console.Write("Nhap cong ty san xuat: ");           
            string name_cty = Console.ReadLine();
            //validate ten vao
            while (name_cty == null || name_cty.Trim().Length <= 0)
            {
                Console.Write("   !Nhap ten cong ty san xuat nhe (bat buoc): ");
                name_cty = Console.ReadLine();
            }
            p.Name_Company = name_cty;



            Console.Write($"Nam san xuat dang so ({min}-{max}): ");
            //valid nam dang so
            string input = Console.ReadLine();
            int inputValue;
            bool success = int.TryParse(input, out inputValue);            
            while (!success || inputValue<min || inputValue >max)
            {
                Console.Write($"   !Vui long nhap nam dang so ({min}-{max}): ");
                input = Console.ReadLine();
                success = int.TryParse(input, out inputValue);
            }
            p.Nam_SX = inputValue;         



            Console.Write("Loai hang (category - bat buoc): ");
            string loaihang= Console.ReadLine();
            //validate loai hang
            while (loaihang == null || loaihang.Trim().Length <= 0)
            {
                Console.Write("   !Nhap ten loai hang nhe (bat buoc): ");
                loaihang = Console.ReadLine();
            }
            p.Name_Category = loaihang;




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
            else
            {
                cate.Name_Category = p.Name_Category;
                cate.Id_Category = GenerateID_Category();
                ListCategory.Add(cate);
                Console.WriteLine("\nThem Category thanh cong!\n");
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
         * 7 Hàm cap nhat Product theo Id 
         */
        public void UpdateProduct(int id)
        {
            int min = 0;
            int max = 2022;          
            Category cate = new Category();
            Product prod = FindProductByID(id);

            if (prod != null)
            {
                Console.Write("nhap ten Product MOI: ");
                string name = Console.ReadLine();
                //validate ten vao
                while (name == null || name.Trim().Length <= 0)
                {
                    Console.Write("   !Nhap ten Product moi nhe (bat buoc): ");
                    name = Console.ReadLine();
                }
                prod.Name_Product = name;
                Console.Write("\nDa cap nhat Product thanh cong\n\n");


                //cap nhat han dung
                Console.Write("Nhap han dung MOI (mm/dd/yy): ");
                string datetime = Console.ReadLine();
                //valide datetime
                DateTime temp;
                bool successDT = DateTime.TryParse(datetime, out temp);
                while (!successDT)
                {
                    Console.Write("   !vui long nhap han dung (mm/dd/yy): ");
                    datetime = Console.ReadLine();
                    successDT = DateTime.TryParse(datetime, out temp);
                }
                prod.Handung = temp.ToShortDateString();
                Console.Write("\nDa cap nhat Han dung thanh cong\n\n");


                Console.Write("Nhap cong ty san xuat MOI: ");
                string name_cty = Console.ReadLine();
                //validate ten vao
                while (name_cty == null || name_cty.Trim().Length <= 0)
                {
                    Console.Write("   !Nhap ten cong ty san xuat nhe (bat buoc): ");
                    name_cty = Console.ReadLine();
                }
                prod.Name_Company = name_cty;
                Console.Write("\nDa cap nhat cong ty sx thanh cong\n\n");


                Console.Write($"Nam san xuat dang so ({min}-{max}): ");
                //valid nam dang so
                string input = Console.ReadLine();
                int inputValue;
                bool success = int.TryParse(input, out inputValue);
                while (!success || inputValue < min || inputValue > max)
                {
                    Console.Write($"   !Vui long nhap nam dang so ({min}-{max}): ");
                    input = Console.ReadLine();
                    success = int.TryParse(input, out inputValue);
                }
                prod.Nam_SX = inputValue;
                Console.Write("\nDa cap nhat nam san xuat thanh cong\n\n");


                Console.Write("Loai hang MOI (category - bat buoc): ");
                string loaihang = Console.ReadLine();
                //validate loai hang
                while (loaihang == null || loaihang.Trim().Length <= 0)
                {
                    Console.Write("   !Nhap ten loai hang nhe (bat buoc): ");
                    loaihang = Console.ReadLine();
                }
                prod.Name_Category = loaihang;
                Console.Write("\nDa cap nhat Category thanh cong\n\n");


                //can kiem tra category da ton tai chua, neu co thi ko them nua            
                if (ListCategory != null && ListCategory.Count > 0)
                {
                    bool dacoCate = false;
                    foreach (Category c in ListCategory)
                    {
                        //da co category nay                   
                        if (c.Name_Category.ToLower().Trim() == prod.Name_Category.ToLower().Trim())
                        {
                            dacoCate = true;
                        }

                    }
                    if (!dacoCate)
                    {
                        cate.Name_Category = prod.Name_Category;
                        cate.Id_Category = GenerateID_Category();
                        ListCategory.Add(cate);
                    }
                }
                else
                {
                    cate.Name_Category = prod.Name_Category;
                    cate.Id_Category = GenerateID_Category();
                    ListCategory.Add(cate);
                    //Console.WriteLine("\nThem Category thanh cong!\n");
                }            

            }
            else
            {
                Console.Write("\nProduct ko ton tai nhe\n");
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
         * 8 ham Xoa Category theo Id
         */
        public void DeleteProduct(int id)
        {
            Product prod = FindProductByID(id);
            if(prod != null)
            {
                ListProduct.Remove(prod);
                Console.Write($"\nDa xoa product id={id} nhe\n");
            }
            else
            {
                Console.Write("\nProduct ko ton tai\n");
            }
        }
        
        /*
         * 9 Ham tim kiem product theo ten 
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

        /*
         * 10 Ham show
         */
        public void ShowProduct(List<Product> listPro)
        {
            //tieu de cot
            Console.WriteLine("{0, -5} {1, -20} {2, -10} {3, -15} {4, -10} {5, -10}", "ID", "Name", "Han dung", "cong ty SX", "nam SX", "loai hang");
            // hien thi danh sach Category
            if (listPro != null && listPro.Count > 0)
            {
                foreach (Product p in listPro)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -10} {3, -15} {4, -10} {5, -10}",
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

       
    }
}
