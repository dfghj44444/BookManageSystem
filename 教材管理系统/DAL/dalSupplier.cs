using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookManageSystem.DAL
{
    class dalSupplier
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlDataAdapter da;
        DataTable dt;
        string queryStr="";
        /// <summary>
        /// 根据SN获取供应商名
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public DataTable GetSupplierBySN(string SN)
        {
            queryStr = "SELECT * FROM booksupplier WHERE sn="+SN;
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException se)
            { }
            finally 
            {
                conn.Close();
            }
            return dt;          
        }
    }
}
