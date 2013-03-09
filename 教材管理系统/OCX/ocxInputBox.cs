using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BookManageSystem.DAL;

namespace BookManageSystem.OCX
{
    class ocxInputBox
    {
        /// <summary>
        /// //禁用审核弹出窗口
        /// </summary>
        /// <param name="Caption">标题</param>
        /// <param name="Hint">文字</param>
        /// <param name="Default">理由</param>
        /// <returns></returns>
        public string ShenheFail(string Caption, string Hint, string Default)
        {
            Form InputForm = new Form();
            InputForm.MinimizeBox = false;
            InputForm.MaximizeBox = false;
            InputForm.StartPosition = FormStartPosition.CenterScreen;
            InputForm.Width = 220;
            InputForm.Height = 150;
            InputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            //InputForm.Font.Name = "宋体";
            //InputForm.Font.Size = 10;

            InputForm.Text = Caption;
            Label lbl = new Label();
            lbl.Text = Hint;
            lbl.Left = 10;
            lbl.Top = 20;
            lbl.Parent = InputForm;
            lbl.AutoSize = true;
            TextBox tb = new TextBox();
            tb.Left = 30;
            tb.Top = 45;
            tb.Width = 160;
            tb.Parent = InputForm;
            tb.Text = Default;
            tb.SelectAll();
            Button btnok = new Button();
            btnok.Left = 30;
            btnok.Top = 80;
            btnok.Parent = InputForm;
            btnok.Text = "确定";
            InputForm.AcceptButton = btnok;//回车响应

            btnok.DialogResult = DialogResult.OK;
            Button btncancal = new Button();
            btncancal.Left = 120;
            btncancal.Top = 80;
            btncancal.Parent = InputForm;
            btncancal.Text = "取消";
            btncancal.DialogResult = DialogResult.Cancel;
            try
            {
                if (InputForm.ShowDialog() == DialogResult.OK)
                {
                    return tb.Text;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                InputForm.Dispose();
            }

        }

        /// <summary>
        /// 允许审核弹出窗口
        /// </summary>
        /// <param name="Caption">标题</param>
        /// <param name="Hint">文字</param>
        /// <param name="Default">理由</param>
        /// <returns></returns>
        public string SelectSaler(string Caption, string Hint, string SN)
        {
            Form InputForm = new Form();
            InputForm.MinimizeBox = false;
            InputForm.MaximizeBox = false;
            InputForm.StartPosition = FormStartPosition.CenterScreen;
            InputForm.Width = 220;
            InputForm.Height = 150;
            InputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            //InputForm.Font.Name = "宋体";
            //InputForm.Font.Size = 10;

            InputForm.Text = Caption;
            Label lbl = new Label();
            lbl.Text = Hint;
            lbl.Left = 10;
            lbl.Top = 20;
            lbl.Parent = InputForm;
            lbl.AutoSize = true;
            ComboBox cb = new ComboBox();//下拉列表选择供货商
            dalBooksupplier ds = new dalBooksupplier();
            cb.DataSource = ds.GetSupplierBySN(SN);
            cb.ValueMember = "ID";
            cb.DisplayMember = "supplier";
            cb.Left = 30;
            cb.Top = 45;
            cb.Width = 160;
            cb.Parent = InputForm;
            cb.Text = "请选择供货商";
            Button btnok = new Button();
            btnok.Left = 30;
            btnok.Top = 80;
            btnok.Parent = InputForm;
            btnok.Text = "确定";
            InputForm.AcceptButton = btnok;//回车响应

            btnok.DialogResult = DialogResult.OK;
            Button btncancal = new Button();
            btncancal.Left = 120;
            btncancal.Top = 80;
            btncancal.Parent = InputForm;
            btncancal.Text = "取消";
            btncancal.DialogResult = DialogResult.Cancel;
            try
            {
                if (InputForm.ShowDialog() == DialogResult.OK)
                {
                    return cb.SelectedValue.ToString();//返回供应商ID
                    //return cb.Text;//返回供应商名
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                InputForm.Dispose();
            }

        }
    }
}
