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
    public partial class GetBook : Form
    {
        dalBook db = new dalBook();
        dalClass dc = new dalClass();
        bllOutcord bo = new bllOutcord();
        public GetBook()
        {
            InitializeComponent();
        }

        private void GetBook_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = db.GetAllBook();
            
            comboBox1.DataSource = dc.GetClassbyStr("");
            comboBox1.DisplayMember = "classname";
            comboBox1.ValueMember = "ID";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int flag = dataGridView1.SelectedCells[0].RowIndex;
            txtSN.Text = dataGridView1.Rows[flag].Cells[0].Value.ToString();
            //txtSN.AutoCompleteSource="97";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sn;
            int count;
            if (txtSN.Text.Trim() != "")
            {
                if (txtCount.Text.Trim() != "")
                {
                    try 
                    {
                        sn=txtSN.Text.Trim();
                    }
                    catch{MessageBox.Show("SN输入格式有误，请检查后重新输入！");return;}
                    try 
                    { 
                        count = int.Parse(txtCount.Text.Trim()); 
                    }
                    catch{MessageBox.Show("数量输入格式有误，请检查后重新输入！");return;}
                    if ( count!= 0)
                    {
                        try
                        {
                            bo.AddGetBook(sn, count,int.Parse(comboBox1.SelectedValue.ToString()));
                        }
                        catch { MessageBox.Show("添加购书单失败"); return; }
                        MessageBox.Show("添加购书单成功");
                        
                    }
                }
                else { MessageBox.Show("购买数量不能为空！"); }
            }
            else { MessageBox.Show("SN不能为空"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
