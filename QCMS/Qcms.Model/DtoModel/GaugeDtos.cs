/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：仪表
   
   划分到区域WorkArea                                                    
*│　作    者：CodeGeneratorTool                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-04-18 17:39:54                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Qcms.Model.DtoModel                                  
*│　类    名：Gauge                                     
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
    public class GaugeDtos
    {
        public class GaugeDto
        {
            		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 GaugeID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 WorkAreaID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(20)]
		public String GaugeCode {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(50)]
		public String GaugeName {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(1)]
		public Boolean IsAuto {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(1)]
		public Boolean IsVirtual {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(1)]
		public Boolean IsCalculable {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(1)]
		public Boolean IsPrimary {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(500)]
		public String Description {get;set;}


        }
        public class GaugeFilterDto
        {
           
        }
    }
}
