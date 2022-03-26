using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Repository
{
    public interface IRequestRepository
    {
        List<Request> GetRequestsRemaining();
        List<Request> GetRequestHandled();
        void AddRequest(Request request);
        bool AcceptRequest(Request request);
        void DenyRequest(Request request);
        public List<Request> GetAllRequestFromRetail(int storeId);
        public List<Request> GetRequestsFromBetweenDate(int storeId, DateTime start, DateTime end);
        int GetNumberOfRequestsToday();
        int GetNumberOfRequestsThisMonth();
        int GetNumberOfRequestsThisYear();
        int GetNumberOfRequestsThisWeek();
    }
}
