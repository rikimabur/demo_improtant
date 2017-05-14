using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Bạn cần nhập tên đăng nhập.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tên mật khẩu.")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}