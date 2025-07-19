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
    public partial class frm_Product : Form
    {
        public frm_Product()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        public ProductDTO dto = new ProductDTO();

        public ProductDetailDTO detail = new ProductDetailDTO();
        public bool isUpdate=false;

        ProductBLL bll = new ProductBLL();

        private void frm_Product_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (isUpdate)
            {
                txtProductName.Text=detail.ProductName;
                txtPrice.Text=detail.Price.ToString();
                cmbCategory.SelectedValue = detail.CateogryID;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Product Name is Empty");
            else if (cmbCategory.SelectedIndex == -1)
                MessageBox.Show("Please Select a category");
            else if (txtPrice.Text.Trim() == "")
                MessageBox.Show("Price is empty");
            else 
            {
                if (!isUpdate) // ADD mode
                {
                    ProductDetailDTO product = new ProductDetailDTO();
                    product.ProductName = txtProductName.Text;
                    product.CateogryID = Convert.ToInt32(cmbCategory.SelectedValue);
                    product.Price = Convert.ToInt32(txtPrice.Text);

                    if (bll.Insert(product))
                    {
                        MessageBox.Show("Product was added");
                        txtPrice.Clear();
                        txtProductName.Clear();
                        cmbCategory.SelectedIndex = -1;
                    }
                }
                else // UPDATE mode
                {
                    if (detail.ProductName == txtProductName.Text &&
                        detail.CateogryID == Convert.ToInt32(cmbCategory.SelectedValue) &&
                        detail.Price == Convert.ToInt32(txtPrice.Text))
                    {
                        MessageBox.Show("There is no change");
                    }
                    else
                    {
                        detail.ProductName = txtProductName.Text;
                        detail.CateogryID = Convert.ToInt32(cmbCategory.SelectedValue);
                        detail.Price = Convert.ToInt32(txtPrice.Text);

                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Product was updated");
                            this.Close();
                        }
                    }
                }
            }
        }


    
    }
}
