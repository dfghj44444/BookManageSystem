using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BookManageSystem.DAL
{
    class dalBook
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlCommand command;
        SqlDataReader sdr;
        SqlDataAdapter da;
        DataTable dt;
        string sqlStr = "";
        public DataTable GetAllBook()//获取所有图书
        {
            sqlStr = "select distinct *,u1.realname as operator,u2.realname as adder"
                        + " from book,users u1, users u2"
                        + " where book.operatorid=u1.id and book.addtionid=u2.id";

            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlStr, conn);
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
        public DataTable GetBookByStr(string queryStr)//获取所有图书
        {
            sqlStr = "select distinct *,u1.realname as operator,u2.realname as adder"
                        + " from book,users u1, users u2"
                        + " where book.operatorid=u1.id and book.addtionid=u2.id "
                        + queryStr;

            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlStr, conn);
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
        public bool CheckSN(int sn)//检查是否存在SN
        {
            sqlStr = "select 1 from book where sn="+sn;
            try
            {
                conn.Open();
                command = new SqlCommand(sqlStr, conn);
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
            }
            catch { }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return false;
        }
        public void Create(string sn,string bookname,string writer,string press,string course,string area,DateTime pressdate,float price)
        {
            string querySql = "INSERT INTO book(sn,bookname,writer,press,course,area,pressdate,price,addtionid,operatorid) values(\'" + sn + "\',\'" + bookname + "\',\'" + writer + "\',\'" + press + "\',\'" + course + "\',\'" + area + "\',\'" + pressdate + "\'," + price + ",\'" + Cookie.userid + "\',\'" + Cookie.userid + "\')";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteBySn(string sn)
        {
            sqlStr = "DELETE FROM book WHERE sn=\'" + sn + "\'";
            command = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
