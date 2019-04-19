using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Qcms.IRepository;
using Qcms.Model;
using Qcms.Core.Entities;
using Qcms.IService;
using Qcms.Core.Extensions;
using System.Linq.Expressions;
using Qcms.Core.Dtos;
using System.Reflection;
using System.Linq;

namespace Qcms.Service
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : AggregateRoot, new()
    {
        public IRepository<TEntity,Int32> _baseRepository;

        public BaseService(IRepository<TEntity,Int32> baseRepository)
        {
            this._baseRepository = baseRepository;
        }
        public TDtoEntity Get<TDtoEntity>(int id)
        {
           return _baseRepository.Get(id).MapTo<TDtoEntity>();
        }
        public async Task<TDtoEntity> GetAsync<TDtoEntity>(int id)
        {
            TEntity entity= await _baseRepository.GetAsync(id);
            return entity.MapTo<TDtoEntity>();
        }
        public async Task<List<TDtoEntity>> GetAllListAsync<TDtoEntity>()
        {
            List<TEntity> entities= await _baseRepository.GetAllListAsync();
            return entities.MapTo<List<TDtoEntity>>();
        }
        public async Task<Tuple<List<TDtoEntity>, int>> GetAllListAsync<TDtoEntity>(string predicate, object[] values, int pageIndex, int pageSize, string orderBy = null)
        {
            Tuple<List<TEntity>, int> list= await  _baseRepository.GetAllListAsync(predicate, values, pageIndex, pageSize, orderBy);
            return new Tuple<List<TDtoEntity>, int>(list.Item1.MapTo<List<TDtoEntity>>(),list.Item2);
        }
        public async Task<Tuple<List<TDtoEntity>, int>> GetAllListAsync<TDtoEntity>( int pageIndex, int pageSize, string orderBy = null)
        {
            Tuple<List<TEntity>, int> list = await _baseRepository.GetAllListAsync(pageIndex, pageSize, orderBy);
            return new Tuple<List<TDtoEntity>, int>(list.Item1.MapTo<List<TDtoEntity>>(), list.Item2);
        }
        public async Task InsertAsync<TDtoEntity>(TDtoEntity entity)
        {
            TEntity e = entity.MapTo<TEntity>();
            await _baseRepository.InsertAsync(e);
        }
        public async Task UpdateAsync<TDtoEntity>(TDtoEntity entity)
        {
            TEntity e = entity.MapTo<TEntity>();
            await _baseRepository.UpdateAsync(e);
        }
        public async Task DeleteAsync(int id)
        {
            await _baseRepository.DeleteAsync(id);
        }
        public async  Task<Tuple<List<TDtoEntity>, int>> GetAllFilterListAsync<TDtoEntity, TFilter>(FiterConditionBase<TFilter> fiterCondition)
        {

            Tuple<List<TDtoEntity>, int> list = null;
            if (fiterCondition.Filter == null || fiterCondition.Filter.GetType().GetProperties().Length <= 0)
            {
                list = await GetAllListAsync<TDtoEntity>(fiterCondition.SkipCount, fiterCondition.MaxResultCount, fiterCondition.Sorting);
            }
            else
            {
                TFilter filter = fiterCondition.Filter;
                Type t = filter.GetType();//获得该类的Type
                Dictionary<string, string> filterDic = new Dictionary<string, string>();
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    string value = pi.GetValue(filter, null).ConvertToString();//用pi.GetValue获得值
                    string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                    if (value.IndexOf('^') > 0 && value.Split('^').Count() == 2)
                    {
                        filterDic.Add(name + "^lower", value.Split('^')[0]);
                        filterDic.Add(name + "^upper", value.Split('^')[1]);
                    }
                    else
                    {

                        filterDic.Add(name, value);
                    }

                }
                Tuple<string, object[]> tuplewhere = Qcms.Core.Utility.FilterCondtionHelper.GetExpression<TDtoEntity>(filterDic);
                list = await GetAllListAsync<TDtoEntity>(tuplewhere.Item1, tuplewhere.Item2, fiterCondition.SkipCount, fiterCondition.MaxResultCount, fiterCondition.Sorting);
            }
            return list;

        }
    }
}
