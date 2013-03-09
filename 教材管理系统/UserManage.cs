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
    public partial class UserManage : Form
    {
        dalUsers du = new dalUsers();
        public UserManage()
        {
            InitializeComponent();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string regname = txtName.Text.Trim();
                if (!du.IfExistUser(regname))
                {
                    try
                    {
                        du.CreateUser(txtName.Text.Trim(), txtPwd.Text.Trim(), txtRealname.Text.Trim(), txtRole.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim(), chbg.Checked, chbs.Checked, chbc.Checked, chbl.Checked, chbx.Checked);
                    }
                    catch { }
                    MessageBox.Show("注册成功");
                }
                else { MessageBox.Show("用户名已存在"); return; }

            }
            else if (radioButton2.Checked)
            {
                string regname = txtName.Text.Trim();
                if(du.IfExistUser(regname))
                {
                    
                        if (txtPwd.Text.Trim() != null)
                        {
                            try
                            {
                                du.UpdatePwdByName(regname, txtPwd.Text.Trim());
                            }
                            catch 
                            {
                                MessageBox.Show("更新密码失败！"); return;
                            }
                        }
                        if (txtRealname.Text.Trim() != null)
                        {
                            try
                            {
                                du.UpdateRealNameByName(regname, txtRealname.Text.Trim());
                            }
                            catch { MessageBox.Show("更新姓名失败！"); return; }
                        }
                        if (txtRole.Text.Trim() != null)
                        {
                            try
                            {
                                du.UpdateRoleByName(regname, txtRole.Text.Trim());
                            }
                            catch { MessageBox.Show("更新身份失败！"); return; }
                        }
                        if (txtPhone.Text.Trim() != null)
                        {
                            try
                            {
                                du.UpdatePhoneByName(regname, txtPhone.Text.Trim());
                            }
                            catch { MessageBox.Show("更新电话失败！"); return; }
                        }
                        if (txtEmail.Text.Trim() != null)
                        {
                            try
                            {
                                du.UpdateEmailByName(regname, txtEmail.Text.Trim());
                            }
                            catch { MessageBox.Show("更新Email失败！"); return; }
                        }
                        MessageBox.Show("更新成功！");
                    
                }
                else
                {MessageBox.Show("无该用户！");
                }
 
            }
            else if (radioButton3.Checked)
            {
                string regname = txtName.Text.Trim();
                if (du.IfExistUser(regname))
                {
                    if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            du.DeleteUserByRegname(txtName.Text);
                            MessageBox.Show("删除成功");
                        }
                        catch { MessageBox.Show("删除失败"); return; }
                        
                    }
                }
                else 
                {
                    MessageBox.Show("无该用户！");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            if (!Cookie.gpermis)
            {
                MessageBox.Show("您不是管理员");
                this.Close();

            }//非管理员不能用此功能
        }
    }
}
