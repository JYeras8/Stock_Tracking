using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.DAL.DTO
{
    public class SalesDetailDTO
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int SalesAmount { get; set; }
        public int Price { get; set; }
        public DateTime SalesDate { get; set; }
        public int StockAmount { get; set; }
        public int SalesID { get; set; }
        public bool iscategoryDeleted{ get; set; }
        public bool iscustomerDeleted{ get; set; }
        public bool isproductDeleted{ get; set; }
    }
}
