using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Bạn cần nhập tên.")]
        public string FullName { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập tên đăng nhập.")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu.")]
        [MinLength(6, ErrorMessage ="Mật khẩu có ít nhất 6 kí tự")]
        public string PassWord { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập email.")]
        [EmailAddress(ErrorMessage = "Email không đúng.")]
        public string Email { set; get; }
        public string Address { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập số điện thoại.")]
        public string PhoneNumber { set; get; }

    }
}