// Services/ExcelService.cs
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using ExcelDataApi.Models;

namespace ExcelDataApi.Services
{
    public class ExcelService
    {
        private readonly string _filePath;

        public ExcelService(string filePath)
        {
            _filePath = filePath;
        }

        public List<ExcelData> GetData(string filter)
        {
            var data = new List<ExcelData>();

            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var worksheet = package.Workbook.Worksheets.First();
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // Assuming the first row is the header
                {
                    var column1 = worksheet.Cells[row, 1].Text;
                    var column2 = worksheet.Cells[row, 2].Text;

                    // Simple filter logic
                    if (column1.Contains(filter, StringComparison.OrdinalIgnoreCase))
                    {
                        data.Add(new ExcelData
                        {
                            Column1 = column1,
                            Column2 = column2
                        });
                    }
                }
            }

            return data;
        }
    }
}
