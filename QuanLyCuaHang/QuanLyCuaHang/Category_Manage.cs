using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    class Category_Manage
    {

        //tao list category

        //private List<Category> ListCategory = null;
        //public Category_Manage()
        //{
        //    ListCategory = new List<Category>();
        //}

        List<Category> ListCategory = new List<Category>();
        //List<Category> ListCategory;

        /*
         * Ham tao ID_Category tang dan
         */

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
            //tao Id moi va gan vai Id_Category
            cate.Id_Category = GenerateID_Category();

            //nhap ten Category moi
            Console.Write("Nhap ten Category: ");
            cate.Name_Category = Convert.ToString(Console.ReadLine());
            
            //them category moi vao ListCategory
            ListCategory.Add(cate);
            
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
            if(listCate != null && listCate.Count > 0)
            {
                foreach(Category c in listCate)
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
            if(cate != null)
            {
                Console.WriteLine("nhap ten Category MOI: ");
                string name = Convert.ToString(Console.ReadLine());
                if( name != null && name.Length > 0)
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
            if(ListCategory != null && ListCategory.Count > 0)
            {
                foreach( Category c in ListCategory)
                {
                    if(c.Id_Category == id)
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
            if( ListCategory.Count>0 && ListCategory!= null)
            {
                foreach ( Category c in ListCategory)
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
