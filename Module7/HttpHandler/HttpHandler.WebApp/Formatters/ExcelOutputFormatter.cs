using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace HttpHandler.WebApp.Formatters
{
    public class ExcelOutputFormatter : OutputFormatter
    {
        private const string _mediaType = 
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ExcelOutputFormatter() 
            => SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(_mediaType));

        protected override bool CanWriteType(Type type)
        {
            return typeof(IEnumerable<object>).IsAssignableFrom(type);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var excelStream = CreateExcelFile(context.Object as IEnumerable<object>);
            var response = context.HttpContext.Response;
            response.ContentLength = excelStream.Length;

            await response.Body.WriteAsync(excelStream.ToArray());
        }

        public override void WriteResponseHeaders(OutputFormatterWriteContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var fileName = (context.Object as IEnumerable<object>)?.GetType()
                .GetGenericArguments()
                .FirstOrDefault();

            context.HttpContext.Response.Headers["Content-Disposition"] =
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName + ".xlsx"
                }.ToString();

            context.HttpContext.Response.ContentType = _mediaType;
        }

        private static MemoryStream CreateExcelFile(IEnumerable<object> data)
        {
            var ms = new MemoryStream();

            using var spreedDoc = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
            //openxml stuff
            var wbPart = spreedDoc.AddWorkbookPart();
            wbPart.Workbook = new Workbook();
            var worksheetPart = wbPart.AddNewPart<WorksheetPart>();
            var sheetData = new SheetData();
            worksheetPart.Worksheet = new Worksheet(sheetData);
            wbPart.Workbook.AppendChild(new Sheets());
            var sheet = new Sheet()
            {
                Id = wbPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Sheet1"
            };

            //get model properties
            var props = new List<PropertyInfo>(data.First()
                .GetType()
                .GetProperties());

            //header
            var headerRow = new Row();
            foreach (var prop in props)
                headerRow.AppendChild(GetCell(prop.Name));
            sheetData.AppendChild(headerRow);

            //body
            foreach (var record in data)
            {
                var row = new Row();
                foreach (var propValue in props.Select(prop => prop.GetValue(record, null)?.ToString()))
                    row.AppendChild(GetCell(propValue));
                sheetData.AppendChild(row);
            }
            wbPart.Workbook.Sheets.AppendChild(sheet);
            wbPart.Workbook.Save();
            return ms;
        }

        private static Cell GetCell(string text)
        {
            var cell = new Cell()
            {
                DataType = CellValues.InlineString
            };
            var inlineString = new InlineString();
            inlineString.AppendChild(new Text(text));

            cell.AppendChild(inlineString);
            return cell;
        }
    }
}
