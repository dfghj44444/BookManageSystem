using System;
using System.Collections.Generic;
using System.Text;
using BookManageSystem.DAL;

namespace BookManageSystem
{
     public static class Cookie
    {
         private static string _user;
         private static int _userid;
         private static bool _gpermis = false;
         private static bool _spermis = false;
         private static bool _cpermis = false;
         private static bool _lpermis = false;
         private static bool _xpermis = false;
          public static string user
          {
              
              set
              {
                  _user = value;
              }
              get
              {
                  return _user; 
                  //return "老朱";
              }
          }
          
          public static int userid
          {

              set
              {
                  _userid = value;
              }
              get
              {
                  return _userid;
                  //return 6;
              }
          }
        
        public static bool gpermis
        {
            set
            {
                _gpermis = value;
            }
            get
            {
                return _gpermis;
            }

        }
         public static bool cpermis
         {
             set
             {
                 _cpermis = value;
             }
             get
             {
                 return _cpermis;
             }

         }
         public static bool spermis
         {
             set
             {
                 _spermis = value;
             }
             get
             {
                 return _spermis;
             }

         }
         public static bool lpermis
         {
             set
             {
                 _lpermis = value;
             }
             get
             {
                 return _lpermis;
             }

         }
         public static bool xpermis
         {
             set
             {
                 _xpermis = value;
             }
             get
             {
                 return _xpermis;
             }

         }
     
         public static void Create(string regname)
         {
             dalUsers du=new dalUsers();
             _user = regname;
             _userid = du.GetIDByRegname(regname);
             gpermis = du.GetGPermissonByRegname(regname);
             spermis = du.GetSPermissonByRegname(regname);
             cpermis = du.GetCPermissonByRegname(regname);
             lpermis = du.GetLPermissonByRegname(regname);
             xpermis = du.GetXPermissonByRegname(regname);
         }
         
    }
}
