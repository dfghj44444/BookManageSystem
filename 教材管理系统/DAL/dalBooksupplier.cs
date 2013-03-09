using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BookManageSystem.DAL
{
    class dalBooksupplier
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlCommand command=new SqlCommand();
        SqlDataAdapter da;
        DataTable dt;
        string sqlStr = "";
        public DataTable GetAllSupplier()
        {
            sqlStr = "select distinct *,u1.realname as operator,u2.realname as adder,booksupplier.altdate as altdate2,booksupplier.ID as supplierid "
                        + " from booksupplier,book,users u1, users u2"
                        + " where booksupplier.sn=book.sn and booksupplier.operatorid=u1.id and booksupplier.additionid=u2.id"
                        + " order by supplier";
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
        public DataTable GetSupplierByStr(string queryStr)
        {
            queryStr = "select distinct *,u1.realname as operator,u2.realname as adder,booksupplier.altdate as altdate2,booksupplier.ID as supplierid "
                        + " from booksupplier,book,users u1, users u2"
                        + " where booksupplier.sn=book.sn and booksupplier.operatorid=u1.id and booksupplier.additionid=u2.id "
                        + queryStr;
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
        /// <summary>
        /// 根据SN获取供应商名
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public DataTable GetSupplierBySN(string SN)
        {
            sqlStr = "SELECT * FROM booksupplier WHERE sn=" + SN;
            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlStr, conn);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch
            {return null; }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public void Create(string sn, string supplier, string saler, string salertel, float salerprice)
        {
            sqlStr = "INSERT INTO booksupplier(sn,supplier,saler,salertel,saleprice,additionid,operatorid) VALUES(\'"
            + sn + "\',\'" + supplier + "\',\'" + saler + "\',\'" + salertel + "\'," +salerprice + ","+Cookie.userid+","+Cookie.userid+")";
            command = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch { return; }
            finally { conn.Close(); }
        }
        public void DeleteSupplierById(int id)
        {
            sqlStr = "DELETE FROM booksupplier WHERE ID=\'" + id + "\'";
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
