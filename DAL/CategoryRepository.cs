using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;
using System.Data.Entity;

namespace WebApplication5.DAL
{
    public class CategoryRepository : IRepository<Category>
    {
        ShopContext context;
        DbSet<Category> categories;
        public CategoryRepository(ShopContext context)
        {
            this.context = context;
            categories = context.Categories;
        }
        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }
        public IEnumerable<Category> GetList()
        {
            return context.Categories.ToList();
        }
        public void Update(Category entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Create(Category entity)
        {
            categories.Add(entity);
        }

        public void Delete(int id)
        {
            Category category = context.Categories.Find(id);
            Delete(category);
        }

        public void Delete(Category entity)
        {
            if(context.Entry(entity).State==EntityState.Deleted)
            {
                context.Categories.Attach(entity);

            }
            context.Entry(entity).State = EntityState.Deleted;
        }

     

        public void Save()
        {
            context.SaveChanges();
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CategoryRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        public IEnumerable<Category> GetList(string include)
        {
            return context.Categories.Include(include).ToList();
        }
        #endregion

    }
}