using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BookManageSystem.DAL
{
    class dalStock
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlDataAdapter da;
        DataTable dt;
        string queryStr = "";
        public DataTable GetAllStock()
        {
            queryStr = "select distinct * ,price*count as totalprice,users.realname as operator "
                       + " from stock,book,users "
                       + " where stock.sn=book.sn and book.operatorid=users.ID";
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
        /// 利用字符串的查询
        /// </summary>
        /// <param name="querStr"></param>
        /// <returns></returns>
        public DataTable GetStockByStr(string querStr)
        {
            queryStr = "select distinct * ,price*count as totalprice,users.realname as operator "
                       + " from stock,book,users where "
                       + "  stock.sn=book.sn and book.operatorid=users.ID "
                       + querStr;
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
    }
}
