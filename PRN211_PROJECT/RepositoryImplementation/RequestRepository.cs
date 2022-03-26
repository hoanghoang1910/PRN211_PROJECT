using PRN211_PROJECT.Models;
using PRN211_PROJECT.Repository;
using PRN211_PROJECT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.RepositoryImplementation
{
    class RequestRepository : IRequestRepository
    {
        public bool AcceptRequest(Request request)
        {
            return RequestService.Instance.AcceptRequest(request);
        }

        public void AddRequest(Request request)
        {
            RequestService.Instance.AddRequest(request);
        }

        public void DenyRequest(Request request)
        {
            RequestService.Instance.DenyRequest(request);
        }

        public int GetNumberOfRequestsThisMonth()
        {
            return RequestService.Instance.GetNumberOfRequestsThisMonth();
        }

        public int GetNumberOfRequestsThisWeek()
        {
            return RequestService.Instance.GetNumberOfRequestsThisWeek();
        }

        public int GetNumberOfRequestsThisYear()
        {
            return RequestService.Instance.GetNumberOfRequestsThisYear();
        }

        public int GetNumberOfRequestsToday()
        {
            return RequestService.Instance.GetNumberOfRequestsToday();
        }

        public List<Request> GetRequestHandled()
        {
            return RequestService.Instance.GetRequestHandled();
        }

        public List<Request> GetRequestsRemaining()
        {
            return RequestService.Instance.GetRequestsRemaining();
        }

        public List<Request> GetAllRequestFromRetail(int storeId) => RequestService.Instance.GetAllRequestFromRetail(storeId);
        public List<Request> GetRequestsFromBetweenDate(int storeId, DateTime start, DateTime end) => RequestService.Instance.GetRequestsFromBetweenDate(storeId, start, end);
    }
}
