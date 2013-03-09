using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BookManageSystem.OCX;
using BookManageSystem.BLL;

namespace BookManageSystem
{
    public partial class MainForm : Form
    {
        bllQueryBuy buy = new bllQueryBuy();
        int Aflag = 0;//用以标记查询值
        bllIncord incord = new bllIncord();
        int Bflag = 0;
        bllOutcord outcord = new bllOutcord();
        string outcordStr = "";
        bllStock stock = new bllStock();
        string stockStr = "";
        bllBooksupplier booksupplier = new bllBooksupplier();
        string supplierStr = "";
        bllBook book = new bllBook();
        string bookStr = "";
        bllClass cla = new bllClass();
        string claStr = "";
        bllReturner returner = new bllReturner();
        string returnerStr = "";
        public MainForm()
        {
            InitializeComponent();
        }


     
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PasswordChange pswc = new PasswordChange();
            pswc.Show();
        }

        /// <summary>
        /// 开始加载页面
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView4.AutoGenerateColumns = false;
            dataGridView5.AutoGenerateColumns = false;
            dataGridView6.AutoGenerateColumns = false;
            dataGridView7.AutoGenerateColumns = false;
            dataGridView8.AutoGenerateColumns = false;

            Login lgn = new Login();
            lgn.ShowDialog();
            dataGridView1.DataSource = buy.Query(0);
            ocxDGVComboBox dgvCB = new ocxDGVComboBox();
            dgvCB.getState(ref dataGridView1);//购书单获取状态下拉框
            dataGridView2.DataSource = incord.Query(0);
            dgvCB.getState(ref dataGridView2);
            ocxDGVComboBox2 dgvCB2 = new ocxDGVComboBox2();
            dataGridView3.DataSource = outcord.Query();
            dgvCB2.getState(ref dataGridView3);
            dataGridView4.DataSource = stock.Query();
            dataGridView5.DataSource = booksupplier.Query();
            dataGridView6.DataSource = book.Query(bookStr);
            dataGridView7.DataSource = cla.Query(claStr);
            dataGridView8.DataSource = returner.Query(returnerStr);
            dgvCB.getState(ref dataGridView8);//退货单获取状态下拉框
            #region 学生只能看到领书单和教材,其他什么都点不了
            if (Cookie.gpermis == true || Cookie.cpermis == true || Cookie.spermis == true || Cookie.lpermis == true)
            {

            }
            else 
            {
                this.tabControl1.TabPages.Remove(tabPage1);
                this.tabControl1.TabPages.Remove(tabPage2);
                this.tabControl1.TabPages.Remove(tabPage4);
                this.tabControl1.TabPages.Remove(tabPage5);
                this.tabControl1.TabPages.Remove(tabPage7);
                this.tabControl1.TabPages.Remove(tabPage8);
                dataGridView3.DataSource = outcord.Query();
                //this.groupBox1.Visible = false;
                bllOutcord tempbo=new bllOutcord();
                tempbo.QueryOwn();//只能查看自己班的状态正常领书单
                btnOutSearch3.Enabled = false;
                button32.Enabled=false;
                button35.Enabled=false;
                button36.Enabled = false;

            }
            if (Cookie.gpermis == false)//非审核权限者审核按钮全变灰
            {
                btnA6.Enabled = false;
                btnA7.Enabled = false;
                btnOutCheck.Enabled = false;
                btnOutCheckFail.Enabled = false;
                btnOutSearchAll3.Enabled = false;
            }
            #endregion

            ocxRefCombobox orc = new ocxRefCombobox();//领书单页面三个下拉框
            orc.cmbClass(ref cmbOut1);
            orc.cmbTeacher(ref cmbOut2);
            orc.cmbType(ref cmbOut3);
            cla.InitCmb(ref cmbclass1,ref cmbclass2,ref cmbclass3);

        }

 

 





        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UserManage um = new UserManage();
            um.Show();
         
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MoneyCharge mc = new MoneyCharge(0);
            mc.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MoneyCharge mc = new MoneyCharge(1);
            mc.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordChange pw=new PasswordChange();
            pw.Show();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManage um = new UserManage();
            um.Show();
            
        }

        private void 班级管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        private void 供应商管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void 书籍管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 书费缴纳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoneyCharge mc = new MoneyCharge(0);
            mc.Show();
        }

        private void 书费退还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoneyCharge mc = new MoneyCharge(1);
            mc.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void 教材申请单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBook gb = new GetBook();
            gb.Show();
        }

        private void 教材入库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }





        private void 库存查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void 书籍查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }





         #region 页面1内容
            private void btnA1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = buy.Query(1);//查询所有未审核
            Aflag=1;
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = buy.Query(2);//查询所有已审核
            Aflag = 2;
        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = buy.Query(3);//查询所有审核未过
            Aflag = 3;
        }

        private void btnA4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = buy.Query(0);
            Aflag = 4;
        }

        private void btnA5_Click(object sender, EventArgs e)
        {
            
            tabControl1.SelectedTab = tabPage6;
            MessageBox.Show("请选择要购买的教材，然后查找其供应商后发起购书单！");
        }

        private void btnA6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                int sindex = dataGridView1.SelectedRows[0].Index;
                ocxInputBox ib = new ocxInputBox();
                string tempstr=ib.SelectSaler("通过审核", "请选择供货商", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                if(tempstr!=null)
                {
                    dataGridView1.Rows[sindex].Cells["ClmSupplierid"].Value = tempstr;
                    dataGridView1.Rows[sindex].Cells["ClmState"].Value = "1";
                    buy.UpdateChecker(sindex);
                }
            }
            dataGridView1.DataSource = buy.Query(Aflag);//刷新页面
        }
  
        private void btnA7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                int sindex = dataGridView1.SelectedRows[0].Index;
                ocxInputBox ib = new ocxInputBox();
                string tempstr = ib.ShenheFail("请输入备注", "请输入禁用的理由", "在此输入理由");
                if(tempstr!=null)
                {
                    dataGridView1.SelectedRows[0].Cells["ClmNotes"].Value = tempstr;
                    dataGridView1.Rows[sindex].Cells["ClmState"].Value = "5";
                }
            }
        }

        private void btnA8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = buy.Query(4);//查询自己发出购书单
        }

        /// <summary>
        /// 修改数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            buy.Update(e.RowIndex);
            dataGridView1.Refresh();
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("真的要修改吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView1_CellValueChanged(sender, e);
            }
            dataGridView1.DataSource= buy.Query(Aflag);            
        }

        #endregion 页面1内容完毕







        #region 页面2开始
        private void btnB1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = incord.Query(1);
            Bflag = 1;

        }
        /// <summary>
        /// 表2变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            incord.Update(e.RowIndex);
            dataGridView2.Refresh();
        }        

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("真的要修改吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                dataGridView2_CellValueChanged(sender, e);
            }
            dataGridView2.DataSource = buy.Query(Bflag);
        }

        private void btnB2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = incord.Query(2);
            Bflag = 2;
        }

        private void btnB3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = incord.Query(3);
            Bflag = 3;
        }

        private void btnB4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = incord.Query(4);
            Bflag = 4;
        }

        private void btnB5_Click(object sender, EventArgs e)//指定采办人
        {
            int sindex = dataGridView2.SelectedRows[0].Index;
            ocxInputBox ib = new ocxInputBox();
            string tempstr = ib.ShenheFail("请输入采购人", "请输入采购人的姓名", "在此输入姓名");
            if (tempstr != null)
            {
                dataGridView2.Rows[sindex].Cells["ClmBuyer2"].Value = tempstr;
            }
            incord.Query(Bflag);
        }

        private void btnB6_Click(object sender, EventArgs e)
        {
            //ChangeSaler cs = new ChangeSaler();
            //cs.Show();
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                int sindex = dataGridView2.SelectedRows[0].Index;
                ocxInputBox ib = new ocxInputBox();
                string tempstr = ib.SelectSaler("更改供应商", "请选择供货商", dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                if (tempstr != null)
                {
                    dataGridView2.Rows[sindex].Cells["ClmSupplierid2"].Value = tempstr;
                    dataGridView2.Rows[sindex].Cells["ClmState2"].Value = "1";
                    incord.UpdateChecker(sindex);
                }
            }
            dataGridView2.DataSource = buy.Query(Bflag);//刷新页面
        }

        private void btnB7_Click(object sender, EventArgs e)
        {
            
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                int sindex = dataGridView2.SelectedRows[0].Index;
                if (MessageBox.Show("真的要退货吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    dataGridView2.Rows[sindex].Cells["ClmState2"].Value = "6";
                } 
            }
            dataGridView2.DataSource = buy.Query(Bflag);//刷新页面
        }

        private void btnB8_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = incord.Query(0);
            Bflag = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                int sindex = dataGridView2.SelectedRows[0].Index;
                Entry en = new Entry(int.Parse(dataGridView2.Rows[sindex].Cells["ID"].Value.ToString()),dataGridView2.Rows[sindex].Cells[0].Value.ToString());
                en.Show();
                
            }
            dataGridView2.DataSource = incord.Query(Bflag);//刷新页面

        }
        #endregion






        
        #region 第三页页面
        private void button24_Click(object sender, EventArgs e)//学生确认收货
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                dataGridView3.SelectedRows[0].Cells["ClmState3"].Value = 4;
            }
        }
        private void button22_Click(object sender, EventArgs e)//新增领书单
        {
            GetBook gb = new GetBook();
            gb.Show();
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)//表单变化事件
        {
            outcord.Update(e.RowIndex);
            dataGridView3.Refresh();
        }

        private void btnOutCheck_Click(object sender, EventArgs e)//领书单审核
        {
            if (dataGridView3.SelectedRows[0].Cells["ClmState3"].Value.ToString() == "3" || dataGridView3.SelectedRows[0].Cells["ClmState3"].Value.ToString() == "4" || dataGridView3.SelectedRows[0].Cells["ClmState3"].Value.ToString() == "5")
            { MessageBox.Show("已经审核通过，不可再次审核"); }
            else
            {
                dataGridView3.SelectedRows[0].Cells["ClmState3"].Value = outcord.CheckMoney(dataGridView3.SelectedRows[0].Cells["ClmSn3"].Value.ToString(), int.Parse(dataGridView3.SelectedRows[0].Cells["ClmCount3"].Value.ToString()), float.Parse(dataGridView3.SelectedRows[0].Cells["ClmTotalprice3"].Value.ToString()), int.Parse(dataGridView3.SelectedRows[0].Cells["Clmcid3"].Value.ToString()));
            }
        }
        

        private void btnReCheck_Click(object sender, EventArgs e)//重新查找所有
        {
            dataGridView3.DataSource = outcord.Query();
        }

        private void btnOutCheckFail_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要作废之吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView3.SelectedRows[0].Cells["ClmState3"].Value = "5";
            }
        }

        private void btnOutSearch_Click(object sender, EventArgs e)
        {
            string queryStr = "and class.ID=" + int.Parse(cmbOut1.SelectedValue.ToString()) + "  and  u1.ID=" + int.Parse(cmbOut2.SelectedValue.ToString()) + " and outrecord.state=" + int.Parse(cmbOut3.SelectedValue.ToString());
            dataGridView3.DataSource= outcord.Query(queryStr);
        }
        #endregion

        


        #region 第四页
        private void button26_Click(object sender, EventArgs e)//查找所有按钮
        {
            dataGridView4.DataSource = stock.Query();
        }


        private void txtStockSearch_Click(object sender, EventArgs e)//开始查找按钮
        {

            if (cmbStock.SelectedIndex == 0)
            {
                stockStr = " and book.sn LIKE \'%" + txtStock.Text + "%\' ";
            }
            else if (cmbStock.SelectedIndex == 1)
            {
                stockStr = " and bookname LIKE \'%" + txtStock.Text + "%\' ";
            }
            else if (cmbStock.SelectedIndex == 2)
            {
                stockStr = " and writer LIKE \'%" + txtStock.Text + "%\' ";
            }
            else if (cmbStock.SelectedIndex == 3)
            {
                stockStr = " and press LIKE \'%" + txtStock.Text + "%\' ";
            }
            else if (cmbStock.SelectedIndex == 4)
            {
                stockStr = " and course LIKE \'%" + txtStock.Text + "%\' ";
            }
            else if (cmbStock.SelectedIndex == 5)
            {
                stockStr = " and area LIKE \'%" + txtStock.Text + "%\' ";
            }
            else
            {
                stockStr = "";//用完清空
            }
                if (radioButton1.Checked == true)
                {
                    stockStr += " and price BETWEEN " + float.Parse(txtNum1.Text) + " and " + float.Parse(txtNum2.Text);
                }
                else if (radioButton2.Checked == true)
                {
                    stockStr += " and stock.count BETWEEN " + float.Parse(txtNum1.Text) + " and " + float.Parse(txtNum2.Text);
                }
                else if (radioButton3.Checked == true)
                {
                    stockStr += " and price*count  BETWEEN " + float.Parse(txtNum1.Text) + " and " + float.Parse(txtNum2.Text);
                }
                dataGridView4.DataSource = stock.Query(stockStr);
            }
        
        #endregion

        #region 第五页

        private void button41_Click(object sender, EventArgs e)//新增购书单
        {
            if (dataGridView5.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else 
            {
                int sindex = dataGridView5.SelectedRows[0].Index;
                string SN = dataGridView5.Rows[sindex].Cells["clm5sn"].Value.ToString();
                ocxInputBox inputbox = new ocxInputBox();
                int count = int
                    .Parse(inputbox.ShenheFail("输入购买数量","请输入购买数量","1"));
                incord.Create(SN,count);
                dataGridView1.DataSource = buy.Query(0);
                MessageBox.Show("添加购书单成功");
            }

        }


        private void button1_Click(object sender, EventArgs e)//开始查找按钮
        {
            if (cmbSupplier.SelectedIndex == 0)
            {
                supplierStr = " and book.sn LIKE \'%" + txtSupplier.Text + "%\' ";
            }
            else if (cmbSupplier.SelectedIndex == 1)
            {
                supplierStr = " and bookname LIKE \'%" + txtSupplier.Text + "%\' ";
            }
            else if (cmbSupplier.SelectedIndex == 2)
            {
                supplierStr = " and writer LIKE \'%" + txtSupplier.Text + "%\' ";
            }
            else if (cmbSupplier.SelectedIndex == 3)
            {
                supplierStr = " and press LIKE \'%" + txtSupplier.Text + "%\' ";
            }
            else if (cmbSupplier.SelectedIndex == 4)
            {
                supplierStr = " and course LIKE \'%" + txtSupplier.Text + "%\' ";
            }
            else if (cmbSupplier.SelectedIndex == 5)
            {
                supplierStr = " and area LIKE \'%" + txtSupplier.Text + "%\' ";
            }
            else if (cmbSupplier.SelectedIndex == 6)
            {
                supplierStr = " and supplier LIKE \'%" + txtSupplier.Text + "%\' ";
            }
            else if (cmbSupplier.SelectedIndex == 7)
            {
                supplierStr = " and saler LIKE \'%" + txtSupplier.Text + "%\' ";
            }
            else { supplierStr = ""; }
            if (checkBox3.Checked == true)
            {
                supplierStr += " and saleprice BETWEEN " + float.Parse(txtnum3.Text) + " and " + float.Parse(txtnum4.Text);
            }
            dataGridView5.DataSource = booksupplier.Query(supplierStr);
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Addsaler ads = new Addsaler();
            ads.Show();
        }
        private void btnAllStock_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = stock.Query();
        }

        private void button23_Click(object sender, EventArgs e)//删除供应商
        {
            if (dataGridView5.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        booksupplier.Delete(int.Parse(dataGridView5.SelectedRows[0].Cells["Clm5supplierid"].Value.ToString()));
                    }
                    catch { MessageBox.Show("删除失败"); return; }
                    MessageBox.Show("删除成功");
                    dataGridView5.DataSource = booksupplier.Query(supplierStr);//刷新gridview
                }
            }
        }
        #endregion


        #region 第六页

        private void button35_Click(object sender, EventArgs e)//新增教材
        {
            AddBook adb = new AddBook();
            adb.Show();
        }

        

       
        private void button32_Click(object sender, EventArgs e)//删除教材
        {
            if (dataGridView6.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        book.Delete(dataGridView6.SelectedRows[0].Cells["Clm6sn"].Value.ToString());
                    }
                    catch { MessageBox.Show("删除失败"); return; }
                    MessageBox.Show("删除成功");
                    dataGridView6.DataSource = book.Query(bookStr);//刷新gridview
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//查看所有
        {
            bookStr = "";
            dataGridView6.DataSource = book.Query(bookStr);
        }

        private void button36_Click(object sender, EventArgs e)//查找其供应商
        {
            if (dataGridView6.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                string sn = dataGridView6.SelectedRows[0].Cells["Clm6sn"].Value.ToString();
                supplierStr = " and booksupplier.sn=\'" + sn + "\'";
                dataGridView5.DataSource = booksupplier.Query(supplierStr);
                this.tabControl1.SelectedIndex = 4;
                this.tabControl1.TabPages[4].Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)//查找按钮
        {
            if (cmbBook.SelectedIndex == 0)
            {
                bookStr = " and book.sn LIKE \'%" + txtBook.Text + "%\' ";
            }
            else if (cmbBook.SelectedIndex == 1)
            {
                bookStr = " and bookname LIKE \'%" + txtBook.Text + "%\' ";
            }
            else if (cmbBook.SelectedIndex == 2)
            {
                bookStr = " and writer LIKE \'%" + txtBook.Text + "%\' ";
            }
            else if (cmbBook.SelectedIndex == 3)
            {
                bookStr = " and press LIKE \'%" + txtBook.Text + "%\' ";
            }
            else if (cmbBook.SelectedIndex == 4)
            {
                bookStr = " and course LIKE \'%" + txtBook.Text + "%\' ";
            }
            else if (cmbBook.SelectedIndex == 5)
            {
                bookStr = " and area LIKE \'%" + txtBook.Text + "%\' ";
            }
            else
            {
                bookStr = "";//用完清空
            }
            if (chbBook.Checked == true)
            {
                bookStr += " and price BETWEEN " + float.Parse(txtNum5.Text) + " and " + float.Parse(txtNum6.Text);
            }
            dataGridView6.DataSource = book.Query(bookStr);
        }
        #endregion

        #region 第七页
        private void button29_Click(object sender, EventArgs e)//删除班级
        {
            if (dataGridView7.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cla.DeleteById(dataGridView7.SelectedRows[0].Cells["ClmClassid7"].Value.ToString());
                    }
                    catch { MessageBox.Show("删除失败"); return; }
                    MessageBox.Show("删除成功");
                    dataGridView7.DataSource = cla.Query(claStr);//刷新gridview
                }
            }
        }

        private void button34_Click(object sender, EventArgs e)//添加班级
        {
            AddClass adc = new AddClass();
            adc.Show();
        }



        private void button27_Click(object sender, EventArgs e)//查找按钮
        {
            string querystr = " and admissiondate=\'" + cmbclass1.SelectedValue.ToString() + "\' and department=\'" + cmbclass2.SelectedValue.ToString() + "\' and discipline=\'" + cmbclass3.SelectedValue.ToString() + "\' ";
            if (chbsquad.Checked == true)
            { querystr += " and squad LIKE \'%" + txtSquad.Text + "%\' "; }
            if (chbheader.Checked == true)
            { querystr += " and header LIKE \'%" + txtHeader.Text + "%\'"; }
            dataGridView7.DataSource = cla.Query(querystr);

        }

        #endregion

        #region 第八页
        private void dataGridView8_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            returner.Update(e.RowIndex);


        }

        private void dataGridView8_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("真的要修改吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                dataGridView8_CellValueChanged(sender, e);
            }
            dataGridView8.DataSource = returner.Query(returnerStr);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (dataGridView8.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择任何行");
            }
            else
            {
                int sindex = dataGridView8.SelectedRows[0].Index;
                ocxInputBox ib = new ocxInputBox();
                string tempstr = ib.ShenheFail("请输入备注", "请输入取消的理由", "在此输入理由");
                if (tempstr != null)
                {
                    dataGridView8.SelectedRows[0].Cells["ClmNotes8"].Value = tempstr;
                    dataGridView8.Rows[sindex].Cells["ClmState8"].Value = "3";
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)//退货单查找
        {
            returnerStr = "inrecord.altdate BETWEEN \'" + dateTimePicker3.Value + "\' AND \'" + dateTimePicker4.Value + "\'";
            returner.Query(returnerStr);
        }

        #endregion



    }
}
