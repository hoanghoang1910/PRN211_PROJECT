using PRN211_PROJECT.Repository;
using PRN211_PROJECT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.RepositoryImplementation
{
    class LoginInfoRepository : ILoginInfoRepository
    {
        public bool CheckLoginForAdmin(string username, string password)
        {
            return LoginInfoService.Instance.CheckLoginAdmin(username, password);
        }

        public int CheckLoginForSaler(string username, string password)
        {
            return LoginInfoService.Instance.CheckLoginSaler(username, password);
        }
    }
}
