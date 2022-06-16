using ClosedXML.Excel;
using System.Reflection;
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Application.Interfaces.Services;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly IUserRepository _repository;

        public ReportService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task GetUsersExcelReport()
        {
            var users = await _repository.GetAllUsers();

            //Creating a excel workbook and inside of it creating a sheet named Users.
            using var workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Users");
            
            //For creating headers of the columns.
            var column = 1;
            foreach (PropertyInfo p in new User().GetType().GetProperties())
            {
                var sheet = worksheet.Cell(1, column);
                sheet.Value = p.Name;
                sheet.Style.Font.FontSize = 12;
                sheet.Style.Font.SetBold();
                sheet.Style.Font.SetItalic();
                sheet.Style.Fill.SetBackgroundColor(XLColor.Yellow);
                sheet.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Style.Alignment.Horizontal= XLAlignmentHorizontalValues.Left;
                
                column++;
            }

            //For entering the values inside the users table.
            var row = 2;
            foreach (var user in users)
            {
                column = 1;
                foreach (PropertyInfo p in user.GetType().GetProperties())
                {
                    var sheet = worksheet.Cell(row, column);
                    sheet.Value = p.GetValue(user)?.ToString();
                    sheet.Style.Font.FontSize = 10;
                    sheet.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    sheet.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                    column++;
                }
                row++;
            }

            //Giving the file a name.
            worksheet.Columns("A", "Z").AdjustToContents();
            var fileSaveDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = string.Format($"Users_{fileSaveDate}.xlsx");
            string path = $@"C:\TPReports\{ fileName}";

            workbook.SaveAs(path);
        }
    }
}
