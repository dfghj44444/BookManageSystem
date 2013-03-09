using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace BookManageSystem.DAL
{
    class dalInrecord
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlCommand command;
        SqlDataAdapter da;
        DataTable dt;
        string queryStr = "";
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="e"></param>
        /// <param name="querynum">��ѯ����</param>
        /// <returns></returns>
        public DataTable GetInrecordType0()//δ���
        {
            queryStr = "select distinct *,u1.realname as applicant,u3.realname as operator "
                        + "from inrecord,book,users u1,users u3 "
                        + "where inrecord.sn=book.sn and applicantid=u1.id and inrecord.operatorid=u3.id "
                        + "and state=0 "
                        + "order by state";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable GetInrecordType1()//ͨ�����
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                        + "and state=1 "
                        + "";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable GetInrecordType2()//���ڽ���
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                        + "and state=2";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable GetInrecordType3()//���ڷ���
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                        + "and state=3";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable GetInrecordType4()//�Ѿ����
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                        + "and state=4";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public DataTable GetInrecordType5()//���ʧ��
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                        + "and state=5";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable GetInrecordType6()//�˻���
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator,inrecord.altdate as returndate "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                        + "and state=6";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable GetInrecordType6ByStr(string querystr)//�˻���
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator,inrecord.altdate as returndate "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                        + "and "+querystr;
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable GetInrecordType7()//���ϵ�
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                        + "and state=7";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("dt");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable GetInrecordOwn()//��ѯ�Լ��������鵥
        {
            queryStr = "select distinct *,book.price*inrecord.count as totalprice,u1.realname as applicant,u2.realname as checker,u3.realname as operator "
                        + "from inrecord,book,booksupplier,users u1,users u2,users u3 "
                        + "where inrecord.sn=book.sn and inrecord.supplierid=booksupplier.id and applicantid=u1.id and checkerid=u2.id and inrecord.operatorid=u3.id "
                       + "and applicantid="+"\'"+Cookie.userid+"\'";
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable("own");
                da.Fill(dt);
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        /// <summary>
        /// ����ҳ�ĸ���
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="e"></param>
        public void Update(DataTable dt, int sindex)
        {
            dt.Rows[sindex].EndEdit();
            //SqlCommandBuilder command = new SqlCommandBuilder(da);
            //command.GetUpdateCommand();
            SqlCommand command = new SqlCommand(
            "UPDATE inrecord SET sn = @sn, count = @count,truecount=@truecount,realpayment=@realpayment,altdate=GetDate() ,state=@state ,notes=@notes ,supplierid=@supplierid ,operatorid=\'"+Cookie.userid+"\' " +
            " WHERE ID = @ID", conn);
            command.Parameters.Add("@sn", SqlDbType.VarChar, 20, "sn");
            command.Parameters.Add("@count", SqlDbType.Int, 20, "count");
            command.Parameters.Add("@truecount", SqlDbType.Int, 20, "truecount");
            command.Parameters.Add("@realpayment", SqlDbType.Money, 20, "realpayment");
            command.Parameters.Add("@state", SqlDbType.Int, 1, "state");
            command.Parameters.Add("@notes", SqlDbType.VarChar, 100, "notes");
            command.Parameters.Add("@supplierid", SqlDbType.Int, 20, "supplierid");
            SqlParameter parameter = command.Parameters.Add(
                "@ID", SqlDbType.BigInt, 10, "ID");
            parameter.SourceVersion = DataRowVersion.Original;

            da = new SqlDataAdapter("", conn);
            da.UpdateCommand = command;

            try
            {
                conn.Open();
                da.Update(dt);
                dt.AcceptChanges();
                conn.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            } 
        }

        /// <summary>
        /// ����˵ĸ���
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="e"></param>
        public void UpdateChecker(DataTable dt,int sindex)
        {
            dt.Rows[sindex].EndEdit();
            //SqlCommandBuilder command = new SqlCommandBuilder(da);
            //command.GetUpdateCommand();
            SqlCommand command = new SqlCommand(
            "UPDATE inrecord SET checkerid ="+"\'"+Cookie.userid+"\'"+
            " WHERE ID = @ID", conn);
            SqlParameter parameter = command.Parameters.Add(
                "@ID", SqlDbType.BigInt, 10, "ID");
            parameter.SourceVersion = DataRowVersion.Original;

            da = new SqlDataAdapter("", conn);
            da.UpdateCommand = command;

            try
            {
                conn.Open();
                da.Update(dt);
                dt.AcceptChanges();
                conn.Close();
            }
            catch 
            {
                return;
            }
        }

        public void AddInrecord(string sn, int count)
        {
            queryStr = "INSERT INTO inrecord(sn,count,applicantid) VALUES(\'"
            +sn+"\',"+count+","+Cookie.userid+")";
            command = new SqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch { return; }
            finally { conn.Close(); }
        }
        public void Entry(int id, int truecount, float realpay) //ȷ���ջ���������ɶ��ʵ�ʸ����ʵ������
        {
            queryStr = "UPDATE inrecord SET truecount="+truecount+",realpayment="+realpay+" WHERE id="+id;
            command = new SqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch { return; }
            finally { conn.Close(); }
        }
    }
}
