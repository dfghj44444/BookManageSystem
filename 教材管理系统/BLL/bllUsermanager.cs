using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using BookManageSystem.DAL;


namespace BookManageSystem
{
    class bllUsermanager
    {

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="opwd"></param>
        /// <param name="npwd"></param>
        public void ChangePwd(string opwd, string npwd)
        {
            
            
            dalUsers du = new dalUsers();
            if (!du.IfPwdRight(Cookie.user, opwd)) 
            { 
                MessageBox.Show("原密码输入错误！"); 
            }

                try
                {
                    du.UpdatePwdByName(Cookie.user,npwd);
                }
                catch
                {
                    
                    return;
                }
                
       }
        public DataTable AllUser()
        {
            dalUsers du = new dalUsers();
            return du.QueryUserByStr("");
 
        }

     }
        

}

