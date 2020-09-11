using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.VMs
{
    /// <summary>
    /// General Transaction
    /// </summary>
    public abstract class TransactionsBase
    {
        private DateTime _lastUpdated = DateTime.UtcNow;

        [Key]
        public int EntryID { get; set; }
        public string Discriminator { get; set; }

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
        public string MNO { get; set; }
        public string MomoNumber { get; set; }
    }

    public class BankTransactionVM : TransactionsBase
    {
        public string BankName { get; set; }
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
        public decimal RequestAmount { get; set; }
        public string SectorID { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }
        public string NearestLandmark { get; set; }
        public string DistributionMode { get; set; }
        public string MNO { get; set; }
        public string MomoNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string Comments { get; set; }
    }

    public class Transactions_LogVM
    {
        [Key]
        public int LogID { get; set; }      
        public string Discriminator { get; set; }
        public string RefNo { get; set; }
        public string TransactionID { get; set; }
        public string ProviderType { get; set; }
        public string ProviderName { get; set; }
        public string AccountNumber { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal? Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime? EntryDateTime { get; set; }
        public string Comments { get; set; }
    }
}