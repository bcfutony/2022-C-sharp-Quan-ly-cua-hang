
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
                        
            Product_Manage product_Manage = new Product_Manage();

            while (true)
            {
                Console.WriteLine("\nCHUONG TRINH QUAN LY CUA HANG C#");
                Console.WriteLine("*************************CATEGORY********************");
                Console.WriteLine("**  1. Them Category.                                ");
                Console.WriteLine("**  2. Cap nhat thong tin Category boi ID.           ");
                Console.WriteLine("**  3. Xoa Category boi ID.                          ");
                Console.WriteLine("**  4. Tim kiem Category theo ten.                   ");
                Console.WriteLine("**  5. Hien thi danh sach Category.                  ");
                Console.WriteLine("**************************PRODUCT********************");
                Console.WriteLine("**  6. Them Product.                                 ");
                Console.WriteLine("**  7. Cap nhat thong tin Product boi ID.            ");
                Console.WriteLine("**  8. Xoa Product boi ID.                           ");
                Console.WriteLine("**  9. Tim kiem Product theo ten.                    ");
                Console.WriteLine("**  10. Hien thi danh sach Product.                  ");
                Console.WriteLine("**  0. Thoat                                         ");
                Console.WriteLine("*****************************************************");
                Console.Write("NHAP TUY CHON (1-10): ");

                //valid so nhap vao tu 1 den 10
                int min = 0;
                int max = 10;

                string input = Console.ReadLine();
                int inputValue;
                bool success = int.TryParse(input, out inputValue);
                while (!success || inputValue < min || inputValue >max)
                {
                    Console.Write("Vui long chon chuc nang (tu 0 đen 10): ");                   
                    input = Console.ReadLine();
                    success = int.TryParse(input, out inputValue);
                }
                

                int key = inputValue;

                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. Them Category.");
                        product_Manage.NhapCategory();
                        
                        break;
                    case 2: 
                        if (product_Manage.SoLuongCategory() > 0)
                        {
                            Console.WriteLine("\n2. Cap nhat thong tin Category boi ID");
                            Console.Write("Nhap Category_Id: ");

                            string inputId = Console.ReadLine();
                            int inputValueId;
                            bool successId = int.TryParse(inputId, out inputValueId);
                            
                            while (!successId)
                            {
                                Console.Write("Vui long nhap so tu 1 tro len: ");
                                inputId = Console.ReadLine();
                                successId = int.TryParse(inputId, out inputValueId);
                            }

                            int id = inputValueId;
                            //goi ham ham updateCategory()
                            product_Manage.UpdateCategory(id);

                        } else
                        {
                            Console.WriteLine("\nDanh sach Category trong");
                        }                        
                        break;
                    case 3: //xoa category
                        if (product_Manage.SoLuongCategory() > 0)
                        {
                            Console.WriteLine("\n3. Xoa Category boi ID ");
                            Console.Write("Nhap Category_Id: ");

                            string inputId = Console.ReadLine();
                            int inputValueId;
                            bool successId = int.TryParse(inputId, out inputValueId);
                            
                            while (!successId)
                            {
                                Console.Write("Vui long nhap so tu 1 tro len: ");
                                inputId = Console.ReadLine();
                                successId = int.TryParse(inputId, out inputValueId);
                            }

                            int id = inputValueId;
                            
                            //goi ham ham DeleteCategory()
                            product_Manage.DeleteCategory(id);                            

                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach Category trong");
                        }
                        break;
                    case 4: //Tim kiem Category theo ten
                        if (product_Manage.SoLuongCategory() > 0)
                        {
                            Console.WriteLine("\n4. Tim kiem Category theo ten: ");
                            Console.Write("Nhap ten Category can tim: ");
                            string name = Convert.ToString(Console.ReadLine());                                                        
                            //goi ham tim kiem
                            List<Category> kq = product_Manage.FindByNameCategory(name);
                            product_Manage.ShowCategory(kq);

                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach Category trong");
                        }
                        break;
                    case 5:
                        if (product_Manage.SoLuongCategory() > 0)
                        {
                            Console.WriteLine("\n5. Hien thi danh sach Category.");
                            product_Manage.ShowCategory(product_Manage.getListCategory());
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach Category trong!");
                        }
                        break;

                    //them product moi
                    case 6:
                        Console.WriteLine("\n6. Them Product.");
                        product_Manage.NhapProduct();
                        Console.WriteLine("\nThem Product thanh cong!");
                        //hien thi product
                        Console.WriteLine("\nHien thi danh sach Product.");
                        product_Manage.ShowProduct(product_Manage.getListProduct());
                        //category_Manage.ShowCategory(category_Manage.getListCategory());
                        break;

                    //cap nhat product
                    case 7: 
                        
                        if(product_Manage.SoLuongProduct() >0)
                        {
                            Console.WriteLine("\n6. Cap nhat thong tin Product boi ID");
                            Console.Write("Nhap Product_Id: ");

                            string inputId = Console.ReadLine();
                            int inputValueId;
                            bool successId = int.TryParse(inputId, out inputValueId);

                            while (!successId)
                            {
                                Console.Write("Vui long nhap so tu 1 tro len: ");
                                inputId = Console.ReadLine();
                                successId = int.TryParse(inputId, out inputValueId);
                            }

                            int id = inputValueId;
                                                                                    
                            //goi ham ham updateCategory()
                            product_Manage.UpdateProduct(id);

                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach Product trong");
                        }                        
                        break;

                    //xoa product
                    case 8: 
                        if (product_Manage.SoLuongProduct() > 0)
                        {
                            Console.WriteLine("\n8. Xoa Product boi ID ");
                            Console.Write("Nhap Product_Id: ");

                            string inputId = Console.ReadLine();
                            int inputValueId;
                            bool successId = int.TryParse(inputId, out inputValueId);

                            while (!successId)
                            {
                                Console.Write("Vui long nhap so tu 1 tro len: ");
                                inputId = Console.ReadLine();
                                successId = int.TryParse(inputId, out inputValueId);
                            }

                            int id = inputValueId;
                            
                            product_Manage.DeleteProduct(id);
                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach Product trong");
                        }
                        break;

                    //tim kiem
                    case 9: 
                        if (product_Manage.SoLuongProduct() > 0)
                        {
                            Console.WriteLine("\n9. Tim kiem Product theo ten: ");
                            Console.Write("Nhap ten Product can tim: ");
                            string name = Convert.ToString(Console.ReadLine());
                            List<Product> kq = product_Manage.FindByNameProduct(name);
                            product_Manage.ShowProduct(kq);

                        }                      
                        else
                        {
                            Console.WriteLine("\nDanh sach Product trong");
                        }
                        break;

                    //show danh sach product
                    case 10: 
                        if (product_Manage.SoLuongProduct() > 0)
                        {
                            Console.WriteLine("\n10. Hien thi danh sach Product.");
                            product_Manage.ShowProduct(product_Manage.getListProduct());                            
                        }
                        else
                        {
                            Console.WriteLine("\nSanh sach Product trong!");
                        }                        
                        break;
                    case 0:
                        Console.WriteLine("\nBan da chon thoat chuong trinh!");
                        return;
                    default:
                        Console.WriteLine("\nKhong co chuc nang nay!");
                        Console.WriteLine("\nHay chon chuc nang tu 1 - 10.");
                        break;
                }
            }
            


        }
    }
}
