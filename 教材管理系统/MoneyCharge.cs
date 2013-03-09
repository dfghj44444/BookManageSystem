using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BookManageSystem.DAL;

namespace BookManageSystem
{
    public partial class MoneyCharge : Form
    {
        dalClass dc = new dalClass();
        int flag = 0;
        public MoneyCharge()
        {
            InitializeComponent();
        }
         public MoneyCharge(int operation)
         {
             InitializeComponent();
            this.cmbType.Enabled = false;

            if (operation == 0)
            {
                this.Text = "书费缴纳";
                this.cmbType.SelectedIndex = 0;
                this.label2.Text = "缴纳金额";
            }
            else 
            {
                this.Text = "书费退还";
                this.cmbType.SelectedIndex = 1;
                this.label2.Text = "退还金额";
            }
         }
        private void button1_Click(object sender, EventArgs e)
        {
            float delta;
            if (this.cmbType.SelectedIndex == 0)
            {
                 delta= float.Parse(txtNmoney.Text);
            }
            else
            {
                delta = -float.Parse(txtNmoney.Text);//书费退还给学生，班费自然减少了
            }
            try
            {
                dc.UpdateMoneyByID(int.Parse(comboBox1.SelectedValue.ToString()), delta);
            }
            catch { }
            if (this.cmbType.SelectedIndex == 0)
            {
                MessageBox.Show("充值成功");
            }
            else { MessageBox.Show("退款成功"); }
            //下面刷新原有金额
            string querystr = "class.ID=\'" + comboBox1.SelectedValue + "\'";
            txtOmoney.Text = dc.GetClassbyStr (querystr).Rows[0]["money"].ToString();

        }

        private void MoneyCharge_Load(object sender, EventArgs e)
        {
            
            comboBox1.DataSource = dc.GetClassbyStr("");
            comboBox1.DisplayMember = "classname";
            comboBox1.ValueMember = "ID";
            flag = 1;
            string querystr = "class.ID=\'" + comboBox1.SelectedValue + "\'";
            txtOmoney.Text = dc.GetClassbyStr(querystr).Rows[0]["money"].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                string querystr = "class.ID=\'" + comboBox1.SelectedValue + "\'";
                txtOmoney.Text = dc.GetClassbyStr(querystr).Rows[0]["money"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
