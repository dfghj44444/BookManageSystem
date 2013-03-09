using System;
using System.Collections.Generic;
using System.Text;
using BookManageSystem.DAL;
using System.Data;

namespace BookManageSystem.BLL
{
    class bllBook
    {
        DataTable dt;
        DataSet ds;
        public DataTable Query()
        {
            dalBook dbk = new dalBook();
            dt = dbk.GetAllBook();
            return dt;
        }
        public void Delete(string sn) 
        {
            dalBook dbk = new dalBook();
            dbk.DeleteBySn(sn);
        }
        public DataTable Query(string queryStr)
        {
            dalBook dbk = new dalBook();
            dt = dbk.GetBookByStr(queryStr);
            return dt;
        }
    }
}
