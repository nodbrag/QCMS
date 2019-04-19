/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：仪表
   
   划分到区域WorkArea                                                    
*│　作    者：CodeGeneratorTool                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-04-17 17:50:14                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Qcms.Service                                  
*│　类    名： GaugeService                                    
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model;
using Qcms.IRepository;
using Qcms.IService;
using System.Threading.Tasks;
using Qcms.Model.DataModel;

namespace Qcms.Service
{
    public class GaugeService:BaseService<Gauge>,IGaugeService
    {
        private readonly IGaugeRepository _repository;

        public GaugeService(IGaugeRepository repository) :base(repository)
        {
            _repository = repository;
        }

    }
}
