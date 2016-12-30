using System;
using System.Web;
using System.Data.Entity;
using SignalRSamples.Infrastructure.Data.Ef;
using SignalRSamples.Data.Models;
using SignalRSamples.Infrastructure;

namespace SignalRSamples.Portal
{
    public class SignalRChatContextFactory : IEfDbContextFactory
    {
        /// <summary>
        /// 帮我们返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个上下文，并保证
        /// 上线问实例在线程内部是唯一的
        /// </summary>
        /// <returns></returns>
        private DbContext GetCurrentDbContext()
        {
            if (HttpContext.Current == null)
            {
                throw new ArgumentNullException("HttpContext.Current");
            }
            var context = new HttpContextWrapper(HttpContext.Current);
            const string key = "SignalRChatContext";
            DbContext dbContext;

            if (HttpContext.Current.Items.Contains(key))
            {
                dbContext = (DbContext)context.Items[key];
            }
            else
            {
                dbContext = new ChatDbContext(); //创建一个EF上下文
                context.Items.Add(key, dbContext);
            }

            return dbContext;
        }

        public DbContext GetDbContext()
        {
            lock (this)
            {
                return GetCurrentDbContext();
            }
        }
    }


}