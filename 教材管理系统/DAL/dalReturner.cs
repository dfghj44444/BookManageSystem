using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BookManageSystem.DAL
{
    class dalReturner
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlDataAdapter da;
        DataTable dt;
        string queryStr = "";
        public DataTable GetAllReturner()
        {
            queryStr = "select distinct *,u1.realname as operator"
                        + " from returner,users u1"
                        + " where operatorid=u1.ID";

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
