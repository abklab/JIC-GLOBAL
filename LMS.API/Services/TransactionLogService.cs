using AutoMapper;
using LMS.API.DAL;
using LMS.API.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LMS.API.Services
{
    public static class TransactionLogService
    {
        private static LMSdbContext db  = new LMSdbContext();

        /// <summary>
        /// Log Transaction_Log for Submitted Transactions
        /// </summary>
        /// <param name="transactionLog"></param>
        /// <returns></returns>
        internal static async Task LogTransaction(Transactions_LogVM transactionLogVM)
        {
            var transactionLog = Mapper.Map<Transactions_Logs>(transactionLogVM);
            db.Transactions_Logs.Add(transactionLog);
            int i = await db.SaveChangesAsync();
        }
    }
}