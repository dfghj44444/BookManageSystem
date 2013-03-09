using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BookManageSystem.DAL;

namespace BookManageSystem.BLL
{
    class bllReturner
    {
        dalInrecord di = new dalInrecord();
        DataTable dt;
        DataSet ds;
        public DataTable Query(string querystr)
        {
            if (querystr == "")
            {
                try
                {
                    dt = di.GetInrecordType6();
                }
                catch { return null; }
            }
            else { dt = di.GetInrecordType6ByStr(querystr); }

            return dt;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="e"></param>
        public void Update(int sindex)
        {
            if (dt != null)
            {
                dalInrecord di = new dalInrecord();
                di.Update(dt, sindex);

            }
        }
    }
}
