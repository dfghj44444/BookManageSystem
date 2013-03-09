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
    public partial class Entry : Form
    {
        int _id;
        string _sn;
        public Entry()
        {
            InitializeComponent();
            
        }
        public Entry(int id, string sn)
        {
            InitializeComponent();
            _id = id;
            _sn = sn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int truecount = int.Parse(textBox1.Text.Trim());
                float realpay = float.Parse(textBox1.Text.Trim());
                dalInrecord di = new dalInrecord();
                di.Entry(_id, truecount, realpay);
                MessageBox.Show("确认收货成功");
            }
            catch
            {
                MessageBox.Show("格式输入不正确!");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
