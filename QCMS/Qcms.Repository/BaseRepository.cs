using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qcms.Core.Extensions;
using Qcms.Core.Entities;
using Qcms.IRepository;
using Qcms.Model.DataModel;

namespace Qcms.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity,Int32> where TEntity : AggregateRoot, new()
    {
        //protected readonly ModelBaseContext _context;

        //public virtual DbSet<TEntity> Table { get { return _context.Set<TEntity>(); } }

        //public BaseRepository(ModelBaseContext context)
        //{

        //    _context = context;
        //}

        protected ModelBaseContext _context { get { return (ModelBaseContext)_unitOfWork.context; } }

        public virtual DbSet<TEntity> Table { get { return _context.Set<TEntity>(); } }

        public Uow.IEFUnitOfWork _unitOfWork { get; set; }

        public BaseRepository(Uow.EFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region 获得实体的列表
        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return Table.Where(predicate);
            }
            return Table;
        }
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors == null)
            {
                return GetAll();
            }
            var linq = GetAll();

            foreach (var item in propertySelectors)
            {
                linq = linq.Include(item);
            }
            return linq;
        }

        public List<TEntity> GetAllList(bool IsNoTracking=true)
        {
            if(IsNoTracking)
            return GetAll().AsNoTracking().ToList();
            else
            return GetAll().ToList();
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate,bool IsNoTracking= true)
        {
            if(IsNoTracking)
            return GetAll().Where(predicate).AsNoTracking().ToList();
            else
            return GetAll().Where(predicate).ToList();
        }

        public async Task<List<TEntity>> GetAllListAsync(bool IsNoTracking = true)
        {
            if (IsNoTracking)
                return await GetAll().AsNoTracking().ToListAsync();
            else
                return await GetAll().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate, bool IsNoTracking = true)
        {
            if(IsNoTracking)
            return await GetAll().Where(predicate).AsNoTracking().ToListAsync();
            else
            return await GetAll().Where(predicate).ToListAsync();
        }
        #region 获取实体的列表，支持分页
        public Tuple<List<TEntity>, int> GetAllList(int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true)
        {
            var list= GetAll();
            if (IsNoTracking)
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(list.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList(), list.Count());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList(), list.Count());
                }
            }
            else
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
                } 
            }
        }
        public async Task<Tuple<List<TEntity>, int>> GetAllListAsync(int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true)
        {
            var list = GetAll();
            if (IsNoTracking)
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(await list.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(), await list.CountAsync());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(await list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(), await list.CountAsync());

                }

            }
            else
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(await list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(), await list.CountAsync());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(await list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(), await list.CountAsync());
                }

            }

        }
        public Tuple<List<TEntity>, int> GetAllList(Expression<Func<TEntity, bool>> predicate,  int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true)
        {
            var list = GetAll();
            if (predicate != null)
                list = GetAll().Where(predicate);
            if (IsNoTracking)
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(list.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList(), list.Count());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList(), list.Count());

                }
            }
            else
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
                }

            }
        }
        public async Task<Tuple<List<TEntity>, int>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true)
        {
            var list = GetAll();
            if (predicate != null)
                list = GetAll().Where(predicate);
            if (IsNoTracking)
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(await list.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(), await list.CountAsync());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(await list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(), await list.CountAsync());
                }
            }
            else
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(await list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(), await list.CountAsync());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(await list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(), await list.CountAsync());
                }

            }
        }
        public async Task<Tuple<List<TEntity>, int>> GetAllListAsync(string predicate, object[] values, int pageIndex, int pageSize, string orderBy = null, bool IsNoTracking = true)
        {
            var list = GetAll();
            if (predicate != null)
                list = GetAll().Where(predicate, values);
            if (IsNoTracking)
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(await list.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(), await list.CountAsync());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(await list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(), await list.CountAsync());
                }
            }
            else
            {
                if (orderBy.IsNullOrEmpty())
                {
                    return new Tuple<List<TEntity>, int>(await list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(), await list.CountAsync());
                }
                else
                {
                    return new Tuple<List<TEntity>, int>(await list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(), await list.CountAsync());
                }

            }
        }
        #endregion

        #endregion

        #region 获得单个实体
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().SingleAsync(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().FirstOrDefaultAsync(predicate);
        }

        public TEntity Get(int id)
        {
            return Table.Find(id);
        }
        public async Task<TEntity> GetAsync(int id)
        {
            return await Table.FindAsync(id);
        }
        #endregion

        #region 插入
        public TEntity Insert(TEntity entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task BatchInsertAsync(List<TEntity> entitys, List<TEntity> oldentity)
        {
            List<TEntity> tList = new List<TEntity>();
            foreach (TEntity entity in entitys)
            {
                tList.Add(entity);
            }
            if (oldentity.Count > 0)
            {
                Table.RemoveRange(oldentity);
            }
            await Table.AddRangeAsync(tList);
            await _context.SaveChangesAsync();
        }
        public void BatchInsert(List<TEntity> entitys, List<TEntity> oldentity)
        {
            List<TEntity> tList = new List<TEntity>();
            foreach (TEntity entity in entitys)
            {
                tList.Add(entity);
            }
            if (oldentity.Count > 0)
            {
                Table.RemoveRange(oldentity);
            }
            Table.AddRange(tList);
            _context.SaveChanges();
        }
        #endregion

        #region 更新
        public TEntity Update(TEntity entity)
        {
            Table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public void BatchUpdate(List<TEntity> entitys)
        {
            List<TEntity> tList = new List<TEntity>();
            foreach (TEntity entity in entitys)
            {
                tList.Add(entity);
            }
            Table.UpdateRange(tList);
            _context.SaveChanges();
        }

        public async Task BatchUpdateAsync(List<TEntity> entitys)
        {
            List<TEntity> tList = new List<TEntity>();
            foreach (TEntity entity in entitys)
            {
                tList.Add(entity);
            }
            Table.UpdateRange(tList);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region 删除
        public void Delete(int id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);
            Table.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Table.RemoveRange(GetAll().Where(predicate).ToList());
           _context.SaveChanges();
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
           
            Table.RemoveRange(GetAll().Where(predicate).ToList());
            await _context.SaveChangesAsync();
        }

        #endregion

        #region 其他
        public int Count()
        {
            return GetAll().Count();
        }

        public async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).CountAsync();
        }

        public long LongCount()
        {
            return GetAll().LongCount();
        }

        public async Task<long> LongCountAsync()
        {
            return await GetAll().LongCountAsync();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).LongCount();
        }

        public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).LongCountAsync();
        }

        #endregion

 
        
    }
}
