using System.Threading.Tasks;
using System.Web.Http;
using LMS.API.Services;
using System;
using LMS.API.VMs;

namespace LMS.API.Controllers.V1
{
    [RoutePrefix("api/v2000/_transactions")]
    public class TransactionsController : ApiController
    {
        private static string _year = DateTime.Today.Year.ToString();
        private readonly TransactionsService _service;

        public TransactionsController()
        {
            _service = new TransactionsService();
        }

        [Route("all")]
        [HttpGet()]
        public async Task<IHttpActionResult> GetTransactions()
        {
            var list = await _service.GetTransactionsAsync();
            if (list == null)
                return NotFound();
            return Ok(list);
        }


        /// <summary>
        /// Find Transaction by RefNo
        /// </summary>
        /// <param name="refno"></param>
        /// <returns></returns>
        [Route("_refno/{refno}")]
        [HttpGet()]
        public async Task<IHttpActionResult> GetBankTransactionsByRefNo(string refno)
        {
            var vm = await _service.GetTransactionByRefNo(refno);
            if (vm == null)
                return NotFound();
            return Ok(vm);
        }



        /// <summary>
        /// MOMO Balance Entry by Account number
        /// </summary>
        /// <param name="refno"></param>
        /// <returns></returns>
        [Route("_balanceInquiry/{accountNumber}")]
        [HttpGet()]
        public async Task<IHttpActionResult> GetBalanceByAccountNumber(string accountNumber)
        {
            var vm = await _service.GetBalanceByAccountNumber(accountNumber);
            if (vm == null)
                return NotFound();
            return Ok(vm);
        }

        /// <summary>
        /// Momo Transaction endpoint
        /// </summary>
        /// <param name="momovm"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("_momopost/mp-500/repayments")]
        public async Task<IHttpActionResult> MomoPost(MomoTransactionVM momovm)
        {
            var transactionLogVM = new Transactions_LogVM();
            if (momovm == null)
                return BadRequest("An empty/null MOMO Transaction was submitted.");

            //validate RefNo
            var isValidRefNo = _service.ValidateReferenceNo(momovm.RefNo);
            if (!isValidRefNo)
            {
                //Log MOMO Transaction with Invalid RefNo

                transactionLogVM.Descriptions = $"Account {momovm.MomoNumber} submitted payment with an INVALID Reference Number.(Type:Bank; Provider:{momovm.MNO}; TransactionID:{momovm.TransactionID}; Amount:{momovm.Amount})";
                transactionLogVM.LogEntryDateTime = DateTime.Now;

                await TransactionLogService.LogTransaction(transactionLogVM);
                return BadRequest("Invalid Reference Number (RefNo).");
            }

            TransactionsVM transactionVM = new TransactionsVM()
            {
                AccountNumber = momovm.MomoNumber,
                Amount = momovm.Amount,
                ContactNumber = momovm.ContactNumber,
                EmailAddress = momovm.EmailAddress,
                ProviderName = momovm.MNO,
                ProviderType = "MNO",
                EntryDate = DateTime.Now,
                RefNo = momovm.RefNo,
                TransactionID = momovm.TransactionID,
                TransactionType = "MP"
            };

            var result = await _service.SaveTransactionAsync(transactionVM);
            transactionLogVM.Descriptions = $"Account {momovm.MomoNumber} submitted payment.(RefNo:{momovm.RefNo}; Type:Bank; Provider:{momovm.MNO}; TransactionID:{momovm.TransactionID}; Amount:{momovm.Amount})";
            transactionLogVM.LogEntryDateTime = DateTime.Now;
            await TransactionLogService.LogTransaction(transactionLogVM);

            if (result == null && !string.IsNullOrWhiteSpace(_service.Error))
                return InternalServerError(new Exception(_service.Error));
            return Ok(result);

        }

        /// <summary>
        /// Bank Transaction endpoint
        /// </summary>
        /// <param name="bankvm"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("_bankpost/bp-500/repayments")]
        public async Task<IHttpActionResult> BankPost(BankTransactionVM bankvm)
        {
            var transactionLogVM = new Transactions_LogVM();

            if (bankvm == null)
                return BadRequest("An empty/null Bank Transaction was submitted.");

            var isValidRefNo = _service.ValidateReferenceNo(bankvm.RefNo);
            if (!isValidRefNo)
            {
                //Log BANK Transaction with Invalid RefNo
                transactionLogVM.Descriptions = $"Account {bankvm.AccountNumber} submitted payment with an INVALID Reference Number.(Type:Bank; Provider:{bankvm.BankName}; TransactionID:{bankvm.TransactionID}; Amount:{bankvm.Amount})";
                transactionLogVM.LogEntryDateTime = DateTime.Now;

                await TransactionLogService.LogTransaction(transactionLogVM);
                return BadRequest("Invalid Reference Number (RefNo).");
            }

            TransactionsVM transactionVM = new TransactionsVM()
            {
                AccountNumber = bankvm.AccountNumber,
                Amount = bankvm.Amount,
                ContactNumber = bankvm.ContactNumber,
                EmailAddress = bankvm.EmailAddress,
                ProviderType = "BANK",
                ProviderName = bankvm.BankName,
                EntryDate = DateTime.Now,
                RefNo = bankvm.RefNo,
                TransactionID = bankvm.TransactionID,
                TransactionType = "BP"
            };

            var result = await _service.SaveTransactionAsync(transactionVM);
            transactionLogVM.Descriptions = $"Account {bankvm.AccountNumber} submitted payment.(RefNo:{bankvm.RefNo}; Type:Bank; Provider:{bankvm.BankName}; TransactionID:{bankvm.TransactionID}; Amount:{bankvm.Amount})";
            transactionLogVM.LogEntryDateTime = DateTime.Now;
            await TransactionLogService.LogTransaction(transactionLogVM);

            if (result == null && !string.IsNullOrWhiteSpace(_service.Error))
                return InternalServerError(new Exception(_service.Error));
            return Ok(result);
        }


    }
}
