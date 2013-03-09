using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BookManageSystem.DAL;

namespace BookManageSystem.BLL
{
    class bllStock
    {
        DataTable dt;
        DataSet ds;
        public DataTable Query()
        {
            dalStock dst = new dalStock();
            dt = dst.GetAllStock();
            return dt;
        }
        public DataTable Query(string queryStr)
        {
            dalStock dst = new dalStock();
            dt = dst.GetStockByStr(queryStr);
            return dt;
        }
    }
}
