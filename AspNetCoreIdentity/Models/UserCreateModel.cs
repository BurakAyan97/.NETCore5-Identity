﻿using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
        public string UserName { get; set; }
        
        [EmailAddress(ErrorMessage ="Lütfen bir email formatı giriniz")]
        [Required(ErrorMessage ="Email adresi gereklidir")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Parola alanı boş geçilemez.")]
        public string Password { get; set; }
        
        [Compare("Password",ErrorMessage ="Parolalar eşleşmiyor")]
        public string ConfirmedPassword { get; set; }
        
        [Required(ErrorMessage ="Cinsiyet boş geçilemez")]
        public string Gender { get; set; }
    }
}
