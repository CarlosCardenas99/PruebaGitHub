using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Paltarumi.Acopio.Domain.Queries.Sunat
{
    public class SunatStorage
    {
        public SunatConsultaRucDto consultaRuc(string ruc)
        {
            SunatVa sunatVa = new SunatVa();
            SunatConsultaRucDto response = new SunatConsultaRucDto();
            string URL;
            EmpresaApiEn empresa;

            try
            {
                string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImNyZWF0aXZlLnN0b3JlLnRpZ3JlZG9yYWRvQGdtYWlsLmNvbSJ9.9oLsNwlFccNP160Ox8kXRPriBbdnShX3Gj1h2ATmNKE";
                // Dim token As String = UserLoggin.token01
                URL = $"https://dniruc.apisperu.com/api/v1/ruc/{ruc}?token={token}";

                string json_de_respuesta = sendJsonGET(URL, token);
                if (json_de_respuesta.Contains("html"))
                {
                    response.response = new Response(-1, "Error en la consulta");
                    return response;
                }
                if (json_de_respuesta.Contains("false"))
                {
                    var status = JsonConvert.DeserializeObject<ResponseErrorSunat>(json_de_respuesta);
                    response.response = new Response(-1, status.message);
                    return response;
                }
                var r = JsonConvert.DeserializeObject<EmpresaApiEn>(json_de_respuesta);
                var json_r_in = JsonConvert.SerializeObject(r, Formatting.Indented);
                empresa = JsonConvert.DeserializeObject<EmpresaApiEn>(json_de_respuesta);

                response.sunatVo = new SunatConsultaRucVo();

                response.sunatVo.ruc = empresa.ruc;
                response.sunatVo.razonSocial = empresa.razonSocial;
                response.sunatVo.direccion = empresa.direccion;
                response.sunatVo.departamento = empresa.departamento;
                response.sunatVo.provincia = empresa.provincia;
                response.sunatVo.distrito = empresa.distrito;
                response.sunatVo.ubigeo = empresa.ubigeo;

                response.response = new Response();
                return response;
            }
            catch (Exception ex)
            {
                response = consultaRucLaravel(ruc);
            }

            return response;
        }

        public SunatConsultaRucDto consultaRucLaravel(string ruc)
        {
            SunatConsultaRucDto response = new SunatConsultaRucDto();
            string URL;
            EmpresaApiLaravelEn empresa;

            try
            {
                string token = "961ecd96a2e13e7b523267f28b29cffbdbd4b147904a39520fd3374cd68b7774";
                // Dim token As String = UserLoggin.token02
                URL = $"https://apiperu.dev/api/ruc/{ruc}";

                string json_de_respuesta = sendJsonGET(URL, token);

                var r = JsonConvert.DeserializeObject<EmpresaApiLaravelEn>(json_de_respuesta);
                var json_r_in = JsonConvert.SerializeObject(r, Formatting.Indented);
                empresa = JsonConvert.DeserializeObject<EmpresaApiLaravelEn>(json_de_respuesta);

                if (empresa.success)
                {
                    response.sunatVo = new SunatConsultaRucVo();
                    response.sunatVo.ruc = empresa.data.ruc;
                    response.sunatVo.razonSocial = empresa.data.nombre_o_razon_social;
                    response.sunatVo.direccion = empresa.data.direccion_completa;
                    response.sunatVo.ubigeo = String.Empty;
                }
                else
                    response = consultaRucOptimize(ruc);

                response.response = new Response();
                return response;
            }
            catch (Exception ex)
            {
                response = consultaRucOptimize(ruc);
            }

            return response;
        }

        public SunatConsultaRucDto consultaRucOptimize(string ruc)
        {
            SunatConsultaRucDto response = new SunatConsultaRucDto();
            string URL;
            EmpresaApiOptimizeEn empresa;

            try
            {
                URL = $"https://dni.optimizeperu.com/api/company/{ruc}";

                string json_de_respuesta = sendJsonGET(URL, string.Empty);

                var r = JsonConvert.DeserializeObject<EmpresaApiOptimizeEn>(json_de_respuesta);
                var json_r_in = JsonConvert.SerializeObject(r, Formatting.Indented);
                empresa = JsonConvert.DeserializeObject<EmpresaApiOptimizeEn>(json_de_respuesta);

                response.sunatVo = new SunatConsultaRucVo();
                response.sunatVo.ruc = empresa.ruc;
                response.sunatVo.razonSocial = empresa.nombre_comercial;
                response.sunatVo.direccion = "-";

                response.response = new Response();
                return response;
            }
            catch (Exception ex)
            {
                response.response = new Response();
                response.response.responseCode = -1;
                response.response.responseMessage = ex.Message;
            }

            return response;
        }

        public SunatConsultaRucDto consultaDni(string dni)
        {
            SunatConsultaRucDto response = new SunatConsultaRucDto();
            string URL;
            PersonaApiEn persona;

            try
            {
                string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImNyZWF0aXZlLnN0b3JlLnRpZ3JlZG9yYWRvQGdtYWlsLmNvbSJ9.9oLsNwlFccNP160Ox8kXRPriBbdnShX3Gj1h2ATmNKE";
                // Dim token As String = UserLoggin.token01
                URL = $"https://dniruc.apisperu.com/api/v1/dni/{dni}?token={token}";

                string json_de_respuesta = sendJsonGET(URL, token);

                var r = JsonConvert.DeserializeObject<PersonaApiEn>(json_de_respuesta);
                var json_r_in = JsonConvert.SerializeObject(r, Formatting.Indented);
                persona = JsonConvert.DeserializeObject<PersonaApiEn>(json_de_respuesta);

                response.sunatVo = new SunatConsultaRucVo();
                response.sunatVo.ruc = persona.dni;
                response.sunatVo.razonSocial = string.Format("{0} {1} {2}", persona.apellidoPaterno, persona.apellidoMaterno, persona.nombres);
                response.sunatVo.direccion = string.Empty;

                if (response.sunatVo.razonSocial.Trim() == string.Empty)
                    response = consultaDniLaravel(dni);
                else
                    response.response = new Response();
                return response;
            }
            catch (Exception ex)
            {
                response = consultaDniLaravel(dni);
            }

            return response;
        }

        public SunatConsultaRucDto consultaDniLaravel(string dni)
        {
            SunatConsultaRucDto response = new SunatConsultaRucDto();
            string URL;
            PersonaApiLaravelEn persona;

            try
            {
                string token = "961ecd96a2e13e7b523267f28b29cffbdbd4b147904a39520fd3374cd68b7774";
                // Dim token As String = UserLoggin.token02

                URL = $"https://apiperu.dev/api/dni/{dni}";

                string json_de_respuesta = sendJsonGET(URL, token);

                var r = JsonConvert.DeserializeObject<PersonaApiLaravelEn>(json_de_respuesta);
                var json_r_in = JsonConvert.SerializeObject(r, Formatting.Indented);
                persona = JsonConvert.DeserializeObject<PersonaApiLaravelEn>(json_de_respuesta);

                if (persona.success)
                {
                    response.sunatVo = new SunatConsultaRucVo();
                    response.sunatVo.ruc = persona.data.numero;
                    response.sunatVo.razonSocial = persona.data.nombre_completo;
                    response.sunatVo.direccion = "-";

                    response.response = new Response();
                }
                else
                    response = consultaDniOptimize(dni);

                return response;
            }
            catch (Exception ex)
            {
                response = consultaDniOptimize(dni);
            }

            return response;
        }

        public SunatConsultaRucDto consultaDniOptimize(string dni)
        {
            SunatConsultaRucDto response = new SunatConsultaRucDto();
            string URL;
            PersonaApiOptimizeEn persona;

            try
            {
                URL = $"https://dni.optimizeperu.com/api/persons/{dni}";

                string json_de_respuesta = sendJsonGET(URL, string.Empty);

                var r = JsonConvert.DeserializeObject<PersonaApiOptimizeEn>(json_de_respuesta);
                var json_r_in = JsonConvert.SerializeObject(r, Formatting.Indented);
                persona = JsonConvert.DeserializeObject<PersonaApiOptimizeEn>(json_de_respuesta);

                response.sunatVo = new SunatConsultaRucVo();
                response.sunatVo.ruc = persona.dni;
                response.sunatVo.razonSocial = string.Format("{0} {1} {2}", persona.first_name, persona.last_name, persona.name);
                response.sunatVo.direccion = string.Empty;

                response.response = new Response();
                return response;
            }
            catch (Exception ex)
            {
                response.response = new Response();
                response.response.responseCode = -1;
                response.response.responseMessage = ex.Message;
            }

            return response;
        }

        public string sendJsonGET(string ruta, string token)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    if (token != string.Empty)
                        wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

                    var respuesta = wc.DownloadString(ruta);
                    return respuesta;
                }
                catch (WebException x)
                {
                    return new StreamReader(x.Response.GetResponseStream()).ReadToEnd();
                }
            }
        }

        public string sendJsonPOST(string ruta, string token, string json)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                    // wc.Headers.Add(HttpRequestHeader.Authorization, "Token token=" & token)
                    wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                    var respuesta = wc.UploadString(ruta, "POST", json);
                    return respuesta;
                }
                catch (WebException x)
                {
                    return new StreamReader(x.Response.GetResponseStream()).ReadToEnd();
                }
            }
        }


    }

    public class ResponseErrorSunat
    {
        public string success { get; set; }
        public string message { get; set; }
    }

    class EmpresaApiEn
    {
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public List<string> telefonos { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public string condicion { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string fechaInscripcion { get; set; }
        public string sistEmsion { get; set; }
        public string sistContabilidad { get; set; }
        public string actExterior { get; set; }
        public List<string> actEconomicas { get; set; }
        public List<string> cpPago { get; set; }
        public List<string> sistElectronica { get; set; }
        public string fechaEmisorFe { get; set; }
        public List<string> cpeElectronico { get; set; }
        public string fechaPle { get; set; }
        public List<string> padrones { get; set; }
        public string fechaBaja { get; set; }
        public string profesion { get; set; }
        public string ubigeo { get; set; }
        public string capital { get; set; }
    }

    class EmpresaApiLaravelEn
    {
        public bool success { get; set; }
        public EmpresaApiLaravelDataEn data { get; set; }
    }

    class EmpresaApiLaravelDataEn
    {
        public string direccion { get; set; }
        public string direccion_completa { get; set; }
        public string ruc { get; set; }
        public string nombre_o_razon_social { get; set; }
        public string estado { get; set; }
        public string condicion { get; set; }
        public List<string> ubigeo { get; set; }
        public int origen { get; set; }
    }

    class EmpresaApiOptimizeEn
    {
        public string ruc { get; set; }
        public string razon_social { get; set; }
        public string actividad_economica { get; set; }
        public string fecha_actividad { get; set; }
        public string tipo { get; set; }
        public string nombre_comercial { get; set; }
        public string fecha_inscripcion { get; set; }
        public string sistema_emision { get; set; }
        public string sistema_contabilidad { get; set; }
        public string actividad_exterior { get; set; }
        public string emision_electronica { get; set; }
        public string fecha_inscripcion_ple { get; set; }
        public string fecha_baja { get; set; }
        public string empleados { get; set; }
        public string sucursales { get; set; }
    }

    class PersonaApiEn
    {
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string codVerifica { get; set; }
    }

    class PersonaApiLaravelEn
    {
        public bool success { get; set; }
        public PersonaApiLaravelDataEn data { get; set; }
    }

    class PersonaApiLaravelDataEn
    {
        public int origen { get; set; }
        public string numero { get; set; }
        public string nombre_completo { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string codigo_verificacion { get; set; }
        public string sexo { get; set; }
    }

    class PersonaApiOptimizeEn
    {
        public string dni { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string cui { get; set; }
    }
    public class SunatConsultaRucDto
    {
        public Response response { get; set; }
        public SunatConsultaRucVo sunatVo { get; set; }
    }
    public class Response
    {
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public Response()
        {
            this.responseCode = 0;
            this.responseMessage = "OK";
        }

        public Response(int responseCode, string message)
        {
            this.responseCode = responseCode;
            this.responseMessage = message;
        }
    }

    public class SunatConsultaRucVo
    {
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string ubigeo { get; set; }
    }
    public class SunatVa
    {
        public Response validarDni(string dni)
        {
            if ( dni.All(char.IsNumber))
                return responseValidator(-2, "dni formato incorrecto");
            else if (dni.Length != 8)
                return responseValidator(-3, "dni cantidad incorrecta");

            return new Response();
        }

        public Response validarRuc(string ruc)
        {
            if (ruc.All(char.IsNumber))
                return responseValidator(-1, "ruc Formato Incorrecto");
            else if (ruc.Length != 11)
                return responseValidator(-2, "ruc Cantidad Incorrecta");
            else
            {
                var Factores = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                var Resultado = 0;
                for (var i = 0; i <= 9; i++)
                {
                    var Valor = Int32.Parse(ruc.Substring(i, 1));
                    Factores[i] = Valor * Factores[i];
                }

                Resultado = 11 - (Factores.Sum() % 11);
                Resultado = Resultado == 10 ? 0: ( Resultado == 11 ? 1: Resultado);

                //if (Resultado > 11) Resultado = Strings.Right(Resultado, 1);

                //if (Resultado != Strings.Right(ruc, 1)) return responseValidator(-3, "ruc Numero Incorrecto");
            }

            return new Response();
        }


        private Response responseValidator(int code, string message)
        {
            Response response = new Response();
            response.responseCode = code;
            response.responseMessage = message;
            return response;
        }
    }
}
