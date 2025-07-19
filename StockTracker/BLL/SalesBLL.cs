﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.DAL.DTO;
using StockTracker.DAL;
using StockTracker.DAL.DAO;

namespace StockTracker.BLL
{
    class SalesBLL : IBLL<SalesDetailDTO, SalesDTO>
    {
        SalesDAO dao = new SalesDAO();
        ProductDAO productDAO = new ProductDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        CustomerDAO customerDAO = new CustomerDAO();

        public bool Delete(SalesDetailDTO entity)
        {
            Sale sales=new Sale();
            sales.ID=entity.SalesID;
            dao.Delete(sales);
            Product product = new Product();
            product.ID=entity.ProductID;
            product.StockAmount=entity.StockAmount+ entity.SalesAmount;
            productDAO.Update(product);
            return true;
        }

        public bool GetBack(SalesDetailDTO entity)
        {
            dao.GetBack(entity.SalesID);
            Product product = new Product();
            product.ID=entity.ProductID;
            int temp=entity.StockAmount-entity.SalesAmount;
            product.StockAmount = temp;
            productDAO.Update(product);
            return true;
        }

        public bool Insert(SalesDetailDTO entity)
        {
            Sale sales = new Sale();
            sales.CategoryID = entity.CategoryID;
            sales.ProductID = entity.ProductID;
            sales.CustomerID=entity.CustomerID;
            sales.ProductSalesPrice=entity.Price;
            sales.ProductSalesAmount=entity.SalesAmount;
            sales.SalesDate=entity.SalesDate;
            dao.Insert(sales);
            Product product = new Product();
            product.ID= entity.ProductID;
            int temp = entity.StockAmount - entity.SalesAmount;
            product.StockAmount = temp;
            productDAO.Update(product);
            return true;
        }

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO();
            dto.Products = productDAO.Select();
            dto.Customers=customerDAO.Select();
            dto.categories = categoryDAO.Select();
            dto.Sales=dao.Select();
            return dto;
        }
        public SalesDTO Select(bool isDeleted)
        {
            SalesDTO dto = new SalesDTO();
            dto.Products = productDAO.Select(isDeleted);
            dto.Customers = customerDAO.Select(isDeleted);
            dto.categories = categoryDAO.Select(isDeleted);
            dto.Sales = dao.Select(isDeleted);
            return dto;
        }

        public bool Update(SalesDetailDTO entity)
        {
            Sale sales = new Sale();
            sales.ID = entity.SalesID;
            sales.ProductSalesAmount = entity.SalesAmount;
            dao.Update(sales);

            Product product = new Product();
            product.ID = entity.ProductID;
            product.StockAmount = entity.StockAmount;
            productDAO.Update(product);

            return true;
        }
    }
}
