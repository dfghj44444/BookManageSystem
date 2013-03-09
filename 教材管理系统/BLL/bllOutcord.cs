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
        /// ��ѯ����
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
                    tempds.Merge(dout.GetOwnOutcord(int.Parse(row[0].ToString())));//���й��鵥
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
        /// �������鵥
        /// </summary>
        public int AddGetBook(string sn, int count,int cid) 
        {
            dalOutrecord dout = new dalOutrecord();
            try
            {
                dout.AddOutrecord(sn, count, cid);//������鵥
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// ��������
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
        /// �����
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
            if (stockcount >= count)//����п��Ļ�
            {
                queryStr = " class.ID=" + cid;
                if (totalprice < float.Parse(dc.GetClassbyStr(queryStr).Rows[0]["money"].ToString())) { return 3; }//�����ѹ��Ļ������ͨ�����ȴ�ѧ������
                else { return 2; }//���ذ�Ѳ���
            }
            else { return 1; }//���ؿ�治��

        }
    }
}
