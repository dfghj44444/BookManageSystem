using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BookManageSystem.DAL;
using System.Windows.Forms;

namespace BookManageSystem.BLL
{
    class bllIncord
    {
        DataTable dt;
        DataSet ds;
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="querynum"></param>
        /// <returns></returns>
        public DataTable Query(int querynum)
        {
            dalInrecord di = new dalInrecord();
            ds = new DataSet();
            switch (querynum)
            {
                case 0:
                    ds.Tables.Add(di.GetInrecordType1());//所有购书单
                    ds.Merge(di.GetInrecordType2(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType3(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType4(), false, MissingSchemaAction.Add);
                    break;
                case 1://所有待购
                    ds.Tables.Add(di.GetInrecordType1());
                    break;
                case 2://所有交涉中
                    ds.Tables.Add(di.GetInrecordType2());
                    break;
                case 3://所有已发货
                    ds.Tables.Add(di.GetInrecordType3());
                    break;
                case 4://所有已入库
                    ds.Tables.Add(di.GetInrecordType4());
                    break;
                default:
                    ds.Tables.Add(di.GetInrecordType1());//所有购书单
                    ds.Merge(di.GetInrecordType2(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType3(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType4(), false, MissingSchemaAction.Add);
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
                di.Update(dt, sindex);

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
                di.UpdateChecker(dt, sindex);
            }
        }

        public void Create(string sn,int count) 
        {
            dalInrecord di = new dalInrecord();
            di.AddInrecord(sn, count);
        }
    }
}
