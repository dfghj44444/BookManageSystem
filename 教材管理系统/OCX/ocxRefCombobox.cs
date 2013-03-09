using System;
using System.Collections.Generic;
using System.Text;
using BookManageSystem.DAL;
using System.Windows.Forms;

namespace BookManageSystem.OCX
{
    class ocxRefCombobox
    {
        public void cmbClass(ref ComboBox cb)
        {
            dalClass dc = new dalClass();
            cb.DataSource = dc.GetClassbyStr("");//必须在设置dataGridView1的DataSource的属性前设置
            cb.DisplayMember = "Classname";
            cb.ValueMember = "ID";
        }
        public void cmbTeacher(ref ComboBox cb)
        {
            dalUsers du = new dalUsers();
            cb.DataSource = du.GetUsersByStr("lpermis=1");//必须在设置dataGridView1的DataSource的属性前设置
            cb.DisplayMember = "realname";
            cb.ValueMember = "ID";
        }
        public void cmbType(ref ComboBox cb)
        {
            ocxDGVComboBox2 ocmb2 = new ocxDGVComboBox2();
            cb.DataSource = ocmb2.SourceTable(); ;//必须在设置dataGridView1的DataSource的属性前设置
            cb.DisplayMember = "DisplayMember";
            cb.ValueMember = "ValueMember";
        }
        public void cmbGetter(ref ComboBox cb)
        {
            dalUsers du = new dalUsers();
            cb.DataSource = du.GetUsersByStr("xpermis=1");//必须在设置dataGridView1的DataSource的属性前设置
            cb.DisplayMember = "realname";
            cb.ValueMember = "ID";
        }
    }
}
