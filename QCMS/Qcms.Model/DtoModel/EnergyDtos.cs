/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：水(软水、纯水)、电、蒸汽
   
   EnergyUnitGroupID:能源单位组；
   EnergyUnitID:能耗单位；                                                    
*│　作    者：CodeGeneratorTool                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-04-18 17:39:54                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Qcms.Model.DtoModel                                  
*│　类    名：Energy                                     
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qcms.Model.DtoModel
{
    public class EnergyDtos
    {
        public class EnergyDto
        {
            		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 EnergyID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 EnergyUnitGroupID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 EnergyUnitID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(50)]
		public String EnergyName {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(500)]
		public String Description {get;set;}


        }
        public class EnergyFilterDto
        {
           
        }
    }
}
