using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.DAL.DTO;
using StockTracker.DAL;
using StockTracker.DAL.DAO;

namespace StockTracker.BLL
{
    public class CategoryBLL : IBLL<CategoryDetailDTO, CategoryDTO>
    {
        CategoryDAO dao = new CategoryDAO();
        ProductDAO productDAO = new ProductDAO();
        public bool Delete(CategoryDetailDTO entity)
        {
            Category category = new Category();
            category.ID = entity.ID;
            dao.Delete(category);
            Product product = new Product();
            product.CategoryID = entity.ID;
            productDAO.Delete(product);
            return true;
        }

        public bool GetBack(CategoryDetailDTO entity)
        {
            return dao.GetBack(entity.ID);
        }

        public bool Insert(CategoryDetailDTO entity)
        {
            Category category = new Category();
            category.CategoryName = entity.CategoryName;
            return dao.Insert(category);
        }

        public CategoryDTO Select()
        {
            CategoryDTO dto = new CategoryDTO();
            dto.Categories= dao.Select();
            return dto;
        }

        public bool Update(CategoryDetailDTO entity)
        {
            Category category=new Category();
            category.CategoryName = entity.CategoryName;
            category.ID = entity.ID;    
            return dao.Update(category);
        }
    }
}
