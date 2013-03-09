using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BookManageSystem.DAL
{
    class dalOutrecord
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlCommand command;
        SqlDataAdapter da;
        DataTable dt;
        string sqlString = "";
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="e"></param>
        /// <param name="querynum">查询参数</param>
        /// <returns></returns>
        public DataTable GetOutrecordByStr(string queryStr)
        {
            sqlString = "select distinct *,price*outrecord.count as totalprice,u1.realname as teacher,u2.realname as operator ,u3.realname as getter "
                        + "from outrecord,book,class,users u1,users u2,users u3 "
                        + "where outrecord.sn=book.sn and outrecord.classid=class.ID and outrecord.tid=u1.id and outrecord.operatorid=u2.id and getterid=u3.id "
                        + queryStr;
            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlString, conn);
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
        public DataTable GetOwnOutcord(int cid)
        {
            sqlString = "select distinct *,price*outrecord.count as totalprice,u1.realname as teacher,u2.realname as operator ,u3.realname as getter "
                        + "from outrecord,book,class,users u1,users u2,users u3 "
                        + "where outrecord.sn=book.sn and outrecord.classid=class.ID and outrecord.tid=u1.id and outrecord.operatorid=u2.id and getterid=u3.id "
                        + " and state IN(2,3,4) and classid="
                        +cid;
            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlString, conn);
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
        /// <summary>
        /// 新增领书单
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="count"></param>
        public void AddOutrecord(string sn, int count,int cid)
        {
            sqlString = "INSERT INTO outrecord(sn,classid,count,tid,operatorid) VALUES(\'"
            + sn + "\'," + cid+"," + count + "," + Cookie.userid + ","+Cookie.userid+")";
            command = new SqlCommand(sqlString, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch { return; }
            finally { conn.Close(); }
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="count"></param>
        public void UpdateStateById(int sn, int count, int cid)
        {
            
        }
        /// <summary>
        /// DATAGRIDVIEW3的更新
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="e"></param>
        public void Update(DataTable dt, int sindex)
        {
            dt.Rows[sindex].EndEdit();
            //SqlCommandBuilder command = new SqlCommandBuilder(da);
            //command.GetUpdateCommand();
            SqlCommand command = new SqlCommand(
            "UPDATE outrecord SET sn = @sn, count = @count,getdate=GetDate() ,state=@state ,notes=@notes  ,operatorid=\'" + Cookie.userid + "\' " +
            " WHERE ID = @ID", conn);
            command.Parameters.Add("@sn", SqlDbType.VarChar, 20, "sn");
            command.Parameters.Add("@count", SqlDbType.Int, 20, "count");
            command.Parameters.Add("@state", SqlDbType.Int, 1, "state");
            command.Parameters.Add("@notes", SqlDbType.VarChar, 100, "notes");
            SqlParameter parameter = command.Parameters.Add(
                "@ID", SqlDbType.BigInt, 10, "ID");
            parameter.SourceVersion = DataRowVersion.Original;

            da = new SqlDataAdapter("", conn);
            da.UpdateCommand = command;

            try
            {
                conn.Open();
                da.Update(dt);
                dt.AcceptChanges();
                
            }
            catch 
            {
                return;
            }
            finally { conn.Close(); }
        }
    }
}
