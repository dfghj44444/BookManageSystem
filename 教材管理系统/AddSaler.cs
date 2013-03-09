using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BookManageSystem.DAL;
using BookManageSystem.BLL;

namespace BookManageSystem
{
    public partial class Addsaler : Form
    {
        public Addsaler()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//添加供应商事件
        {
            dalBooksupplier dbs = new dalBooksupplier();
            try
            {
                dbs.Create(txtSN.Text, txtSupplier.Text, txtSaler.Text, txtSalertel.Text, float.Parse(txtSalerprice.Text));
            }
            catch { MessageBox.Show("添加供应商失败"); }
            MessageBox.Show("添加供应商成功");

        }

        private void Addsaler_Load(object sender, EventArgs e)//加载事件
        {
            bllBook bb = new bllBook();
            dataGridView1.DataSource = bb.Query();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int flag = dataGridView1.SelectedCells[0].RowIndex;
            txtSN.Text = dataGridView1.Rows[flag].Cells[0].Value.ToString();
        }
    }
}
