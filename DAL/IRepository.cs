using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.DAL
{
    public interface IRepository<TEntity>:IDisposable where TEntity: class
    {
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(string include);
        TEntity GetById(int id);
        void Delete(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Create(TEntity entity);
        void Save();
    }
}
