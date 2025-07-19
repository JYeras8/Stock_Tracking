using StockTracker.DAL;
using StockTracker.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.DAL.DAO
{
    class ProductDAO : StockContent, IDAO<Product, ProductDetailDTO>
    {
        public bool Delete(Product entity)
        {
            try
            {
                if (entity.ID != 0)
                {
                    
                        Product product = db.Products.First(x => x.ID == entity.ID);
                        product.isDeleted = true;
                        product.DeletedDate = DateTime.Today;
                        db.SaveChanges();
                }
                    else if (entity.CategoryID != 0)
                    {
                        List<Product> list = db.Products.Where(x=>x.CategoryID==entity.CategoryID).ToList();
                        foreach (var item in list)
                        {
                            item.isDeleted=true;
                            item.DeletedDate = DateTime.Today;
                        List<Sale> sales = db.Sales.Where(x => x.ProductID == item.ID).ToList();
                        foreach (var item2 in sales)
                        {
                            item2.isDeleted=true;
                            item2.DeletedDate = DateTime.Today;
                        }
                        db.SaveChanges();
                    }
                        db.SaveChanges();
                    }
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
                Product product = db.Products.First(x => x.ID == ID);
                product.isDeleted = false;
                product.DeletedDate = null;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert(Product entity)
        {
            try
            {
                db.Products.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductDetailDTO> Select()
        {
            try
            {
                List<ProductDetailDTO> products = new List<ProductDetailDTO>();
                var list=(from p in db.Products.Where(x=>x.isDeleted==false)
                          join c in db.Categories on p.CategoryID equals c.ID
                          select new
                          {
                              productName=p.ProductName,
                              categoryName=c.CategoryName,
                              stockAmount=p.StockAmount,
                              price=p.Price,
                              productID=p.ID,
                              categoryID=c.ID,
                          }).OrderBy(x => x.productName).ToList();
                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CategoryName = item.categoryName;
                    dto.StockAmount = item.stockAmount;
                    dto.Price = item.price;
                    dto.ProductID = item.productID;
                    dto.CateogryID = item.categoryID;
                    products.Add(dto);

                }
                return products;
                          
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProductDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<ProductDetailDTO> products = new List<ProductDetailDTO>();
                var list = (from p in db.Products.Where(x => x.isDeleted == isDeleted)
                            join c in db.Categories on p.CategoryID equals c.ID
                            select new
                            {
                                productName = p.ProductName,
                                categoryName = c.CategoryName,
                                stockAmount = p.StockAmount,
                                price = p.Price,
                                productID = p.ID,
                                categoryID = c.ID,
                                categoryisdeleted=c.isDeleted,
                            }).OrderBy(x => x.productName).ToList();
                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CategoryName = item.categoryName;
                    dto.StockAmount = item.stockAmount;
                    dto.Price = item.price;
                    dto.ProductID = item.productID;
                    dto.CateogryID = item.categoryID;
                    dto.isCategoryDeleted=item.categoryisdeleted;
                    products.Add(dto);

                }
                return products;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Product entity)
        {
            try
            {
                Product product = db.Products.First(x => x.ID == entity.ID);
                if (entity.CategoryID == 0)
                {
                    product.StockAmount = entity.StockAmount;

                }
                else
                {
                    product.ProductName = entity.ProductName;
                    product.Price= entity.Price;
                    product.CategoryID = entity.CategoryID;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
