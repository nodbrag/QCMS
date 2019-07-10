/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：水(软水、纯水)、电、蒸汽
   
   EnergyUnitGroupID:能源单位组；
   EnergyUnitID:能耗单位；接口实现                                                    
*│　作    者：CodeGeneratorTool                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-04-17 17:50:13                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Qcms.Repository                                  
*│　类    名： EnergyRepository                                      
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
    public class EnergyRepository: BaseRepository<Energy>,IEnergyRepository
    {
        //public EnergyRepository(Uow.EFUnitOfWork unitOfWork):base(unitOfWork)
        //{


        //}
        public EnergyRepository(ModelBaseContext context) : base(context)
        {


        }
    }
}