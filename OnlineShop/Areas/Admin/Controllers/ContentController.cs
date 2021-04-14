using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
             var dao = new ContentDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetByID(id);

            SetViewBag(content.ID);
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();


                long id = dao.Insert(content);
                if (id > 0)
                {
                    SetAlert("Thêm mới doanh mục thành công!!", "success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {

                    ModelState.AddModelError("", "Thêm doanh mục không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();


                var result = dao.Update(content);
                if (result)
                {
                    SetAlert("Cập nhập người dùng thành công!!", "success");

                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập Người dùng không thành công");
                }
            }
            SetViewBag(content.ID);
            return View();
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}