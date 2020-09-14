using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.API.VMs
{
    /// <summary>
    /// General Transaction
    /// </summary>
    public abstract class TransactionsBase
    {
        private DateTime _lastUpdated = DateTime.UtcNow;

        [Key]
        public int EntryID { get; set; }

        [Required(ErrorMessage = "Reference Number is required.")]
        public string RefNo { get; set; }

        [Required(ErrorMessage = "TransactionID is required.")]
        public string TransactionID { get; set; }

        [Required(ErrorMessage = "Contact Phone number is required.")]
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; } = "";

        [Required(ErrorMessage = "Transaction Amount is required.")]
        public decimal? Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? LastUpdated
        {
            get
            {
                return _lastUpdated;
            }
            private set
            {
                value = _lastUpdated;
            }
        }
    }

    public class MomoTransactionVM : TransactionsBase
    {
        public string MNO { get; set; } = "MNO";
        public string MomoNumber { get; set; }
    }

    public class BankTransactionVM : TransactionsBase
    {
        public string BankName { get; set; } = "BANK";
        public string AccountNumber { get; set; }
    }

    public class TransactionsVM : TransactionsBase
    {
        public string ProviderType { get; set; }
        public string ProviderName { get; set; }
        public string AccountNumber { get; set; }
    }

    /// <summary>
    /// Loan Application viewMdodel
    /// </summary>
    public class LoanApplicationVM
    {
        public int ApplicationID { get; set; }
        public string FullName { get; set; }
        public decimal RequestAmount { get; set; } = 0;
        public string SectorID { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }
        public string NearestLandmark { get; set; }
        public string DistributionMode { get; set; }
        public string MNO { get; set; } = "MNO";
        public string MomoNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; } = "Bank";
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string Comments { get; set; }
    }

    public partial class Loan_Outstanding_3VM
    {
        decimal _balance = 0m;
        public int EntryID { get; set; }
        public string Account_Number { get; set; }
        public string Account_Name { get; set; }
        public string Balance {
            get {
                return String.Format("{0:C}", _balance);
            }

            set {
                var _ = decimal.TryParse(value,out _balance);
              
            }
        }
    }

    public class Transactions_LogVM
    {
        public int LogID { get; set; }
        public string Descriptions { get; set; }
        public Nullable<System.DateTime> LogEntryDateTime { get; set; }
    }
}