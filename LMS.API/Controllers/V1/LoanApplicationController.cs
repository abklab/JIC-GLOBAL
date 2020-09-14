using LMS.API.Services;
using LMS.API.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LMS.API.Controllers.V1
{
    [RoutePrefix("api/v2000/LoanApplication")]

    public class LoanApplicationController : ApiController
    {
        LoanApplicationService _service;
        public LoanApplicationController()
        {
            _service = new LoanApplicationService();
        }


        // GET: api/LoanApplication/all
        [Route("all")]
        public async Task<IHttpActionResult> GetLoanApplications()
        {
            var result = await _service.GetLoanApplications();
            return Ok(result);
        }

        // GET: api/LoanApplication/5
        public async Task<IHttpActionResult> GetLoanApplication(int applicationID)
        {
            var result= await _service.GetLoanApplicationByID(applicationID);
            return Ok(result);
        }

        // POST: api/LoanApplication
        [HttpPost]
        [Route("_apply")]
        public async Task<IHttpActionResult> LoanApplication(LoanApplicationVM loanApplicationVM)
        {
            var transactionLogVM = new Transactions_LogVM();
            if (loanApplicationVM == null)
                return BadRequest("Invalid loan application(null/empty) submitted ");

            var result = await _service.SubitLoanApplication(loanApplicationVM);

            transactionLogVM.Descriptions = $"Loan Application - (Applicant Name: {loanApplicationVM.FullName}; Loan Amount:{loanApplicationVM.RequestAmount}; Section ID: {loanApplicationVM.SectorID}; Distribution Mode:{loanApplicationVM.DistributionMode})";
            transactionLogVM.LogEntryDateTime = DateTime.Now;
            await TransactionLogService.LogTransaction(transactionLogVM);

            if (result == null && !string.IsNullOrWhiteSpace(_service.ErrorMessage))
                return InternalServerError(new Exception(_service.ErrorMessage));
            return Ok(result);
        }

        //// PUT: api/LoanApplication/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/LoanApplication/5
        //public void Delete(int id)
        //{
        //}
    }
}
