using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
         OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public long Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Category ViewDetail(int Id)
        {
            return db.Categories.Find(Id);
        }
        public bool Update(Category entity)
        {
            try
            {
                var user = db.Categories.Find(entity.ID);

                user.Name = entity.Name;
                user.MetaTitle = entity.MetaTitle;
                user.DisplayOrder = entity.DisplayOrder;
                user.Status = entity.Status;
                user.ShowOnHome = entity.ShowOnHome;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    model = model.Where(x => x.Phone.Contains(searchString)|| x.Address.Contains(searchString));
            //}
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);

        }
        public bool Delete(int Id)
        {
            try
            {
                var user = db.Categories.Find(Id);
                db.Categories.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ProductCategory ViewDetail (long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
