using LMS.Contracts;
using LMS.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using LMS.DAL;

namespace LMS.Services
{
    public class TransactionsService
    {
        public Exception Error { get; private set; }

        private LMSEntities _db;
        public TransactionsService()
        {
            _db = new LMSEntities();
        }

        public TransactionsVM SaveTransactionAsync(TransactionsVM transactionVM)
        {
            try
            {
                if (transactionVM == null)
                    throw new Exception("Null or Empty Momo transaction was submitted.");

               // _db.Transactions.Add(transaction);
                return null;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public int Add_ListAsync(IEnumerable<MomoTransactionVM> transactionsVM)
        {
            throw new NotImplementedException();
        }

        public bool Delete_Transaction(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MomoTransactionVM> GetAll_Transactions()
        {
            throw new NotImplementedException();
        }

        public MomoTransactionVM Get_Transaction(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MomoTransactionVM> Search_Trancations(Expression<Func<MomoTransactionVM, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Update_Transaction(MomoTransactionVM t)
        {
            throw new NotImplementedException();
        }
    }
}