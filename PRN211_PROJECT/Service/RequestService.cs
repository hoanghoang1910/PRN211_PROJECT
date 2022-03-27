using Microsoft.EntityFrameworkCore;
using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Notification noti = new Notification
            {
                NotiDate = DateTime.Now,
                NotificationMessage = $"Request from {request.Store.StoreName} created",
                NotiType = 5,
                NotiFrom = request.StoreId
            };
            context.Notifications.Add(noti);
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
                Notification noti = new Notification
                {
                    NotificationMessage = $"Request with id {request.RequestId} accepted",
                    NotiType = 3,
                    NotiDate = DateTime.Now
                };
                context.Notifications.Add(noti);
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
            Notification noti = new Notification
            {
                NotificationMessage = $"Request with id {request.RequestId} rejected",
                NotiType = 4,
                NotiDate = DateTime.Now
            };
            context.Notifications.Add(noti);
            context.SaveChanges();
        }

        public int GetNumberOfRequestsToday()
        {
            return context.Requests.Where(r => r.DateCreated.Date == DateTime.Today).Count();
        }

        public int GetNumberOfRequestsThisMonth()
        {
            return context.Requests.Where(r => r.DateCreated.Month == DateTime.Today.Month).Count();
        }

        public int GetNumberOfRequestsThisYear()
        {
            return context.Requests.Where(r => r.DateCreated.Year == DateTime.Today.Year).Count();
        }

        public int GetNumberOfRequestsThisWeek()
        {
            return context.Requests.ToList().Where(s => GetIso8601WeekOfYear(s.DateCreated) == GetIso8601WeekOfYear(DateTime.Now)).Count();
        }


        public int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public List<Request> GetAllRequestFromRetail(int storeId)
        {
            return context.Requests.Include(x => x.Store).Include(x => x.Product).Where(x => x.StoreId == storeId).ToList();
        }

        public List<Request> GetRequestsFromBetweenDate(int storeId, DateTime start, DateTime end)
        {
            return context.Requests.Include(x => x.Store).Include(x => x.Product)
                .Where(x => x.DateCreated >= start && x.DateCreated < end.AddDays(1)).Where(x => x.StoreId == storeId).ToList();
        }
    }
}
