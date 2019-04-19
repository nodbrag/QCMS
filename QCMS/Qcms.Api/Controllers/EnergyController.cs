/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：水(软水、纯水)、电、蒸汽
   
   EnergyUnitGroupID:能源单位组；
   EnergyUnitID:能耗单位；                                                    
*│　作    者：CodeGeneratorTool                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-04-17 17:50:13                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Qcms.Api.Controllers                                  
*│　类    名： EnergyController                                    
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
    public class EnergyController: BaseController<EnergyDtos.EnergyDto,EnergyDtos.EnergyFilterDto,Energy>
    {
        public readonly IEnergyService _service;
        public EnergyController(IEnergyService service) :base(service)
        {
            _service = service;
        }
    }
}
