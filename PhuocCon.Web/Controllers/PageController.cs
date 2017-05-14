using AutoMapper;
using PhuocCon.Model.Models;
using PhuocCon.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhuocCon.Web.Models;

namespace PhuocCon.Web.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        PageService _pageService;
        public PageController(PageService pageService)
        {
            this._pageService = pageService;
        }
        public ActionResult Index(string alias)
        {
            var page = _pageService.GetByAlias(alias);
            var model = Mapper.Map<Page, PageViewModel>(page);
            return View(model);
        }
    }
}