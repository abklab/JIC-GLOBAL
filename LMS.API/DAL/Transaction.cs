//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LMS.API.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int EntryID { get; set; }
        public string RefNo { get; set; }
        public string TransactionID { get; set; }
        public string ProviderType { get; set; }
        public string ProviderName { get; set; }
        public string AccountNumber { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string TransactionType { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
