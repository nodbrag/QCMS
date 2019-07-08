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
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using System.Text;

using System.IO;


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
        
        [HttpGet]
        public async Task<IActionResult> DownloadOrders()
        {
            var newFile = AppDomain.CurrentDomain.BaseDirectory+ "tempExcels" +DateTime.Now.Millisecond + ".xls";
            if (System.IO.File.Exists(newFile))
            {
                System.IO.File.Delete(newFile);
            }
            List<EnergyDtos.EnergyDto> energies=  await _service.GetAllListAsync<EnergyDtos.EnergyDto>();
            using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            {

                IWorkbook workbook = new XSSFWorkbook();

                var sheet = workbook.CreateSheet("orders");
                sheet.AddMergedRegion(new CellRangeAddress(0, 1, 0, 0));
                sheet.AddMergedRegion(new CellRangeAddress(0, 1, 1, 1));
                sheet.AddMergedRegion(new CellRangeAddress(0, 1, 2, 2));
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 3, 4));
                var header = sheet.CreateRow(0);

                ICellStyle style = workbook.CreateCellStyle();//创建样式对象
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                IFont font = workbook.CreateFont(); //创建一个字体样式对象
                font.FontName = "黑体"; //和excel里面的字体对应
                //font.IsItalic = true; //斜体
                //font.FontHeightInPoints = 16;//字体大小
                font.Color = new NPOI.HSSF.Util.HSSFColor.Red().Indexed;
                font.Boldweight = short.MaxValue;//字体加粗
                style.SetFont(font); //将字体样式赋给样式对象

                style.BorderDiagonalLineStyle = BorderStyle.Dashed;
                style.BorderDiagonal = BorderDiagonal.Backward;
                style.BorderDiagonalColor = IndexedColors.LightOrange.Index;

                style.FillForegroundColor = new NPOI.HSSF.Util.HSSFColor.SkyBlue().Indexed;  //具体数字代表的颜色看NPOI颜色对照表
                style.FillPattern = FillPattern.SolidForeground;
                //style.FillBackgroundColor = 13; 


                ICell cell0 = header.CreateCell(0);
                cell0.SetCellValue("日期     产品");
                cell0.CellStyle = style;

                ICell cell1 = header.CreateCell(1);
                cell1.SetCellValue("类型");
                cell1.CellStyle = style;

                ICell cell2 = header.CreateCell(2);
                cell2.SetCellValue("公司");
                cell2.CellStyle = style;

                ICell cell3 = header.CreateCell(3);
                cell3.SetCellValue("订单");
                cell3.CellStyle = style;

               var header2= sheet.CreateRow(1);
                ICell cell13 = header2.CreateCell(3);
                cell13.SetCellValue("编号");
                cell13.CellStyle = style;

                ICell cell14 = header2.CreateCell(4);
                cell14.SetCellValue("时间");
                cell14.CellStyle = style;

                var rowIndex = 2;
                foreach (var item in energies)
                {
                    var datarow = sheet.CreateRow(rowIndex);

                    datarow.CreateCell(0).SetCellValue(item.EnergyID);
                    datarow.CreateCell(1).SetCellValue(item.EnergyName);
                    datarow.CreateCell(2).SetCellValue(item.EnergyUnitGroupID);
                    datarow.CreateCell(3).SetCellValue(item.Description);
                    datarow.CreateCell(4).SetCellValue(item.EnergyUnitID);
                    rowIndex++;
                }
                //设置列宽度
                sheet.SetColumnWidth(0, 16*300);
 

                workbook.Write(fs);
            }
            var memory = new MemoryStream();
            using (var stream = new FileStream(newFile, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            System.IO.File.Delete(newFile);
            return File(memory, "application/vnd.ms-excel", "order.xlsx");
        }
    }
}
