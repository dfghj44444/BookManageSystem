using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BookManageSystem.DAL;
using BookManageSystem.OCX;

namespace BookManageSystem
{
    public partial class AddClass : Form
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//添加班级事件
        {
            dalClass dc = new dalClass();
            try
            {
                dc.Create(txtClassname.Text, dateTimePicker1.Value, txtDepartment.Text, txtDiscipline.Text, txtSquad.Text, txtSquadtel.Text, txtHeader.Text, txtHeadertel.Text, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtCount.Text), txtNotes.Text);
            }
            catch { MessageBox.Show("添加班级失败");this.Close(); }
            MessageBox.Show("添加班级成功！");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddClass_Load(object sender, EventArgs e)
        {
            ocxRefCombobox orc = new ocxRefCombobox();//初始化下拉框
            orc.cmbClass(ref comboBox1);
        }
    }
}
