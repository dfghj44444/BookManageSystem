using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BookManageSystem.DAL
{
    class dalUsers
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString());
        SqlDataAdapter da=new SqlDataAdapter();
        SqlCommand command;
        SqlDataReader sdr;

        public DataTable GetUsersByStr(string queryStr) 
        {
            string SqlString = "SELECT * FROM users WHERE "
                            + queryStr;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                da = new SqlDataAdapter(SqlString, conn);
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
        /// 检测用户是否存在
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public bool IfExistUser(string regname)
        {
            string querySql = "SELECT * FROM users WHERE regname=\'" + regname+"\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// 检测密码是否正确
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public bool IfPwdRight(string regname,string pwd)
        {
            string querySql = "SELECT pwd FROM users WHERE regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                sdr.Read();
                if (sdr.GetString(0) == pwd)
                {
                    return true;
                }                
            }
            catch
            {
                return false;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return false;
        }
        /// <summary>
        /// 根据用户名拿ID
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public int GetIDByRegname(string regname)
        {
            
            string querySql = "SELECT ID FROM users WHERE regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return int.Parse(sdr[0].ToString());
                }
            }
            catch 
            {
                return 0;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return 0;
        }
        /// <summary>
        /// 根据用户名判断管理员权限
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public bool GetGPermissonByRegname(string regname)
        {
            string querySql = "SELECT 1 FROM users WHERE gpermis=1 and regname=\'" + regname+"\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// 根据用户名判断审核权限
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public bool GetSPermissonByRegname(string regname)
        {
            string querySql = "SELECT 1 FROM users WHERE spermis=1 and regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// 根据用户名判断操作员权限
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public bool GetCPermissonByRegname(string regname)
        {
            string querySql = "SELECT 1 FROM users WHERE cpermis=1 and regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// 根据用户名判断老师权限
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public bool GetLPermissonByRegname(string regname)
        {
            string querySql = "SELECT 1 FROM users WHERE lpermis=1 and regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// 根据用户名判断学生权限
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public bool GetXPermissonByRegname(string regname)
        {
            string querySql = "SELECT 1 FROM users WHERE xpermis=1 and regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return false;
        }
        /// <summary>
        /// 根据用户名和邮箱找回密码
        /// </summary>
        /// <param name="regname"></param>
        /// <returns></returns>
        public string GetPwdByEmail(string regname,string email)
        {
            string querySql = "SELECT pwd FROM users WHERE regname=\'" + regname + "\' and email=\'"+email+"\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                sdr = command.ExecuteReader();
                if (sdr.Read())
                {
                    return sdr[0].ToString();
                }
            }
            catch 
            {
                return null;
            }
            finally
            {
                sdr.Close();
                conn.Close();
            }
            return null;
        }
        /// <summary>
        /// 新建用户
        /// </summary>
        /// <param name="regname"></param>
        /// <param name="pwd"></param>
        /// <param name="realname"></param>
        /// <param name="tel"></param>
        /// <param name="email"></param>
        public void CreateUser(string regname,string pwd,string realname,string tel,string email,string role,bool g,bool s,bool c,bool l,bool x)
        {
            string querySql = "INSERT INTO users(regname,pwd,realname,role,tel,email,gpermis,spermis,cpermis,lpermis,xpermis) values(\'" + regname + "\',\'" + pwd + "\',\'" + realname + "\',\'" + tel + "\',\'" + email + "\',\'" + role + "\'," + g + "," + s + "," + c + "," + l + "," + x + ")";
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
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="regname"></param>
        public void DeleteUserByRegname(string regname)
        {
            string querySql = "DELETE FROM users WHERE regname=\'" + regname + "\'";
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
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        public void UpdatePwdByName(string regname,string pwd)
        {
            string querySql = "UPDATE users SET pwd=\'"+pwd+"\'  WHERE regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                command.ExecuteReader();
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

        /// <summary>
        /// 修改姓名
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        public void UpdateRealNameByName(string regname, string realname)
        {
            string querySql = "UPDATE users SET realname=\'" + realname + "\'  WHERE regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                command.ExecuteReader();
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

        /// <summary>
        /// 修改身份
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        public void UpdateRoleByName(string regname, string role)
        {
            string querySql = "UPDATE users SET role=\'" + role + "\'  WHERE regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                command.ExecuteReader();
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

        /// <summary>
        /// 修改电话
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        public void UpdatePhoneByName(string regname, string phone)
        {
            string querySql = "UPDATE users SET tel=\'" + phone + "\'  WHERE regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                command.ExecuteReader();
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


        /// <summary>
        /// 修改Ｅｍａｉｌ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        public void UpdateEmailByName(string regname, string email)
        {
            string querySql = "UPDATE users SET email=\'" + email + "\'  WHERE regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                command.ExecuteReader();
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

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        public void UpdatePermisByName(string regname,bool g, bool s, bool c, bool l, bool x)
        {
            string querySql = "UPDATE users SET gpermis=" + g + " and  spermis=" + s + " and cpermis=" + c + " and lpermis=" + l + " and xpermis'" + x + " and and WHERE regname=\'" + regname + "\'  WHERE regname=\'" + regname + "\'";
            command = new SqlCommand(querySql, conn);
            try
            {
                conn.Open();
                command.ExecuteReader();
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
        public DataTable QueryUserByStr(string queryStr)
        {
            DataTable dt=new DataTable();
            string querySql = "SELECT * FROM users" + queryStr;
            try
            {
                conn.Open();
                da = new SqlDataAdapter(queryStr, conn);
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
