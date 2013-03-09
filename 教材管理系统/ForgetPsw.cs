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
    public partial class ForgetPsw : Form
    {
        public ForgetPsw()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dalUsers du = new dalUsers();
            if (du.IfExistUser(textBox1.Text))
            {
                string pwd = du.GetPwdByEmail(textBox1.Text, textBox2.Text);
                if (pwd!=null)
                {
                    MessageBox.Show(pwd);
                }
                else
                {
                    MessageBox.Show("邮箱错误");
                }
            }
            else
            {
                MessageBox.Show("用户名不存在！");
            }
            
        }
    }
}
