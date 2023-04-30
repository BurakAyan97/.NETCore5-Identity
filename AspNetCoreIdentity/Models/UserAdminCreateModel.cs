using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models
{
    public class UserAdminCreateModel
    {
        [Required(ErrorMessage ="Kullanıcı adı gereklidir")]
        public string Username { get; set; }
        
        [Required(ErrorMessage ="Email adı gereklidir")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Cinsiyetgereklidir")]
        public string Gender { get; set; }
    }
}
