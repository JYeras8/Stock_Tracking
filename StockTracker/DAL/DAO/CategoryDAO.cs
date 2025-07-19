using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.DAL.DTO;

namespace StockTracker.DAL.DAO
{
    public class CategoryDAO : StockContent, IDAO<Category, CategoryDetailDTO>
    {
        public bool Delete(Category entity)
        {
            try
            {
                Category category = db.Categories.First(x => x.ID == entity.ID);
                category.isDeleted = true;
                category.DeletedDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GetBack(int ID)
        {
            try
            {
                Category category = db.Categories.First(x => x.ID == ID);
                category.isDeleted=false;
                category.DeletedDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert(Category entity)
        {
            try
            {
                db.Categories.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
        }

        public List<CategoryDetailDTO> Select()
        {
            List<CategoryDetailDTO> categories = new List<CategoryDetailDTO> ();
            var list= db.Categories.Where(x => x.isDeleted==false).ToList();
            foreach (var item in list)
            {
                CategoryDetailDTO dto = new CategoryDetailDTO();
                dto.ID = item.ID;
                dto.CategoryName= item.CategoryName;
                categories.Add(dto);
            }
            return categories;
        }
        public List<CategoryDetailDTO> Select(bool isDeleted)
        {
            List<CategoryDetailDTO> categories = new List<CategoryDetailDTO>();
            var list = db.Categories.Where(x => x.isDeleted == isDeleted).ToList();
            foreach (var item in list)
            {
                CategoryDetailDTO dto = new CategoryDetailDTO();
                dto.ID = item.ID;
                dto.CategoryName = item.CategoryName;
                categories.Add(dto);
            }
            return categories;
        }

        public bool Update(Category entity)
        {
            try
            {
                Category category = db.Categories.First(x => x.ID == entity.ID);
                category.CategoryName = entity.CategoryName;
                db.SaveChanges ();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
