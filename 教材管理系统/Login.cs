using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BookManageSystem.DAL;
using BookManageSystem;

namespace BookManageSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //禁用窗体右上角最小化最大化按钮
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x00000000;
        private const int MF_GRAYED = 0x00000001;
        private const int MF_DISABLED = 0x00000002;
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern bool EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uEnable);

        private void Login_Load(object sender, EventArgs e)
        {
            //禁用窗体右上角关闭按钮
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            EnableMenuItem(hMenu, SC_CLOSE, MF_DISABLED | MF_GRAYED);

        }

        private void btnClose_Click(object sender, EventArgs e)//关闭整个程序
        {
            //this.Close();

            System.Environment.Exit(0); 

        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            bllCheck chk = new bllCheck();
            if (chk.CheckRegname(this.maskedTextBox1.Text))
            {
                if (chk.CheckPwd(this.maskedTextBox1.Text, this.maskedTextBox2.Text))
                {
 
                }
                else
                {
                    MessageBox.Show("密码错误！");
                    return;
                }
            }
            else 
            {
                MessageBox.Show("用户名不存在！");
                return;
            }
            //开始生成用户信息COOKIE
            Cookie.Create(this.maskedTextBox1.Text);
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPsw fp = new ForgetPsw();
            fp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cookie.Create("xs");
            this.Close();
        }

    }
}
