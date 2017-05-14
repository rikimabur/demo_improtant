using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class FeedbackViewModel
    {
       
        public int ID { set; get; }
        [MaxLength(250,ErrorMessage ="Tên không được quá 250 ký tự")]
        [Required(ErrorMessage ="Tên không được bỏ trống")]
        public string Name { set; get; }
        [MaxLength(250, ErrorMessage = "Email không được quá 250 ký tự")]
        public string Email { set; get; }
        [MaxLength(500, ErrorMessage = "Message không được quá 500 ký tự")]
        public string Message { set; get; }
        public DateTime CreatedDate { set; get; }
        [Required(ErrorMessage = "Xin vui lòng chọn trạng thái")]
        public bool Status { set; get; }
        public ContactDetailViewModel contactDetail { set; get; }

    }
}