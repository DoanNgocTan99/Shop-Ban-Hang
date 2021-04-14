using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductCategoryDao();
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
        public ActionResult Edit(int id)
        {
            var user = new ProductCategoryDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();


                var result = dao.Update(productCategory);
                if (result)
                {
                    SetAlert("Cập nhập người dùng thành công!!", "success");

                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập Người dùng không thành công");
                }

            }
            return View("Index");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductCategory content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();


                long id = dao.Insert(content);
                if (id > 0)
                {
                    SetAlert("Thêm mới doanh mục thành công!!", "success");
                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {

                    ModelState.AddModelError("", "Thêm doanh mục không thành công");
                }
            }
            SetViewBag();
            return View("Index");

        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}