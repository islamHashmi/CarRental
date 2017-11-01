using System.ComponentModel.DataAnnotations;

namespace AjinkyaCarRental.Context
{
    [MetadataType(typeof(CompanyBranchVM))]
    public partial class CompanyBranch { }

    public class CompanyBranchVM
    {
        [Required]
        [Display(Name ="Branch Name")]
        public string branchName { get; set; }
    }
}