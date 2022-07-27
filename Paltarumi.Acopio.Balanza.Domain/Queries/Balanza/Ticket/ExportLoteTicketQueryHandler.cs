using AutoMapper;
using MediatR;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style.XmlAccess;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class ExportLoteTicketQueryHandler : SearchQueryHandlerBase<ExportLoteTicketQuery, SearchConsultaTicketFilterDto, byte>
    {
        public ExportLoteTicketQueryHandler(
            IMapper mapper,
            IMediator mediator
        ) : base(mapper, mediator)
        {

        }

        protected override async Task<ResponseDto<SearchResultDto<byte>>> HandleQuery(ExportLoteTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<byte>>();
            var searchResult = await _mediator?.Send(new SearchConsultaTicketQuery(request.SearchParams))!;
            var itemsToExport = searchResult?.Data?.Items ?? new List<SearchConsultaTicketDto>();

            using ExcelPackage excelPackage = new ExcelPackage();

            excelPackage.Workbook.Properties.Title = Resources.Balanza.Ticket.ExcelReportTitle;
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

            ExcelNamedStyleXml styleNumericthreeDecimals = excelPackage.Workbook.Styles.CreateNamedStyle("styleNumericthreeDecimals");
            styleNumericthreeDecimals.Style.Numberformat.Format = "#,###,##0.000";
            styleNumericthreeDecimals.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            styleNumericthreeDecimals.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
            styleNumericthreeDecimals.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            styleNumericthreeDecimals.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
            styleNumericthreeDecimals.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            styleNumericthreeDecimals.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            styleNumericthreeDecimals.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            styleNumericthreeDecimals.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);

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
            var contentDataRow = 3;//headerRow

            ExcelWorksheet _worksheet = excelPackage.Workbook.Worksheets.Add(
                string.Format(Resources.Balanza.Ticket.ExcelReportName, DateTimeOffset.Now)
            );

            _worksheet.Cells[headerRow, 02].Value = "Lote";
            _worksheet.Cells[headerRow, 02].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 03].Value = "Ticket";
            _worksheet.Cells[headerRow, 03].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 04].Value = "Fecha Ingreso";
            _worksheet.Cells[headerRow, 04].StyleName = "StyleHeaderAlt";

            _worksheet.Cells[headerRow, 05].Value = "Fecha Salida";
            _worksheet.Cells[headerRow, 05].StyleName = "StyleHeaderAlt";

            _worksheet.Cells[headerRow, 06].Value = "Concesion";
            _worksheet.Cells[headerRow, 06].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 07].Value = "Proveedor";
            _worksheet.Cells[headerRow, 07].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 08].Value = "Grr";
            _worksheet.Cells[headerRow, 08].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 09].Value = "Grt";
            _worksheet.Cells[headerRow, 09].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 10].Value = "Estado Tmh";
            _worksheet.Cells[headerRow, 10].StyleName = "StyleHeaderAlt";

            _worksheet.Cells[headerRow, 11].Value = "Peso Bruto";
            _worksheet.Cells[headerRow, 11].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 12].Value = "Tara";
            _worksheet.Cells[headerRow, 12].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 13].Value = "Peso Neto";
            _worksheet.Cells[headerRow, 13].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 14].Value = "Estado Tmh Carreta";
            _worksheet.Cells[headerRow, 14].StyleName = "StyleHeaderAlt";

            _worksheet.Cells[headerRow, 15].Value = "Peso Bruto Carreta";
            _worksheet.Cells[headerRow, 15].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 16].Value = "Tara Carreta";
            _worksheet.Cells[headerRow, 16].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 17].Value = "Peso Neto Carreta";
            _worksheet.Cells[headerRow, 17].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 18].Value = "Peso Neto Total";
            _worksheet.Cells[headerRow, 18].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 19].Value = "Transportista";
            _worksheet.Cells[headerRow, 19].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 20].Value = "Placa";
            _worksheet.Cells[headerRow, 20].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 21].Value = "Marca Vehiculo";
            _worksheet.Cells[headerRow, 21].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 22].Value = "Tipo Vehiculo";
            _worksheet.Cells[headerRow, 22].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 23].Value = "Vehiculo Tara";
            _worksheet.Cells[headerRow, 23].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 24].Value = "Conductor";
            _worksheet.Cells[headerRow, 24].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 25].Value = "Licencia";
            _worksheet.Cells[headerRow, 25].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 26].Value = "Unidad Medida";
            _worksheet.Cells[headerRow, 26].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 27].Value = "Cantidad Sacos";
            _worksheet.Cells[headerRow, 27].StyleName = "StyleHeader";

            _worksheet.Cells[headerRow, 28].Value = "Porcentaje Humedad";
            _worksheet.Cells[headerRow, 28].StyleName = "StyleHeaderAlt";

            if (searchResult.IsValid && itemsToExport.Any())
            {
                foreach (var lote in itemsToExport)
                {
                    var formatoFecha = "{0:format}";

                    _worksheet.Cells[contentDataRow, 02].Value = lote.CodigoLote;
                    _worksheet.Cells[contentDataRow, 02].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 03].Value = lote.Numero;
                    _worksheet.Cells[contentDataRow, 03].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 04].Value = string.Format(formatoFecha.Replace("format", Resources.Common.ExcelFormatFecha), lote.FechaIngreso);
                    _worksheet.Cells[contentDataRow, 04].StyleName = "StyleCellDate";

                    _worksheet.Cells[contentDataRow, 05].Value = string.Format(formatoFecha.Replace("format", Resources.Common.ExcelFormatFecha), lote.FechaSalida);
                    _worksheet.Cells[contentDataRow, 05].StyleName = "StyleCellDate";

                    _worksheet.Cells[contentDataRow, 06].Value = lote.Concesion;
                    _worksheet.Cells[contentDataRow, 06].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 07].Value = lote.Proveedor;
                    _worksheet.Cells[contentDataRow, 07].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 08].Value = lote.Grr;
                    _worksheet.Cells[contentDataRow, 08].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 09].Value = lote.Grt;
                    _worksheet.Cells[contentDataRow, 09].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 10].Value = lote.EstadoTmh;
                    _worksheet.Cells[contentDataRow, 10].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 11].Value = lote.PesoBruto;
                    _worksheet.Cells[contentDataRow, 11].StyleName = "styleNumericthreeDecimals";

                    _worksheet.Cells[contentDataRow, 12].Value = lote.Tara;
                    _worksheet.Cells[contentDataRow, 12].StyleName = "styleNumericthreeDecimals";

                    _worksheet.Cells[contentDataRow, 13].Value = lote.PesoNeto;
                    _worksheet.Cells[contentDataRow, 13].StyleName = "styleNumericthreeDecimals";

                    _worksheet.Cells[contentDataRow, 14].Value = lote.EstadoTmhCarreta;
                    _worksheet.Cells[contentDataRow, 14].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 15].Value = lote.PesoBrutoCarreta;
                    _worksheet.Cells[contentDataRow, 15].StyleName = "styleNumericthreeDecimals";

                    _worksheet.Cells[contentDataRow, 16].Value = lote.TaraCarreta;
                    _worksheet.Cells[contentDataRow, 16].StyleName = "styleNumericthreeDecimals";

                    _worksheet.Cells[contentDataRow, 17].Value = lote.PesoNetoCarreta;
                    _worksheet.Cells[contentDataRow, 17].StyleName = "styleNumericthreeDecimals";

                    _worksheet.Cells[contentDataRow, 18].Value = lote.PesoNetoTotal;
                    _worksheet.Cells[contentDataRow, 18].StyleName = "styleNumericthreeDecimals";

                    _worksheet.Cells[contentDataRow, 19].Value = lote.Transportista;
                    _worksheet.Cells[contentDataRow, 19].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 20].Value = lote.Placa;
                    _worksheet.Cells[contentDataRow, 20].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 21].Value = lote.VehiculoMarca;
                    _worksheet.Cells[contentDataRow, 21].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 22].Value = lote.TipoVehiculo;
                    _worksheet.Cells[contentDataRow, 22].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 23].Value = lote.VehiculoTara;
                    _worksheet.Cells[contentDataRow, 23].StyleName = "styleNumericthreeDecimals";

                    _worksheet.Cells[contentDataRow, 24].Value = lote.Conductor;
                    _worksheet.Cells[contentDataRow, 24].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 25].Value = lote.Licencia;
                    _worksheet.Cells[contentDataRow, 25].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 26].Value = lote.UnidadMedida;
                    _worksheet.Cells[contentDataRow, 26].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 27].Value = lote.CantidadUnidadMedida;
                    _worksheet.Cells[contentDataRow, 27].StyleName = "StyleCellText";

                    _worksheet.Cells[contentDataRow, 28].Value = lote.PorcentajeHumedad;
                    _worksheet.Cells[contentDataRow, 28].StyleName = "StyleNumericTwoDecimals";

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

            for (int col = 1; col <= 28; col++)
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
