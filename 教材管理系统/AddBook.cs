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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dalBook db = new dalBook();
            try
            {
                db.Create(txtSn.Text, txtBookname.Text, txtWriter.Text, txtPress.Text, txtCourse.Text, txtArea.Text, dateTimePicker1.Value, float.Parse(txtPress.Text));
            }
            catch { MessageBox.Show("添加教材信息失败！"); this.Close(); }
            MessageBox.Show("添加教材信息成功！");this.Close();
        }
    }
}
