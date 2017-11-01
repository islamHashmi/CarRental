using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjinkyaCarRental.Context
{
    [MetadataType(typeof(CompanyVM))]
    public partial class Company { }

    public class CompanyVM
    {
        [Required]
        [Display(Name = "Company Name")]
        public string companyName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [Display(Name = "PAN Number")]
        public string panNumber { get; set; }

        [Required]
        [Display(Name = "Telephone 1")]
        public string telephone1 { get; set; }

        [Display(Name = "Telephone 2")]
        public string telephone2 { get; set; }

        [Display(Name = "Service Tax No.")]
        public string serviceTaxNumber { get; set; }
        
    }
}