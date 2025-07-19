using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracker.BLL;
using StockTracker.DAL.DTO;

namespace StockTracker
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        CustomerBLL bll=new CustomerBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() == "")
                MessageBox.Show("Customer Name is Empty");
            else
            {
                if (!isUpdate)
                {
                    CustomerDetailDTO customer = new CustomerDetailDTO();
                    customer.customername = txtCustomerName.Text;
                    if (bll.Insert(customer))
                    {
                        MessageBox.Show("Customer was added");
                        txtCustomerName.Clear();
                    }
                }
                else
                {
                    if (detail.customername == txtCustomerName.Text)
                        MessageBox.Show("There is no change");
                    else 
                    {
                        detail.customername = txtCustomerName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Customer was updated.");
                                this.Close();
                        }
                    }

                }
            }
        }
        public CustomerDetailDTO detail = new CustomerDetailDTO();
        public bool isUpdate = false;
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtCustomerName.Text=detail.customername;
        }
    }
}
