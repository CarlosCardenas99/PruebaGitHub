using AutoMapper;
using MediatR;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style.XmlAccess;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class ExportLoteBalanzaQueryHandler : SearchQueryHandlerBase<ExportLoteBalanzaQuery, SearchLoteBalanzaFilterDto, byte>
    {
        public ExportLoteBalanzaQueryHandler(
            IMapper mapper,
            IMediator mediator
        ) : base(mapper, mediator)
        {

        }

        protected override async Task<ResponseDto<SearchResultDto<byte>>> HandleQuery(ExportLoteBalanzaQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<byte>>();
            var searchResult = await _mediator?.Send(new SearchLoteBalanzaQuery(request.SearchParams))!;
            var itemsToExport = searchResult?.Data?.Items ?? new List<SearchLoteBalanzaDto>();

            using ExcelPackage excelPackage = new ExcelPackage();

            excelPackage.Workbook.Properties.Title = Resources.Balanza.LoteBalanza.ExcelReportTitle;
            excelPackage.Workbook.Properties.Author = Resources.Common.ExcelReportAuthor;

            ExcelNamedStyleXml styleHeader = excelPackage.Workbook.Styles.CreateNamedStyle("StyleHeader");

            styleHeader.Style.Font.Bold = true;
            styleHeader.Style.Font.Color.SetColor(System.Drawing.Color.White);
            styleHeader.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            styleHeader.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            styleHeader.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            styleHeader.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            styleHeader.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            styleHeader.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            styleHeader.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            styleHeader.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
            styleHeader.Style.Fill.PatternType = ExcelFillStyle.Solid;
            styleHeader.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(128, 128, 128));

            ExcelNamedStyleXml styleHeaderAlt = excelPackage.Workbook.Styles.CreateNamedStyle("StyleHeaderAlt");
            styleHeaderAlt.Style.Font.Bold = true;
            styleHeaderAlt.Style.Font.Color.SetColor(System.Drawing.Color.White);
            styleHeaderAlt.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            styleHeaderAlt.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            styleHeaderAlt.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            styleHeaderAlt.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            styleHeaderAlt.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            styleHeaderAlt.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            styleHeaderAlt.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            styleHeaderAlt.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
            styleHeaderAlt.Style.Fill.PatternType = ExcelFillStyle.Solid;
            styleHeaderAlt.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(191, 143, 0));

            ExcelNamedStyleXml styleCellText = excelPackage.Workbook.Styles.CreateNamedStyle("StyleCellText");
            styleCellText.Style.Numberformat.Format = "@";
            styleCellText.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            styleCellText.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            styleCellText.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            styleCellText.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            styleCellText.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            styleCellText.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            styleCellText.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            styleCellText.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);

            ExcelNamedStyleXml styleNumericTwoDecimals = excelPackage.Workbook.Styles.CreateNamedStyle("StyleNumericTwoDecimals");
            styleNumericTwoDecimals.Style.Numberformat.Format = "#,###,##0.00";
            styleNumericTwoDecimals.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            styleNumericTwoDecimals.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            styleNumericTwoDecimals.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            styleNumericTwoDecimals.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            styleNumericTwoDecimals.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            styleNumericTwoDecimals.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            styleNumericTwoDecimals.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            styleNumericTwoDecimals.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);

            ExcelNamedStyleXml styleCellDate = excelPackage.Workbook.Styles.CreateNamedStyle("StyleCellDate");
            styleCellDate.Style.Numberformat.Format = Resources.Common.ExcelFormatFecha;
            styleCellDate.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            styleCellDate.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            styleCellDate.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            styleCellDate.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            styleCellDate.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            styleCellDate.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            styleCellDate.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            styleCellDate.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);

            var headerRow = 2;
            var contentDataRow = 3;

            ExcelWorksheet _worksheet = excelPackage.Workbook.Worksheets.Add(
                string.Format(Resources.Balanza.LoteBalanza.ExcelReportName, DateTimeOffset.Now)
            );

            _worksheet.Cells[headerRow, 02].Value = "IdLoteBalanza";
            _worksheet.Cells[headerRow, 02].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 03].Value = "Estado";
            _worksheet.Cells[headerRow, 03].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 04].Value = "NombreConcesion";
            _worksheet.Cells[headerRow, 04].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 05].Value = "FechaAcopio";
            _worksheet.Cells[headerRow, 05].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 06].Value = "CantidadSacos";
            _worksheet.Cells[headerRow, 06].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 07].Value = "FechaIngreso";
            _worksheet.Cells[headerRow, 07].StyleName = "StyleHeaderAlt";

            _worksheet.Cells[headerRow, 08].Value = "CodigoLote";
            _worksheet.Cells[headerRow, 08].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 09].Value = "NombreProveedor";
            _worksheet.Cells[headerRow, 09].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 10].Value = "NombreEstadoTipoMaterial";
            _worksheet.Cells[headerRow, 10].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 11].Value = "Tmh";
            _worksheet.Cells[headerRow, 11].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 12].Value = "Humedad";
            _worksheet.Cells[headerRow, 12].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 13].Value = "Tms";
            _worksheet.Cells[headerRow, 13].StyleName = "StyleHeaderAlt";

            _worksheet.Cells[headerRow, 14].Value = "NumeroTickets";
            _worksheet.Cells[headerRow, 14].StyleName = "StyleHeader";

            if (searchResult.IsValid && itemsToExport.Any())
            {
                foreach (var lote in itemsToExport)
                {
                    var formatoFecha = "{0:format}";

                    _worksheet.Cells[contentDataRow, 02].Value = lote.IdLoteBalanza;
                    _worksheet.Cells[contentDataRow, 02].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 03].Value = lote.Estado;
                    _worksheet.Cells[contentDataRow, 03].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 04].Value = lote.NombreConcesion;
                    _worksheet.Cells[contentDataRow, 04].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 05].Value = string.Format(formatoFecha.Replace("format", Resources.Common.ExcelFormatFecha), lote.FechaAcopio);
                    _worksheet.Cells[contentDataRow, 05].StyleName = "StyleCellDate";

                    _worksheet.Cells[contentDataRow, 06].Value = lote.CantidadSacos;
                    _worksheet.Cells[contentDataRow, 06].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 07].Value = string.Format(formatoFecha.Replace("format", Resources.Common.ExcelFormatFecha), lote.FechaIngreso);
                    _worksheet.Cells[contentDataRow, 07].StyleName = "StyleCellDate";

                    _worksheet.Cells[contentDataRow, 08].Value = lote.CodigoLote;
                    _worksheet.Cells[contentDataRow, 08].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 09].Value = lote.NombreProveedor;
                    _worksheet.Cells[contentDataRow, 09].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 10].Value = lote.NombreEstadoTipoMaterial;
                    _worksheet.Cells[contentDataRow, 10].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 11].Value = lote.Tmh;
                    _worksheet.Cells[contentDataRow, 11].StyleName = "StyleNumericTwoDecimals";

                    _worksheet.Cells[contentDataRow, 12].Value = lote.Humedad;
                    _worksheet.Cells[contentDataRow, 12].StyleName = "StyleNumericTwoDecimals";

                    _worksheet.Cells[contentDataRow, 13].Value = lote.Tms;
                    _worksheet.Cells[contentDataRow, 13].StyleName = "StyleNumericTwoDecimals";

                    _worksheet.Cells[contentDataRow, 14].Value = lote.NumeroTickets;
                    _worksheet.Cells[contentDataRow, 14].StyleName = "StyleCellText";

                    contentDataRow++;
                }
            }
            else
            {
                contentDataRow++;

                _worksheet.Cells[contentDataRow, 02].Value = Resources.Common.ExcelReportEmpty;
                _worksheet.Cells[contentDataRow, 02].StyleName = "StyleCellDate";

                contentDataRow++;
            }

            for (int col = 1; col <= 14; col++)
                _worksheet.Column(col).AutoFit();

            _worksheet.Calculate();

            var bytes = new byte[0];

            using (var memoryStream = new MemoryStream())
            {
                excelPackage.SaveAs(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                bytes = memoryStream.ToArray();
            }

            response.UpdateData(new SearchResultDto<byte>
            {
                Items = bytes
            });

            return await Task.FromResult(response);
        }
    }
}
