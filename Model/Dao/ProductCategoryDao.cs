using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        OnlineShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
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
        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public ProductCategory ViewDetail(int Id)
        {
            return db.ProductCategories.Find(Id);
        }
        public bool Update(ProductCategory entity)
        {
            try
            {
                var user = db.ProductCategories.Find(entity.ID);

                user.Name = entity.Name;
                user.MetaTitle = entity.MetaTitle;
                user.DisplayOrder = entity.DisplayOrder;
                user.ModifiedDate = DateTime.Now;
                user.CreatrBy = entity.CreatrBy;
                user.Status = entity.Status;
                user.ShowOnHome = entity.ShowOnHome;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
