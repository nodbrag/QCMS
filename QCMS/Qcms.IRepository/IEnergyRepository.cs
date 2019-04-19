/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：水(软水、纯水)、电、蒸汽
   
   EnergyUnitGroupID:能源单位组；
   EnergyUnitID:能耗单位；                                                    
*│　作    者：CodeGeneratorTool                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-04-17 17:50:13                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Qcms.IRepository                                   
*│　接口名称： IEnergyRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model.DataModel;
using System.Threading.Tasks;


namespace Qcms.IRepository
{
    public interface IEnergyRepository: IRepository<Energy,Int32>
    {
        
    }
}