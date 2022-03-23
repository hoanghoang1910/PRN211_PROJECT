using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Service
{
    class RequestService
    {
        private static RequestService instance = null;
        private static readonly object instanceLock = new object();
        private ProjectPRN211Context context = new ProjectPRN211Context();
        private RequestService() { }
        public static RequestService Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RequestService();
                    }
                    return instance;
                }
            }
        }

        public List<Request> GetRequestsRemaining()
        {
            return context.Requests
                .Include(r => r.Product)
                .Include(r => r.Store)
                .Where(r => r.Status == null)
                .ToList();
        }

        public List<Request> GetRequestHandled()
        {
            return context.Requests
                .Include(r => r.Product)
                .Include(r => r.Store)
                .Where(r => r.Status != null)
                .ToList();
        }

        public void AddRequest(Request request)
        {
            request.Status = null;
            context.Requests.Add(request);
            context.SaveChanges();
        }

        public bool AcceptRequest(Request request)
        {
            AdminStock adminStock = context.AdminStocks.Find(request.ProductId);
            if (adminStock.Quantity >= request.Quantity)
            {
                request.Status = true;
                context.Requests.Update(request);
                adminStock.Quantity -= request.Quantity;
                context.AdminStocks.Update(adminStock);
                StoreStock storeStock = new StoreStock();
                storeStock = context.StoreStocks
                    .Where(s => s.StoreId == request.StoreId && s.ProductId == request.ProductId)
                    .FirstOrDefault();
                if (storeStock == null)
                {
                    StoreStock s = new StoreStock();
                    s.ProductId = request.ProductId;
                    s.Quantity = request.Quantity;
                    s.StoreId = request.StoreId;
                    context.StoreStocks.Add(s);
                }
                else
                {
                    storeStock.Quantity += request.Quantity;
                    context.StoreStocks.Update(storeStock);
                }
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DenyRequest(Request request)
        {
            request.Status = false;
            context.Requests.Update(request);
            context.SaveChanges();
        }
    }
}
