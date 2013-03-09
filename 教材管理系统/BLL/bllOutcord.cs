using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BookManageSystem.DAL;

namespace BookManageSystem.BLL
{
    class bllOutcord
    {
        DataTable dt;
        DataSet ds;
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="querynum"></param>
        /// <returns></returns>
        public DataTable Query(string queryStr)
        {
            dalOutrecord dout = new dalOutrecord();
            dt = dout.GetOutrecordByStr(queryStr);
            return dt;
        }
        public DataTable Query()
        {
            dalOutrecord dout = new dalOutrecord();
            dt=dout.GetOutrecordByStr("");
            return dt;
        }
        public DataTable QueryOwn()
        {
            DataTable temp;
            DataSet tempds = new DataSet();
            //dt.Columns.Add();
            //dt.Columns[0].DataType=typeof(int);
            int flag=0;
            dalClass dc = new dalClass();
            temp=dc.GetClassByID(Cookie.userid);
            dalOutrecord dout = new dalOutrecord();
            foreach (DataRow row in temp.Rows)
            {
                if(flag==0)
                {
                    tempds.Tables.Add(dout.GetOwnOutcord(int.Parse(row[0].ToString())));
                }
                else
                {      
                    tempds.Merge(dout.GetOwnOutcord(int.Parse(row[0].ToString())));//所有购书单
                }
                flag=1;
             }
             if (tempds.Tables.Count != 0)
             {
                 return tempds.Tables[0];
             }
             else 
             {
                 return dout.GetOwnOutcord(99999);
             }
        }
        /// <summary>
        /// 新增购书单
        /// </summary>
        public int AddGetBook(string sn, int count,int cid) 
        {
            dalOutrecord dout = new dalOutrecord();
            try
            {
                dout.AddOutrecord(sn, count, cid);//添加领书单
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="e"></param>
        public void Update(int sindex)
        {
            if (dt != null)
            {
                dalOutrecord di = new dalOutrecord();
                di.Update(dt, sindex);

            }
        }
        /// <summary>
        /// 检查班费
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="count"></param>
        /// <param name="totalprice"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int CheckMoney(string sn,int count,float totalprice,int cid)
        {
            string queryStr = " stock.sn=\'" + sn + "\'";
            dalStock stock = new dalStock();
            dalClass dc = new dalClass();
            int stockcount=int.Parse(stock.GetStockByStr(queryStr).Rows[0][1].ToString());
            if (stockcount >= count)//如果有库存的话
            {
                queryStr = " class.ID=" + cid;
                if (totalprice < float.Parse(dc.GetClassbyStr(queryStr).Rows[0]["money"].ToString())) { return 3; }//如果班费够的话，审核通过，等待学生领书
                else { return 2; }//返回班费不足
            }
            else { return 1; }//返回库存不足

        }
    }
}
