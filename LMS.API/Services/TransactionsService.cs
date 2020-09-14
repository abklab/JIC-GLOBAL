using AutoMapper;
using LMS.API.DAL;
using LMS.API.VMs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net.Http;

namespace LMS.API.Services
{
    public class TransactionsService
    {
        public string Error { get; private set; }

        private LMSdbContext db;
        public TransactionsService()
        {
            db = new LMSdbContext();
        }

        /// <summary>
        /// Get all transactions
        /// </summary>
        /// <returns>All transactions: MOMO and BANK </returns>
        public async Task<IEnumerable<TransactionsVM>> GetTransactionsAsync()
        {
            var transactions = await db.Transactions.ToListAsync();
            var vm = Mapper.Map<IEnumerable<TransactionsVM>>(transactions);
            return vm;
        }

        /// <summary>
        /// Get Transaction by EntryID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TransactionsVM> GetTransactionByID(int id)
        {
            var transaction = await db.Transactions.FindAsync(id);
            var vm = Mapper.Map<TransactionsVM>(transaction);
            return vm;
        }

        /// <summary>
        /// Post Transaction: Momo/Bank
        /// </summary>
        /// <param name="transactionVM"></param>
        /// <returns></returns>
        public async Task<TransactionsVM> SaveTransactionAsync(TransactionsVM transactionVM)
        {
            try
            {
                var transaction = Mapper.Map<Transaction>(transactionVM);
                db.Transactions.Add(transaction);
                int i = await db.SaveChangesAsync();
                if (i > 0)
                {
                    transactionVM.EntryID = transaction.EntryID;
                    return transactionVM;
                }
                else
                    throw new Exception("Unable to save transaction record.");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        internal async Task<Loan_Outstanding_3VM> GetBalanceByAccountNumber(string accountNumber)
        {
            try
            {
                var account =await db.Loan_Outstanding_3.FirstOrDefaultAsync(x => x.Account_Number == accountNumber);
                var accountvm = Mapper.Map<Loan_Outstanding_3VM>(account);
                return accountvm;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Validate customer RefNo/ Account_Number in the View vwCustomerLoanOutstanding
        /// </summary>
        /// <param name="refNo"></param>
        /// <returns></returns>
        internal bool ValidateReferenceNo(string refNo)
        {
           return db.vwCustomersLoanOutstandings.Any(a => a.Account_Number == refNo);
        }

        /// <summary>
        /// Get Transaction by RefNo
        /// </summary>
        /// <param name="refNo"></param>
        /// <returns></returns>
        public async Task<TransactionsVM> GetTransactionByRefNo(string refNo)
        {
            var transaction = await db.Transactions.FirstOrDefaultAsync(x => x.RefNo == refNo);
            var vm = Mapper.Map<TransactionsVM>(transaction);
            return vm;
        }

        //public async Task<TransactionsVM> PutTransactions_Logs(int id, Transactions_Logs transactions_Logs)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != transactions_Logs.LogID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(transactions_Logs).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!Transactions_LogsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}



        //public async Task<IHttpActionResult> DeleteTransactions_Logs(int id)
        //{
        //    Transactions_Logs transactions_Logs = await db.Transactions_Logs.FindAsync(id);
        //    if (transactions_Logs == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Transactions_Logs.Remove(transactions_Logs);
        //    await db.SaveChangesAsync();

        //    return Ok(transactions_Logs);
        //}


        /// <summary>
        /// Check if Transaction exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool TransactionExistsByEntryID(int entryid)
        {
            return db.Transactions.Count(e => e.EntryID == entryid) > 0;
        }


    }
}