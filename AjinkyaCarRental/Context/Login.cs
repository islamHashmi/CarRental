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
    
    public partial class Login
    {
        public int userId { get; set; }
        public int employeeId { get; set; }
        public string loginId { get; set; }
        public string loginKey { get; set; }
        public Nullable<System.DateTime> lastLoginDate { get; set; }
        public int entryBy { get; set; }
        public System.DateTime entryDate { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
    
        public virtual Login Login1 { get; set; }
        public virtual Login Login2 { get; set; }
    }
}
