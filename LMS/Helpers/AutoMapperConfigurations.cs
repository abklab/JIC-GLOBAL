using AutoMapper;
using LMS.DAL;
using LMS.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Helpers
{
    public static class AutoMapperConfigurations
    {
        public static void Initialize()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<Transaction, TransactionsVM>();
                c.CreateMap<Transactions_Logs, Transactions_LogVM>();
                c.CreateMap<LoanApplication, LoanApplicationVM>();
            });

        }
    }
}