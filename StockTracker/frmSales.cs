using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracker.DAL.DTO;
using StockTracker.BLL;
using System.Diagnostics.Eventing.Reader;

namespace StockTracker
{
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        public SalesDTO dto = new SalesDTO();
       public SalesDetailDTO detail = new SalesDetailDTO();
        public bool isUpdate=false;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;

            if (!isUpdate)
            {
                General.StyleDataGridView(gridProduct);
                gridProduct.DataSource = dto.Products;
                gridProduct.Columns[0].HeaderText = "Product Name";
                gridProduct.Columns[1].HeaderText = "Customer Name";
                gridProduct.Columns[2].HeaderText = "Stock Amount";
                gridProduct.Columns[3].HeaderText = "Price";
                gridProduct.Columns[4].Visible = false;
                gridProduct.Columns[5].Visible = false;

                dataGridView1.DataSource = dto.Customers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Customer Name";
                General.StyleDataGridView(dataGridView1);
                if (dto.categories.Count > 0)
                    combofull = true;
            }
            else
            {
                panel2.Hide();
                txtCustomerName.Text=detail.CustomerName;
                txtProductName.Text=detail.ProductName;
                txtPrice.Text=detail.Price.ToString();
                txtSalesAmount.Text=detail.SalesAmount.ToString();

                ProductDetailDTO product = dto.Products.First(x => x.ProductID == detail.ProductID);
                detail.StockAmount = product.StockAmount;

                txtStock.Text = detail.StockAmount.ToString();

            }
        }
        bool combofull=false;
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x=> x.CateogryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                gridProduct.DataSource = list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStock.Clear();

                }
            }

        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.customername.Contains(txtCustomerSearch.Text)).ToList();
            dataGridView1.DataSource = list;
            if(list.Count==0)
                txtCustomerName.Clear();
        }

        private void gridProduct_Enter(object sender, EventArgs e)
        {

        }

        private void gridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = gridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[3].Value);
            detail.StockAmount = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[5].Value);
            txtProductName.Text = detail.ProductName;
            txtPrice.Text=detail.Price.ToString();
            txtStock.Text=detail.StockAmount.ToString();


        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.CustomerID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            txtCustomerName.Text = detail.CustomerName;
        }

        SalesBLL bll = new SalesBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSalesAmount.Text.Trim() == "")
                MessageBox.Show("Please fill the sales amount area");
            
            else
            {
                if (!isUpdate)
                {
                    if (detail.ProductID == 0)
                        MessageBox.Show("Please select a product");
                    else if (detail.CustomerID == 0)
                        MessageBox.Show("Please select a customer from customer table");
                    else if (detail.StockAmount < Convert.ToInt32(txtSalesAmount.Text))
                        MessageBox.Show("You havent bouht enought product for sale");
                    else
                    {
                        detail.SalesAmount = Convert.ToInt32(txtSalesAmount.Text);
                        detail.SalesDate = DateTime.Today;
                        if (bll.Insert(detail))
                        {
                            MessageBox.Show("Sales was added");
                            bll = new SalesBLL();
                            dto = bll.Select();
                            gridProduct.DataSource = dto.Products;
                            dto.Customers = dto.Customers;
                            combofull = false;
                            cmbCategory.DataSource = dto.categories;
                            if (dto.Products.Count > 0)
                                combofull = false;
                            txtSalesAmount.Clear();
                        }
                    }


                }
                else  // Update
                {
                  
                    if (detail.SalesAmount == Convert.ToInt32(txtSalesAmount.Text))
                    {
                        MessageBox.Show("There is no change");
                    }
                    else
                    {
                        int temp = detail.StockAmount + detail.SalesAmount;
                        int newSalesAmount = Convert.ToInt32(txtSalesAmount.Text);

                        if (temp < newSalesAmount)
                        {
                            MessageBox.Show("You do not have enough product for sale");
                        }
                        else
                        {
                            detail.SalesAmount = newSalesAmount;
                            detail.StockAmount = temp - detail.SalesAmount;

                            if (bll.Update(detail))
                            {
                                MessageBox.Show("Sales was updated");
                                this.Close();
                            }
                        }
                    }
                }

            }

        }
    }
}
