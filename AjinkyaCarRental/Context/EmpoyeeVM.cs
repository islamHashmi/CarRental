using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AjinkyaCarRental.Context
{
    [MetadataType(typeof(EmpoyeeVM))]
    public partial class Employee
    {
        [NotMapped]
        public SelectList branchList { get; set; }
    }

    public class EmpoyeeVM
    {
        [Required]
        public int branchId { get; set; }

        [Display(Name = "Name"), Required]
        public string employeeName { get; set; }

        [Display(Name ="Residential Address")]
        public string residentiallAddress { get; set; }

        [Display(Name ="Navite Address")]
        public string nativeAddress { get; set; }

        [Display(Name ="Mobile Number")]
        public string mobileNumber { get; set; }

        [Display(Name ="Telephone")]
        public string residentialTelephone { get; set; }

        [Display(Name ="Joining Date")]
        public DateTime joiningDate { get; set; }

        [Display(Name ="Leaving Date")]
        public DateTime? leavingDate { get; set; }

        [Display(Name ="Basic Amount")]
        public decimal? basicAmount { get; set; }

        [Display(Name ="HRA Amount")]
        public decimal? hraAmount { get; set; }

        [Display(Name ="CC Amount")]
        public decimal? ccAmount { get; set; }

        [Display(Name ="Bank")]
        public bool? bank { get; set; }

        [Display(Name ="A/c Number")]
        public string accountNumber { get; set; }

        public int entryBy { get; set; }

        public DateTime entryDate { get; set; }

        public int? updatedBy { get; set; }

        public DateTime? updatedDate { get; set; }
    }
}