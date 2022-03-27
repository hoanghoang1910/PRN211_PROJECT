using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Repository
{
    public interface ILoginInfoRepository
    {
        int CheckLoginForSaler(string username, string password);
        bool CheckLoginForAdmin(string username, string password);
    }
}
