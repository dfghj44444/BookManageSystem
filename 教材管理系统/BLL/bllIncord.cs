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
        /// ��ѯ����
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
                    ds.Tables.Add(di.GetInrecordType1());//���й��鵥
                    ds.Merge(di.GetInrecordType2(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType3(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType4(), false, MissingSchemaAction.Add);
                    break;
                case 1://���д���
                    ds.Tables.Add(di.GetInrecordType1());
                    break;
                case 2://���н�����
                    ds.Tables.Add(di.GetInrecordType2());
                    break;
                case 3://�����ѷ���
                    ds.Tables.Add(di.GetInrecordType3());
                    break;
                case 4://���������
                    ds.Tables.Add(di.GetInrecordType4());
                    break;
                default:
                    ds.Tables.Add(di.GetInrecordType1());//���й��鵥
                    ds.Merge(di.GetInrecordType2(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType3(), false, MissingSchemaAction.Add);
                    ds.Merge(di.GetInrecordType4(), false, MissingSchemaAction.Add);
                    break;
            }
            dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// ��������
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
        /// ���Ĺ�Ӧ��
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
