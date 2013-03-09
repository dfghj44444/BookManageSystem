using System;
using System.Collections.Generic;
using System.Text;
using BookManageSystem.DAL;
using System.Data;

namespace BookManageSystem.BLL
{
    class bllBooksupplier
    {
        DataTable dt;
        DataSet ds;
        public DataTable Query()
        {
            dalBooksupplier dbs = new dalBooksupplier();
            dt = dbs.GetAllSupplier();
            return dt;
        }
        public DataTable Query(string queryStr)
        {
            dalBooksupplier dbs = new dalBooksupplier();
            dt = dbs.GetSupplierByStr(queryStr);
            return dt;
        }
        public void Delete(int id)
        {
            dalBooksupplier dbs = new dalBooksupplier();
            dbs.DeleteSupplierById(id);
        }
    }
}
