﻿using System;
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
    public partial class frmStockAlert : Form
    {
        public frmStockAlert()
        {
            InitializeComponent();
        }
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();

        private void btnOkay_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            this.Hide();
            frm.ShowDialog();
        }

        private void frmStockAlert_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.Products=dto.Products.Where(x => x.StockAmount <= 10).ToList();
            dataGridView1.DataSource = dto.Products;

            General.StyleDataGridView(dataGridView1);
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Customer Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            if (dto.Products.Count == 0)
            {
                frmMain frm = new frmMain();
                this.Hide();
                frm.ShowDialog();
            }
        }
    }
}
