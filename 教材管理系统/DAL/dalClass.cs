using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BookManageSystem.DAL
{
    class dalClass
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlCommand command;
        SqlDataAdapter da;
        DataTable dt;
        string sqlStr = "";
        public DataTable GetClassbyStr(string queryStr)
        {
            sqlStr = "select distinct *,u1.realname as getter,u2.realname as operator,class.id as classid"
                        + " from class,users u1,users u2"
                        + " where getterid=u1.ID and operatorid=u2.ID "
                        +queryStr;

            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlStr, conn);
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

        public DataTable GetClassByID(int id)
        {
            sqlStr = "select distinct *"
                       + " from class"
                       + " where "
                       + "getterid="+id;
            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlStr, conn);
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
        public void UpdateMoneyByID(int ID, float delta) 
        {
            sqlStr = "UPDATE class SET money=money+"
                       + delta+" WHERE ID="+ID;
            command = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();               
            }
            catch { }
            finally
            {
                conn.Close();
            }
            
        }
        public void Create(string classname, DateTime admissiondate, string department, string discipline, string squad, string squadtel, string header, string headertel, int getterid,int count, string notes)
        {
            string querySql = "INSERT INTO class(classname,admissiondate,department,squad,squadtel,header,headertel,getterid,operatorid,discipline,count,money,notes) values(\'" + classname + "\',\'" + admissiondate + "\',\'" + department + "\',\'" + squad + "\',\'" + squadtel + "\',\'" + header + "\',\'" + headertel + "\'," + getterid + ","+Cookie.userid+",\'" + discipline + "\'," + count + ",0,\'"+notes+"\')";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteById(string id)
        {
            sqlStr = "DELETE FROM class WHERE id=\'" + id + "\'";
            command = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable  GetAdmissiondateByStr(string queryStr) 
        {
            sqlStr = "SELECT DISTINCT admissiondate FROM class " + queryStr;


            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlStr, conn);
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
        public DataTable GetDepartmentByStr(string queryStr)
        {
            sqlStr = "SELECT DISTINCT department FROM class " + queryStr;
            

            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlStr, conn);
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

        public DataTable GetDisciplinetByStr(string queryStr)
        {
            sqlStr = "SELECT DISTINCT discipline FROM class " + queryStr;

            try
            {
                conn.Open();
                da = new SqlDataAdapter(sqlStr, conn);
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
    }
}
