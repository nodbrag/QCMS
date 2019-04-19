using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qcms.Core.Dtos;
using Qcms.IService;
using Qcms.Core.Entities;
using Qcms.Core.Extensions;
using System.Reflection;


namespace Qcms.Api.Controllers
{
   
    public class BaseController<TDtoEntity,TFilter, TEntity> :  ControllerBase where TEntity : AggregateRoot, new()
    {
        private readonly IService<TEntity> _ppService;
         
        public BaseController(IService<TEntity> appService)
        {
            _ppService = appService;
         
        }
        /// <summary>
        /// 根据id获取当前记录信息
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IExecResult<TDtoEntity>> Get(int id)
        {
           
            var value = await _ppService.GetAsync<TDtoEntity>(id);
            return new OkOpResult<TDtoEntity>(value);
        }
        /// <summary>
        /// 获取当前记录列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IExecPageResult<TDtoEntity>> GetAll()
        {
            var values = await _ppService.GetAllListAsync<TDtoEntity>();
            return new OkOpPageResult<TDtoEntity>(values);
        }
        /// <summary>
        /// 获取过滤条件获取用户记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
       
        public async Task<IExecPageResult<TDtoEntity>> GetAllFliter([FromBody]Qcms.Core.Dtos.FiterConditionBase<TFilter> fiterCondition)
        {
            if (fiterCondition == null)
                return await  GetAll();
            Tuple<List<TDtoEntity>, int> list =  await _ppService.GetAllFilterListAsync<TDtoEntity, TFilter>(fiterCondition);
            return new OkOpPageResult<TDtoEntity>(list.Item1, list.Item2);
        }
        
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IExecResult> Create([FromBody]TDtoEntity entity)
        {
            try
            {
                await _ppService.InsertAsync(entity);
                return new OkOpResult();
            }
            catch (Exception)
            {
                return new BadOpResult(OpResultStatus.InsertError);
            }
            
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IExecResult> Update([FromBody]TDtoEntity entity)
        {
            try
            {
                await _ppService.UpdateAsync(entity);
                return new OkOpResult();
            }
            catch (Exception)
            {
                return new BadOpResult(OpResultStatus.UpdateError);
            }

        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IExecResult> Delete(int id)
        {
            try
            {
                await _ppService.DeleteAsync(id);
                return new OkOpResult();
            }
            catch (Exception)
            {
                return new BadOpResult(OpResultStatus.DeleteError);
            }

        }
    }
}
