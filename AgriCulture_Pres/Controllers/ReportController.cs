using AgriCulture_Pres.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Security.AccessControl;

namespace AgriCulture_Pres.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticReports()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var library = excelPackage.Workbook.Worksheets.Add("File1");

            library.Cells[1, 1].Value = "Product Name";
            library.Cells[1, 2].Value = "Product Category";
            library.Cells[1, 3].Value = "Product Quantity";

            library.Cells[2, 1].Value = "Lentil";
            library.Cells[2, 2].Value = "Legumes";
            library.Cells[2, 3].Value = "659 KG";
            
            library.Cells[3, 1].Value = "Wheat";
            library.Cells[3, 2].Value = "Legumes";
            library.Cells[3, 3].Value = "832 KG";
            
            library.Cells[4, 1].Value = "Carrot";
            library.Cells[4, 2].Value = "Vegetables";
            library.Cells[4, 3].Value = "1.235 KG";

            var bytes = excelPackage.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "LegumesReport.xlsx");
        }
        private List<ContactModel> contacts()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using(var context=new AgriCultureContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactID= x.ContactID,
                    ContactName=x.Name,
                    ContactEmail=x.Email,
                    ContactMessage=x.Message,
                    ContactDate=x.Date
                }).ToList();
            }
            return contactModels;
        }
        public IActionResult ContactReport()
        {
            using (var library = new XLWorkbook())
            {
                var workSheet = library.Worksheets.Add("Message List");
                workSheet.Cell(1, 1).Value = "Message ID";
                workSheet.Cell(1, 2).Value = "Sender of Message";
                workSheet.Cell(1, 3).Value = "E-mail";
                workSheet.Cell(1, 4).Value = "Message Content";
                workSheet.Cell(1, 5).Value = "Message Date";

                int rowCount = 2;
                foreach(var item in contacts())
                {
                    workSheet.Cell(rowCount,1).Value= item.ContactID;
                    workSheet.Cell(rowCount,2).Value= item.ContactName;
                    workSheet.Cell(rowCount,3).Value= item.ContactEmail;
                    workSheet.Cell(rowCount,4).Value= item.ContactMessage;
                    workSheet.Cell(rowCount,5).Value= item.ContactDate;
                    rowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    library.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MessageList.xlsx");
                }
            }
        }
        private List<AnnouncementModel> Announcements()
        {
            List<AnnouncementModel> announcementModels= new List<AnnouncementModel>(); 
            using( var context=new AgriCultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    AnnouncementID= x.AnnouncementID,
                    Title= x.Title,
                    Description= x.Description,
                    Date= x.Date,
                    Status= x.Status
                }).ToList();
            }
            return announcementModels;
            
        }
        public IActionResult AnnouncementReports()
        {
            using(var workBook=new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add("Announcements List");
                worksheet.Cell(1, 1).Value = "Announcement ID";
                worksheet.Cell(1, 2).Value = "Title";
                worksheet.Cell(1, 3).Value = "Description";
                worksheet.Cell(1, 4).Value = "Date";
                worksheet.Cell(1, 5).Value = "Status";

                int rowCount = 2;
                foreach(var item in Announcements())
                {
                    worksheet.Cell(rowCount,1).Value= item.AnnouncementID;
                    worksheet.Cell(rowCount,2).Value= item.Title;
                    worksheet.Cell(rowCount,3).Value = item.Description;
                    worksheet.Cell(rowCount,4).Value = item.Date;
                    worksheet.Cell(rowCount,5).Value = item.Status;
                    rowCount++;
                }
                using(var stream= new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AnnouncementList.xlsx");
                }
            }
        }
        private List<ProductModel> Products()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            using(var context=new AgriCultureContext())
            {
                productModels = context.Crops.Select(x => new ProductModel
                {
                    ProductID=x.cropid,
                    ProductName=x.cropname,
                    ProductQuantity=x.cropnum
                }).ToList();
            }
            return productModels;
        }
        public IActionResult ProductReports()
        {
            using(var workBook=new XLWorkbook())
            {
                var worksheet = workBook.Worksheets.Add("Products List");
                worksheet.Cell(1, 1).Value = "Product ID";
                worksheet.Cell(1, 2).Value = "Name";
                worksheet.Cell(1, 3).Value = "Quantity";

                int rowCount = 2;
                foreach(var item in Products())
                {
                    worksheet.Cell(rowCount, 1).Value = item.ProductID;
                    worksheet.Cell(rowCount, 2).Value = item.ProductName;
                    worksheet.Cell(rowCount, 3).Value = item.ProductQuantity;
                    rowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","ProductsList.xlsx");
                }
            }
        }
    }
}
