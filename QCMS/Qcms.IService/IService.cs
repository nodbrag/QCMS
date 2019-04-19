using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Qcms.Model;
using Qcms.Core.Entities;
using System.Linq.Expressions;
using Qcms.Core.Dtos;

namespace Qcms.IService
{
    public interface IService<TEntity> where TEntity : AggregateRoot, new()
    {
        TDtoEntity Get<TDtoEntity>(int id);
        Task<TDtoEntity> GetAsync<TDtoEntity>(int id);
        Task<List<TDtoEntity>> GetAllListAsync<TDtoEntity>();
        Task<Tuple<List<TDtoEntity>, int>> GetAllListAsync<TDtoEntity>(string predicate, object[] values, int pageIndex, int pageSize, string orderBy = null);
        Task<Tuple<List<TDtoEntity>, int>> GetAllListAsync<TDtoEntity>(int pageIndex, int pageSize, string orderBy = null);
        Task<Tuple<List<TDtoEntity>, int>> GetAllFilterListAsync<TDtoEntity,TFilter>(FiterConditionBase<TFilter> fiterCondition);
        Task InsertAsync<TDtoEntity>(TDtoEntity entity);
        Task UpdateAsync<TDtoEntity>(TDtoEntity entity);
        Task DeleteAsync(int id);
    }
}
