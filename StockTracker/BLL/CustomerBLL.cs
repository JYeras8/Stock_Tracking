using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.DAL.DTO;
using StockTracker.DAL.DAO;
using StockTracker.DAL;

namespace StockTracker.BLL
{
    public class CustomerBLL : IBLL<CustomerDetailDTO, CustomerDTO>
    {
        CustomerDAO dao = new CustomerDAO();
        SalesDAO salesDAO = new SalesDAO();
        public bool Delete(CustomerDetailDTO entity)
        {
            Customer customer = new Customer();
            customer.ID = entity.ID;
            dao.Delete(customer);
            Sale sales = new Sale();
            sales.CustomerID=entity.ID;
            salesDAO.Delete(sales);
            return true;
        }

        public bool GetBack(CustomerDetailDTO entity)
        {
            return dao.GetBack(entity.ID);

        }

        public bool Insert(CustomerDetailDTO entity)
        {
            Customer customer = new Customer();
            customer.CustomerName=entity.customername;
            return dao.Insert(customer);
        }

        public CustomerDTO Select()
        {
            CustomerDTO dto=new CustomerDTO();
            dto.Customers = dao.Select();
            return dto;

        }

        public bool Update(CustomerDetailDTO entity)
        {
            Customer customer = new Customer();
            customer.ID = entity.ID;
            customer.CustomerName = entity.customername;
            return dao.Update(customer);
        }
    }
}
