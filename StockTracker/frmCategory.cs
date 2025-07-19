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
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        CategoryBLL bll = new CategoryBLL();
        public CategoryDetailDTO detail = new CategoryDetailDTO();
        public bool isUpdate= false;
        private void frmCategory_Load(object sender, EventArgs e)
        {
            if(isUpdate)
                txtCategoryName.Text = detail.CategoryName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Trim() == "")
                MessageBox.Show("Category Name is Empty");
            else
            {
                if (!isUpdate)//add
                {
                    CategoryDetailDTO category = new CategoryDetailDTO();
                    category.CategoryName = txtCategoryName.Text;
                    if (bll.Insert(category))
                    {
                        MessageBox.Show("Category was added");
                        txtCategoryName.Clear();
                    }
                }
                else if (isUpdate)
                {
                    if (detail.CategoryName == txtCategoryName.Text.Trim())
                        MessageBox.Show("There are no changes");
                    else
                    {

                        detail.CategoryName = txtCategoryName.Text;
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("Category was updated");
                        this.Close();
                    }

                    }
                }
                
            }

        }
    }
}
