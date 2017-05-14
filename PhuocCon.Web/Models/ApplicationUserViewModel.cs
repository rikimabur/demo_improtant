﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class ApplicationUserViewModel
    {
        public string Id { set; get; }
        public string FullName { set; get; }
        public string Adress { set; get; }
        public DateTime BirthDate { set; get; }
        public string Bio { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string PhoneNumber { set; get; }
        public IEnumerable<ApplicationGroupViewModel> Groups { set; get; }

    }
}