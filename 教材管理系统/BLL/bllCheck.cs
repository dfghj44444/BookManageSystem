using System;
using System.Collections.Generic;
using System.Text;
using BookManageSystem;
using BookManageSystem.DAL;

namespace BookManageSystem
{
   class bllCheck
    {
       
       public bool CheckRegname(string regname)
       {
           dalUsers du = new dalUsers();
           if (du.IfExistUser(regname))
           {
               return true;
           }
           return false;
       }
       public bool CheckPwd(string regname,string pwd)
       {
           dalUsers du = new dalUsers();
           if (du.IfPwdRight(regname,pwd))
           {
               return true;
           }
           return false; 
       }
    }
}
