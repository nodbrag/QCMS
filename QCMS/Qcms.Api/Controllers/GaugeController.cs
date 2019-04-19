/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：仪表
   
   划分到区域WorkArea                                                    
*│　作    者：CodeGeneratorTool                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-04-17 17:50:14                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Qcms.Api.Controllers                                  
*│　类    名： GaugeController                                    
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcms.Model.DataModel;
using Qcms.Model.DtoModel;
using Qcms.IService;
using Qcms.Core.Dtos;


namespace Qcms.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class GaugeController: BaseController<GaugeDtos.GaugeDto,GaugeDtos.GaugeFilterDto,Gauge>
    {
        public readonly IGaugeService _service;
        public GaugeController(IGaugeService service) :base(service)
        {
            _service = service;
        }
    }
}
