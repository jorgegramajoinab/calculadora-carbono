using model.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace carbon_calculator.Controllers
{
    [RoutePrefix("api/Excel")]
    public class ExcelApiController : ApiController
    {
        public class Projections
        {
            public List<double[]> co2 { get; set; } = new List<double[]>();
            public List<double[]> carbono { get; set; } = new List<double[]>();
            public List<double[]> altura { get; set; } = new List<double[]>();
            public List<double[]> area { get; set; } = new List<double[]>();
            public List<double[]> dap { get; set; } = new List<double[]>();
            public List<double[]> volumen { get; set; } = new List<double[]>();
        }

        public class Parameters
        {
            public int years { get; set; }
            public int number { get; set; }
            public bool raleos { get; set; }
        }

        public class DataStructure
        {
            public Projections projections { get; set; }
            public Species specie { get; set; }
            public SpeciesGroundIndex groundIndex { get; set; }
            public Parameters parameters { get; set; } = new Parameters();
        }
        // POST: api/Excel
        [Route("")]
        public HttpResponseMessage Post([FromBody]DataStructure projections)
        {

            using (var excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Proyecciones");

                var workSheet = excel.Workbook.Worksheets["Proyecciones"];

                workSheet.Cells["A1:D1"].Merge = true;
                workSheet.Cells["A1:D1"].Value = "Variables de ingreso de datos";
                workSheet.Cells["A1:D1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#d8e4bc"));

                /* Viñeta principal con inputs */
                workSheet.Cells["A2"].Value = "Especie";
                workSheet.Cells["A3"].Value = projections.specie.commonName;
                workSheet.Cells["B2"].Value = "Indice de sitio";
                workSheet.Cells["B3"].Value = projections.groundIndex.ToString();
                workSheet.Cells["C2"].Value = "Árboles por héctarea";
                workSheet.Cells["C3"].Value = projections.parameters.number;
                workSheet.Cells["D2"].Value = "Años proyectados";
                workSheet.Cells["D3"].Value = projections.parameters.years;


                workSheet.Cells["A2:D2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A2:D2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#d8e4bc"));


                //workSheet.Cells[workSheet.Dimension.Address].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                //workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                //workSheet.Cells[workSheet.Dimension.Address].Style.Font.Bold = true;
                var stream = new MemoryStream(excel.GetAsByteArray());

                var response = Request.CreateResponse(HttpStatusCode.OK, new StreamContent(stream));

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                response.Content.Headers.ContentLength = stream.Length;


                return response;
            }
        }
    }
}
