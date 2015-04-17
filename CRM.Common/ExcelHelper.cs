using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NPOI.HSSF.UserModel;
namespace CRM.Common
{
    public class ExcelHelper
    {
        public static HSSFWorkbook generateHSSF<T>(string sheetName, List<T> list, string[] columnNames, string[] columnCodes)
        {
            HSSFWorkbook hssfWork = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)hssfWork.CreateSheet(sheetName);
            //创建表头
            HSSFRow firstRow = (HSSFRow)sheet.CreateRow(0);
            HSSFCell[] firstCell = new HSSFCell[columnCodes.Length];
            for (int i = 0; i < columnCodes.Length; i++)
            {
                firstCell[i] = (HSSFCell)firstRow.CreateCell(i);
                HSSFRichTextString text = new HSSFRichTextString(columnNames[i]);
                HSSFFont font = (HSSFFont)hssfWork.CreateFont();
                font.Boldweight = 12;
                text.ApplyFont(font);
                firstCell[i].SetCellValue(text);
            }

            //插入数据
            for (int i = 0; i < list.Count; i++)
            {           
                Object cellobj = null;
                Object obj = list[i];
                HSSFRow row = (HSSFRow)sheet.CreateRow(i + 1);
                for (int colIndex = 0; colIndex < columnCodes.Length; colIndex++)
                {
                    string colCode = columnCodes[colIndex];
                    PropertyInfo property = obj.GetType().GetProperty(colCode);
                    cellobj = property.GetValue(obj, null);
                    string cellValue = "";
                    if (cellobj != null)
                    {
                        cellValue = cellobj.ToString();
                    }
                    else
                    {
                        cellValue = "";
                    }
                    row.CreateCell(colIndex).SetCellValue(cellValue);// 插入单元格
                }
            }
            return hssfWork;
        }
    }
}
