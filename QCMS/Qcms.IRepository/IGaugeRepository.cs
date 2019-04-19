/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：仪表
   
   划分到区域WorkArea                                                    
*│　作    者：CodeGeneratorTool                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-04-17 17:50:14                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Qcms.IRepository                                   
*│　接口名称： IGaugeRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model.DataModel;
using System.Threading.Tasks;


namespace Qcms.IRepository
{
    public interface IGaugeRepository: IRepository<Gauge,Int32>
    {
        
    }
}