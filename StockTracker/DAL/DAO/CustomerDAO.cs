using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.DAL.DAO;
using StockTracker.DAL;
using StockTracker.DAL.DTO;

namespace StockTracker.DAL.DAO
{
    public class CustomerDAO : StockContent, IDAO<Customer, CustomerDetailDTO>
    {
        public bool Delete(Customer entity)
        {
            try
            {
                Customer customer = db.Customers.First(x => x.ID == entity.ID);
                customer.isDeleted = true;
                customer.DeletedDate= DateTime.Today;
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
                Customer customer= db.Customers.First(x => x.ID == ID);
                customer.isDeleted = false;
                customer.DeletedDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert(Customer entity)
        {
            try
            {
                db.Customers.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CustomerDetailDTO> Select()
        {
            try
            {
                List<CustomerDetailDTO> Customers = new List<CustomerDetailDTO>();
                var list = db.Customers.Where(x=>x.isDeleted==false).ToList();
                foreach (var item in list)
                {
                    CustomerDetailDTO dto = new CustomerDetailDTO();
                    dto.customername = item.CustomerName;
                    dto.ID = item.ID;
                    Customers.Add(dto);

                }
                return Customers;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CustomerDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<CustomerDetailDTO> Customers = new List<CustomerDetailDTO>();
                var list = db.Customers.Where(x => x.isDeleted == isDeleted).ToList();
                foreach (var item in list)
                {
                    CustomerDetailDTO dto = new CustomerDetailDTO();
                    dto.customername = item.CustomerName;
                    dto.ID = item.ID;
                    Customers.Add(dto);

                }
                return Customers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Customer entity)
        {
            try
            {
                Customer customer = db.Customers.First(x => x.ID == entity.ID);
                customer.CustomerName = entity.CustomerName;
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
