/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：仪表
   
   划分到区域WorkArea接口实现                                                    
*│　作    者：CodeGeneratorTool                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-04-17 17:50:14                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Qcms.Repository                                  
*│　类    名： GaugeRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model.DataModel;
using Qcms.IRepository;
using System.Threading.Tasks;
using System.Linq;

namespace Qcms.Repository
{
    public class GaugeRepository: BaseRepository<Gauge>,IGaugeRepository
    {
        public GaugeRepository(ModelBaseContext context):base(context)
        {

           
        }
    }
}