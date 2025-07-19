using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.DAL.DAO;
using StockTracker.DAL.DTO;
using StockTracker.DAL;


namespace StockTracker.BLL
{
    class ProductBLL : IBLL<ProductDetailDTO, ProductDTO>
    {
        CategoryDAO cateogrydao = new CategoryDAO();
        ProductDAO dao = new ProductDAO();
        SalesDAO salesDAO = new SalesDAO();
        public bool Delete(ProductDetailDTO entity)
        {
            Product product = new Product();
            product.ID=entity.ProductID;
            dao.Delete(product);
            Sale sales = new Sale();
            sales.ProductID=entity.ProductID;
            salesDAO.Delete(sales);

            return true;
        }

        public bool GetBack(ProductDetailDTO entity)
        {
           return dao.GetBack(entity.ProductID);
        }

        public bool Insert(ProductDetailDTO entity)
        {
           Product product = new Product(); 
            product.ProductName = entity.ProductName;
            product.CategoryID=entity.CateogryID;
            product.Price=entity.Price;
            return dao.Insert(product);
        }

        public ProductDTO Select()
        {
            ProductDTO dto = new ProductDTO();
            dto.categories = cateogrydao.Select();
            dto.Products = dao.Select();
            return dto;
        }

        public bool Update(ProductDetailDTO entity)
        {
            Product product = new Product();
            product.ID = entity.ProductID;
            product.Price = entity.Price;
            product.ProductName=entity.ProductName;
            product.StockAmount = entity.StockAmount;
            product.CategoryID = entity.CateogryID;
            return dao.Update(product);
        }
    }
}
