using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class PasswordChange : Form
    {
        public PasswordChange()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string opwd = this.maskedTextBox1.Text;
            if (this.maskedTextBox2.Text == this.maskedTextBox3.Text)
            {
                string npwd = this.maskedTextBox2.Text;
                bllUsermanager um = new bllUsermanager();
                try
                {
                    um.ChangePwd(opwd, npwd);
                    MessageBox.Show("修改密码成功");
                }
                catch 
                {
                    MessageBox.Show("密码修改失败！");
                }
            }
            else { MessageBox.Show("两次密码不一样"); }
        }
    }
}
