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

        public List<Request> GetRequestHandled()
        {
            return RequestService.Instance.GetRequestHandled();
        }

        public List<Request> GetRequestsRemaining()
        {
            return RequestService.Instance.GetRequestsRemaining();
        }
    }
}
