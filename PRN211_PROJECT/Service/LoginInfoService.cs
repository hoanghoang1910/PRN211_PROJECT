using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class LoginInfoService
    {
        private static LoginInfoService instance = null;
        private static readonly object instanceLock = new object();
        private ProjectPRN211Context context = new ProjectPRN211Context();
        private LoginInfoService() { }
        public static LoginInfoService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new LoginInfoService();
                    }
                    return instance;
                }
            }
        }

        public int CheckLoginSaler(string username, string password) 
        {
            LoginInfo login = context.LoginInfos.Where(l => l.Username == username && l.Password == password).FirstOrDefault();
            if(login != null && login.Role != "Admin")
            {
                return int.Parse(login.Role);
            }
            else
            {
                return 0;
            }
        }

        public bool CheckLoginAdmin(string username, string password)
        {
            LoginInfo login = context.LoginInfos.Where(l => l.Username == username && l.Password == password).FirstOrDefault();
            if(login != null && login.Role == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
