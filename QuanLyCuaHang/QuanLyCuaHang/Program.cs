
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            Category_Manage category_Manage = new Category_Manage();
            Product_Manage product_Manage = new Product_Manage();

            while (true)
            {
                Console.WriteLine("\nCHUONG TRINH QUAN LY CUA HANG C#");
                Console.WriteLine("*************************CATEGORY**********************");
                Console.WriteLine("**  1. Them Category.                                **");
                Console.WriteLine("**  2. Cap nhat thong tin Category boi ID.           **");
                Console.WriteLine("**  3. Xoa Category boi ID.                          **");
                Console.WriteLine("**  4. Tim kiem Category theo ten.                   **");
                Console.WriteLine("**  5. Hien thi danh sach Category.                  **");
                Console.WriteLine("**************************PRODUCT**********************");
                Console.WriteLine("**  6. Them Product.                                 **");
                Console.WriteLine("**  7. Cap nhat thong tin Product boi ID.            **");
                Console.WriteLine("**  8. Xoa Product boi ID.                           **");
                Console.WriteLine("**  9. Tim kiem Product theo ten.                    **");
                Console.WriteLine("**  10. Hien thi danh sach Product.                  **");


                Console.WriteLine("**  0. Thoat                                         **");
                Console.WriteLine("*******************************************************");
                Console.Write("Nhap tuy chon: ");
                int key = Convert.ToInt32(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. Them Category.");
                        category_Manage.NhapCategory();
                        Console.WriteLine("\nThem Category thanh cong!");
                        break;
                    case 2: 
                        if (category_Manage.SoLuongCategory() > 0)
                        {
                            Console.WriteLine("\n2. Cap nhat thong tin Category boi ID");
                            Console.Write("nhap Category_Id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            //goi ham ham updateCategory()
                            category_Manage.UpdateCategory(id);

                        } else
                        {
                            Console.WriteLine("\nDanh sach Category trong");
                        }                        
                        break;
                    case 3: //xoa category
                        if (category_Manage.SoLuongCategory() > 0)
                        {
                            Console.WriteLine("\n3. Xoa Category boi ID ");
                            Console.Write("nhap Category_Id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            //goi ham ham DeleteCategory()
                            category_Manage.DeleteCategory(id);                            

                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach Category trong");
                        }
                        break;
                    case 4: //Tim kiem Category theo ten
                        if (category_Manage.SoLuongCategory() > 0)
                        {
                            Console.WriteLine("\n4. Tim kiem Category theo ten: ");
                            Console.Write("nhap ten Category can tim: ");
                            string name = Convert.ToString(Console.ReadLine());                                                        
                            //goi ham tim kiem
                            List<Category> kq = category_Manage.FindByNameCategory(name);
                            category_Manage.ShowCategory(kq);

                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach Category trong");
                        }
                        break;
                    case 5:
                        if (category_Manage.SoLuongCategory() > 0)
                        {
                            Console.WriteLine("\n5. Hien thi danh sach Category.");
                            category_Manage.ShowCategory(category_Manage.getListCategory());
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }
                        break;
                    case 6:
                        Console.WriteLine("\n6. Them Product.");
                        product_Manage.NhapProduct();
                        Console.WriteLine("\nThem Product thanh cong!");
                        //hien thi product
                        Console.WriteLine("\nHien thi danh sach Product.");
                        product_Manage.ShowProduct(product_Manage.getListProduct());
                        //category_Manage.ShowCategory(category_Manage.getListCategory());
                        break;
                    case 7: //cap nhat product
                        
                        if(product_Manage.SoLuongProduct() >0)
                        {
                            Console.WriteLine("\n6. Cap nhat thong tin Product boi ID");
                            Console.Write("nhap Product_Id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            //goi ham ham updateCategory()
                            product_Manage.UpdateProduct(id);

                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach Category trong");
                        }                        
                        break;
                    case 10: //show danh sach product
                        if (product_Manage.SoLuongProduct() > 0)
                        {
                            Console.WriteLine("\n10. Hien thi danh sach Product.");
                            product_Manage.ShowProduct(product_Manage.getListProduct());                            
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach sinh vien trong!");
                        }                        
                        break;
                    case 0:
                        Console.WriteLine("\nBan da chon thoat chuong trinh!");
                        return;
                    default:
                        Console.WriteLine("\nKhong co chuc nang nay!");
                        Console.WriteLine("\nHay chon chuc nang trong hop menu.");
                        break;
                }
            }
            





            //Console.WriteLine("Xin chao, do an");
            ////Thêm, xóa, sửa và tìm kiếm các loại hàng. (5 điểm) Category
            //Console.WriteLine("nhap Category moi");
            //category_Manage.NhapCategory();
            //Console.WriteLine("Da nhap Category thanh cong");
        }
    }
}
