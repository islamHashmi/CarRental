//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AjinkyaCarRental.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int employeeId { get; set; }
        public int branchId { get; set; }
        public string employeeName { get; set; }
        public string residentiallAddress { get; set; }
        public string nativeAddress { get; set; }
        public string mobileNumber { get; set; }
        public string residentialTelephone { get; set; }
        public System.DateTime joiningDate { get; set; }
        public Nullable<System.DateTime> leavingDate { get; set; }
        public Nullable<decimal> basicAmount { get; set; }
        public Nullable<decimal> hraAmount { get; set; }
        public Nullable<decimal> ccAmount { get; set; }
        public Nullable<bool> bank { get; set; }
        public string accountNumber { get; set; }
        public int entryBy { get; set; }
        public System.DateTime entryDate { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public bool active { get; set; }
    
        public virtual CompanyBranch CompanyBranch { get; set; }
    }
}
