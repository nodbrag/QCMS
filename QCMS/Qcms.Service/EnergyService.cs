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
*│　命名空间： Qcms.Service                                  
*│　类    名： EnergyService                                    
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
    public class EnergyService:BaseService<Energy>,IEnergyService
    {
        private readonly IEnergyRepository _repository;

        public EnergyService(IEnergyRepository repository) :base(repository)
        {
            _repository = repository;
            
        }
        
    }
}
