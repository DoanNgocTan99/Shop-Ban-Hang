using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                

                long id = dao.Insert(category);
                if (id > 0)
                {
                    SetAlert("Thêm mới doanh mục thành công!!", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {

                    ModelState.AddModelError("", "Thêm doanh mục không thành công");
                }

            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new CategoryDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();


                var result = dao.Update(category);
                if (result)
                {
                    SetAlert("Cập nhập người dùng thành công!!", "success");

                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập Người dùng không thành công");
                }

            }
            return View("Index");
        }
        public ActionResult Delete(int Id)
        {
            new CategoryDao().Delete(Id);

            return RedirectToAction("Index");
        }
    }
}