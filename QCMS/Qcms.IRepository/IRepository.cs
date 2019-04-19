using System;
using System.Collections.Generic;
using System.Text;
using JIME.Model;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Qcms.Core.Entities;

namespace Qcms.IRepository
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : IEntity, new()
    {

        #region 获得实体的列表

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        List<TEntity> GetAllList(bool IsNoTracking = true);
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate, bool IsNoTracking = true);
        Task<List<TEntity>> GetAllListAsync(bool IsNoTracking = true);
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate,bool IsNoTracking = true);

        #endregion

        #region 获取实体的列表，支持分页
        Tuple<List<TEntity>, int> GetAllList(int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true);
        Task<Tuple<List<TEntity>, int>> GetAllListAsync(int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true);
        Tuple<List<TEntity>,int> GetAllList(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true);
        Task<Tuple<List<TEntity>,int>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate,  int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true);
        Task<Tuple<List<TEntity>, int>> GetAllListAsync(string predicate, object[] values, int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true);
        #endregion

        #region 获得单个实体
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);
        #endregion

        #region 插入
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        void BatchInsert(List<TEntity> entity, List<TEntity> oldentity);
        Task BatchInsertAsync(List<TEntity> entity, List<TEntity> oldentity);
        #endregion

        #region 更新
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void BatchUpdate(List<TEntity> entity);
        Task BatchUpdateAsync(List<TEntity> entity);
        #endregion

        #region 删除
        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region 其他

        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        long LongCount();
        Task<long> LongCountAsync();
        long LongCount(Expression<Func<TEntity, bool>> predicate);
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

    }
}
