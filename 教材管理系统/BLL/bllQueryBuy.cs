using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using BookManageSystem.DAL;

namespace BookManageSystem
{
    class bllQueryBuy
    {
        DataTable dt;
        DataSet ds;
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="e"></param>
        /// <param name="querynum">查询参数</param>
        /// <returns></returns>
        public DataTable Query(int querynum)
        {
            dalInrecord di = new dalInrecord();
            ds = new DataSet();
            switch (querynum)
            {
                case 0://查询所有数据
                    ds.Tables.Add(di.GetInrecordType5());
                    ds.Merge(di.GetInrecordType1(),false,MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType0(),false,MissingSchemaAction.Add);
                    break;
                case 1://查询所有未审核
                    ds.Tables.Add(di.GetInrecordType0());
                    break;
                case 2://查询所有已审核
                    ds.Tables.Add(di.GetInrecordType1());
                    break;
                case 3://查询所有审核不通过
                    ds.Tables.Add(di.GetInrecordType5());
                    break;
                case 4://查询所有自己发出购书单
                    ds.Tables.Add(di.GetInrecordOwn());
                    break;
                default://默认查询所有数据
                    ds.Tables.Add(di.GetInrecordType5());
                    ds.Merge(di.GetInrecordType1(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType0(), false, MissingSchemaAction.Add);
                    break;

            }
            dt = ds.Tables[0];
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
                di.Update(dt,sindex);
                
            }
        }
        /// <summary>
        /// 更改供应商
        /// </summary>
        /// <param name="sindex"></param>
        public void UpdateChecker(int sindex)
        {
            if (dt != null)
            {
                dalInrecord di = new dalInrecord();
                di.UpdateChecker(dt,sindex);
            }
        }
     
    }
}
