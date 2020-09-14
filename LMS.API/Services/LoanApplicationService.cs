using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LMS.API.VMs;
using LMS.API.DAL;
using AutoMapper;
using System.Data.Entity;

namespace LMS.API.Services
{
    public class LoanApplicationService
    {
        private LMSdbContext _db;

        public LoanApplicationService()
        {
            _db = new LMSdbContext();
        }

        public string ErrorMessage { get; private set; } = "";

        internal async Task<LoanApplicationVM> SubitLoanApplication(LoanApplicationVM loanApplicationVM)
        {
            try
            {
                var application = _db.LoanApplications.FirstOrDefault(a => a.ApplicationID == loanApplicationVM.ApplicationID);
                if (application == null)
                {
                    application = Mapper.Map<LoanApplication>(loanApplicationVM);

                    _db.LoanApplications.Add(application);
                }
                else
                    application = Mapper.Map<LoanApplication>(loanApplicationVM);

                int i = await _db.SaveChangesAsync();
                if (i > 0)
                {
                    loanApplicationVM.ApplicationID = application.ApplicationID;
                    return loanApplicationVM;
                }
                else
                    throw new Exception("Sorry something went wrong.Unable to submit Loan application.");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return null;
        }

        internal async Task<LoanApplicationVM> GetLoanApplicationByID(int applicationID)
        {
            var loan = await _db.LoanApplications.FirstOrDefaultAsync(a=>a.ApplicationID==applicationID);
            var loanvm = Mapper.Map<LoanApplicationVM>(loan);
            return loanvm;
        }

        public async Task<IEnumerable<LoanApplicationVM>> GetLoanApplications()
        {
            var list = await _db.LoanApplications.ToListAsync();
            var listvm = Mapper.Map<IEnumerable<LoanApplicationVM>>(list);
            return listvm;
        }
    }
}