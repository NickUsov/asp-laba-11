﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;
using System.Data.Entity;

namespace WebApplication5.DAL
{
    public class GoodRepository:IRepository<Good>
    {
        ShopContext context;
        DbSet<Good> goods;
        public GoodRepository(ShopContext context)
        {
            this.context = context;
            goods = context.Goods;
        }
        public Good GetById(int id)
        {
            return context.Goods.Find(id);
        }
        public IEnumerable<Good> GetList()
        {
            return context.Goods.ToList();
        }
        public IEnumerable<Good> GetList(string include)
        {
            return context.Goods.Include(include).ToList();
        }
        public void Update(Good entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Create(Good entity)
        {
            goods.Add(entity);
        }

        public void Delete(int id)
        {
            Good good = context.Goods.Find(id);
            Delete(good);
        }

        public void Delete(Good entity)
        {
            if (context.Entry(entity).State == EntityState.Deleted)
            {
                context.Goods.Attach(entity);

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
        #endregion
    }
}