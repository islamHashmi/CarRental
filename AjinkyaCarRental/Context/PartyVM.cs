using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AjinkyaCarRental.Context
{
    [MetadataType(typeof(PartyVM))]
    public partial class Party
    {
        [NotMapped]
        public SelectList companyList { get; set; }

        [NotMapped]
        public SelectList branchList { get; set; }

        [NotMapped]
        public SelectList statusList { get; set; }

        [Display(Name = "Main Group")]
        public string primaryGroup { get; set; }
    }

    public class PartyVM
    {
        [Required]
        [Display(Name = "Company")]
        public Nullable<int> companyId { get; set; }
        
        [Required]
        [Display(Name = "Branch")]
        public int? branchId { get; set; }
        
        [Required]
        [Display(Name ="Satus")]
        public string status { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Bill Name")]
        public string billName { get; set; }

        [Required]
        [Display(Name = "ID Name")]
        public string idName { get; set; }

        [Display(Name = "Address Line 1")]
        public string address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string address2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string address3 { get; set; }

        [Display(Name = "Address Line 4")]
        public string address4 { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Pincode")]
        public string pincode { get; set; }

        [Display(Name = "Phone No.")]
        public string contact1 { get; set; }

        [Display(Name = "Phone No.")]
        public string contact2 { get; set; }

        [Display(Name = "Fax Number")]
        public string faxNumber { get; set; }

        [Display(Name = "Email Address")]
        public string emailId { get; set; }

        [Display(Name = "DIscount Allowed")]
        public bool? discountAllowed { get; set; }

        [Display(Name = "Duty Slip Format")]
        public string dutySlipFormat { get; set; }

        [Display(Name = "Vendor Code")]
        public string vendorCode { get; set; }

        [Display(Name = "Cost Center")]
        public string costCenter { get; set; }

        [Display(Name = "TDs %")]
        public decimal? tdsPercent { get; set; }

        [Display(Name = "Commission %")]
        public decimal? commissionPercent { get; set; }

        [Display(Name = "GST Number")]
        public string gstNumber { get; set; }

    }
}