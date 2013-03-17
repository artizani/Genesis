
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using SqlServer;



namespace Loan.Models
{
    public partial class AssetModel
    {
        private AssetModel()
        {
            ConfirmPassword = new Asset().AssetId;
        }
        
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        
    }

    
    
}