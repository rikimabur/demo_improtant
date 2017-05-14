using AutoMapper;
using BotDetect.Web.Mvc;
using PhuocCon.Model.Models;
using PhuocCon.Service;
using PhuocCon.Web.Infrastructure.Extensions;
using PhuocCon.Web.Models;
using PhuocCon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PhuocCon.Web.Controllers
{
    public class ContactController : Controller
    {
        IContactDetailService _contactDetailService;
        IFeedbackService _feedbackService;
        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            this._contactDetailService = contactDetailService;
            this._feedbackService = feedbackService;
        }
        // GET: ContactDetail
        public ActionResult Index()
        {
            //var model = _contactDetailService.GetDefaultContact();
            //var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.contactDetail = GetDetail();
            return View(viewModel);
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ContactCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                Feedback newfeedback = new Feedback();
                newfeedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(newfeedback);
                _feedbackService.Save();
                ViewData["SuccessMsg"] = "Send successful!";


                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/contact_template.html"));
                content = content.Replace("{{ Name}}", feedbackViewModel.Name);
                content = content.Replace("{{ Email}}", feedbackViewModel.Email);
                content = content.Replace("{{ Message}}", feedbackViewModel.Message);

                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ website", content);

                feedbackViewModel.Name = "";
                feedbackViewModel.Message = "";
                feedbackViewModel.Email = "";


            }
            feedbackViewModel.contactDetail = GetDetail();

            return View("Index", feedbackViewModel);
        }
        private ContactDetailViewModel GetDetail()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return contactViewModel;
        }
    }
}