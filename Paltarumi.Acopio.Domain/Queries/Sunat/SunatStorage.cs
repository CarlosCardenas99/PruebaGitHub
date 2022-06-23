using Newtonsoft.Json;
using System.Net;

namespace Paltarumi.Acopio.Domain.Queries.Sunat
{
    public class SunatService
    {
        public string? Code { get; set; }
        public string? Url { get; set; }
        public string? PathRuc { get; set; }
        public string? PathDni { get; set; }
        public string? Token { get; set; }
    }


    public class SunatStorage
    {
        public List<SunatService> SunatServicesRuc = new List<SunatService>
        {
            new SunatService {
                Code = "dniruc",
                Url = "https://dniruc.apisperu.com/api/v1",
                PathRuc = "/ruc/{ruc}?token={token}",
                PathDni = "/dni/{dni}?token={token}",
                Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImNyZWF0aXZlLnN0b3JlLnRpZ3JlZG9yYWRvQGdtYWlsLmNvbSJ9.9oLsNwlFccNP160Ox8kXRPriBbdnShX3Gj1h2ATmNKE"
            },
            new SunatService {
                Code = "apiperu",
                Url = "https://apiperu.dev/api",
                PathRuc = "/ruc/{ruc}",
                PathDni = "/dni/{dni}",
                Token = "961ecd96a2e13e7b523267f28b29cffbdbd4b147904a39520fd3374cd68b7774"
            },
            new SunatService {
                Code = "optimizeperu",
                Url = "https://dni.optimizeperu.com/api",
                PathRuc = "/company/{ruc}",
                PathDni = "/persons/{dni}",
                Token = ""
            }
        };

        public SunatConsultaRucDto ConsultaRuc(string? ruc)
        {
            var response = new SunatConsultaRucDto();

            foreach (var sunatServicesRuc in SunatServicesRuc)
            {
                try
                {
                    var url = $"{sunatServicesRuc?.Url}{ sunatServicesRuc?.PathRuc}";

                    url = url?.Replace("{ruc}", ruc);
                    url = url?.Replace("{token}", sunatServicesRuc?.Token);

                    var json_de_respuesta = sendJsonGET(url, sunatServicesRuc?.Token);

                    if (json_de_respuesta.Contains("html"))
                    {
                        response.response = new Response(-1, "Error en la consulta");
                        continue;
                    }

                    if (json_de_respuesta.Contains("false"))
                    {
                        var status = JsonConvert.DeserializeObject<ResponseErrorSunat>(json_de_respuesta);
                        response.response = new Response(-1, status?.message);
                        continue;
                    }

                    //************************************************************************************

                    var r = JsonConvert.DeserializeObject<EmpresaApiEn>(json_de_respuesta);
                    var json_r_in = JsonConvert.SerializeObject(r, Formatting.Indented);
                    var empresa = JsonConvert.DeserializeObject<EmpresaApiEn>(json_de_respuesta);

                    if (empresa == null)
                    {
                        response.response = new Response(-1, "Error en la consulta");
                        continue;
                    }

                    response.sunatVo = sunatServicesRuc?.Code switch
                    {
                        "dniruc" => new SunatConsultaRucVo
                        {
                            ruc = empresa.ruc,
                            razonSocial = empresa.razonSocial,
                            direccion = empresa.direccion,
                            departamento = empresa.departamento,
                            provincia = empresa.provincia,
                            distrito = empresa.distrito,
                        },
                        "apiperu" => new SunatConsultaRucVo
                        {
                            ruc = empresa.data.ruc,
                            razonSocial = empresa.data.nombre_o_razon_social,
                            direccion = empresa.data.direccion_completa,
                            departamento = empresa.data.departamento,
                            provincia = empresa.data.provincia,
                            distrito = empresa.data.distrito,
                        },
                        "optimizeperu" => new SunatConsultaRucVo
                        {
                            ruc = empresa.ruc,
                            razonSocial = empresa.razonSocial,
                            direccion = empresa.direccion,
                            departamento = empresa.departamento,
                            provincia = empresa.provincia,
                            distrito = empresa.distrito,
                        },
                        _ => new SunatConsultaRucVo()
                    };

                    //************************************************************************************
                    response.response = new Response();

                    return response;

                }
                catch (Exception)
                {
                    continue;
                }
            }

            response.response = new Response(-1, "Error en la consulta");

            return response;
        }

        public SunatConsultaRucDto ConsultaDni(string? dni)
        {
            var response = new SunatConsultaRucDto();

            foreach (var sunatServicesRuc in SunatServicesRuc)
            {
                try
                {
                    var url = $"{sunatServicesRuc?.Url}{ sunatServicesRuc?.PathDni}";

                    url = url?.Replace("{dni}", dni);
                    url = url?.Replace("{token}", sunatServicesRuc?.Token);

                    var json_de_respuesta = sendJsonGET(url, sunatServicesRuc?.Token);

                    if (json_de_respuesta.Contains("html"))
                    {
                        response.response = new Response(-1, "Error en la consulta");
                        continue;
                    }

                    if (json_de_respuesta.Contains("false"))
                    {
                        var status = JsonConvert.DeserializeObject<ResponseErrorSunat>(json_de_respuesta);
                        response.response = new Response(-1, status?.message);
                        continue;
                    }

                    var r = JsonConvert.DeserializeObject<EmpresaApiEn>(json_de_respuesta);
                    var json_r_in = JsonConvert.SerializeObject(r, Formatting.Indented);
                    var persona = JsonConvert.DeserializeObject<PersonaApiEn>(json_de_respuesta);

                    if (persona == null)
                    {
                        response.response = new Response(-1, "Error en la consulta");
                        continue;
                    }

                    response.sunatVo = sunatServicesRuc?.Code switch
                    {
                        "dniruc" => new SunatConsultaRucVo
                        {
                            ruc = persona.dni,
                            razonSocial = string.Format("{0} {1} {2}", persona.apellidoPaterno, persona.apellidoMaterno, persona.nombres),
                            direccion = string.Empty
                        },
                        "apiperu" => new SunatConsultaRucVo
                        {
                            ruc = persona.data.numero,
                            razonSocial = persona.data.nombre_completo,
                            direccion = "-"
                        },
                        "optimizeperu" => new SunatConsultaRucVo
                        {
                            ruc = persona.dni,
                            razonSocial = string.Format("{0} {1} {2}", persona.first_name, persona.last_name, persona.name),
                            direccion = string.Empty
                        },
                        _ => new SunatConsultaRucVo()
                    };

                    if (response.sunatVo.razonSocial.Trim() == string.Empty)
                        continue;
                    response.response = new Response();
                    return response;

                }
                catch (Exception)
                {
                    continue;
                }
            }

            response.response = new Response(-1, "Error en la consulta");

            return response;
        }

        public string sendJsonGET(string? ruta, string? token)
        {
            using WebClient wc = new();

            try
            {
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                if (token != string.Empty)
                    wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

                var respuesta = wc.DownloadString(ruta!);
                return respuesta;
            }
            catch (WebException x)
            {
                return new StreamReader(x.Response?.GetResponseStream()!).ReadToEnd();
            }
        }

        public string sendJsonPOST(string ruta, string token, string json)
        {
            using WebClient wc = new();

            try
            {
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

                var respuesta = wc.UploadString(ruta, "POST", json);
                return respuesta;
            }
            catch (WebException ex)
            {
                return new StreamReader(ex?.Response?.GetResponseStream()!).ReadToEnd();
            }
        }
    }

    public class ResponseErrorSunat
    {
        public string success { get; set; } = null!;
        public string message { get; set; } = null!;
    }

    class EmpresaApiEn
    {
        public string ruc { get; set; } = null!;
        public string razonSocial { get; set; } = null!;
        public string nombreComercial { get; set; } = null!;
        public List<string> telefonos { get; set; } = null!;
        public string tipo { get; set; } = null!;
        public string estado { get; set; } = null!;
        public string condicion { get; set; } = null!;
        public string direccion { get; set; } = null!;
        public string departamento { get; set; } = null!;
        public string provincia { get; set; } = null!;
        public string distrito { get; set; } = null!;
        public string fechaInscripcion { get; set; } = null!;
        public string sistEmsion { get; set; } = null!;
        public string sistContabilidad { get; set; } = null!;
        public string actExterior { get; set; } = null!;
        public List<string> actEconomicas { get; set; } = null!;
        public List<string> cpPago { get; set; } = null!;
        public List<string> sistElectronica { get; set; } = null!;
        public string fechaEmisorFe { get; set; } = null!;
        public List<string> cpeElectronico { get; set; } = null!;
        public string fechaPle { get; set; } = null!;
        public List<string> padrones { get; set; } = null!;
        public string fechaBaja { get; set; } = null!;
        public string profesion { get; set; } = null!;
        public string ubigeo { get; set; } = null!;
        public string capital { get; set; } = null!;
        public EmpresaApiLaravelDataEn data { get; set; } = null!;
    }

    class EmpresaApiLaravelDataEn
    {
        public string direccion_completa { get; set; } = null!;
        public string ruc { get; set; } = null!;
        public string nombre_o_razon_social { get; set; } = null!;
        public string estado { get; set; } = null!;
        public string departamento { get; set; } = null!;
        public string provincia { get; set; } = null!;
        public string distrito { get; set; } = null!;
    }

    class PersonaApiEn
    {
        public string dni { get; set; } = null!;
        public string nombres { get; set; } = null!;
        public string apellidoPaterno { get; set; } = null!;
        public string apellidoMaterno { get; set; } = null!;
        public string codVerifica { get; set; } = null!;
        public bool success { get; set; }
        public string name { get; set; } = null!;
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string cui { get; set; } = null!;
        public PersonaApiLaravelDataEn data { get; set; } = null!;
    }

    class PersonaApiLaravelDataEn
    {
        public int origen { get; set; }
        public string numero { get; set; } = null!;
        public string nombre_completo { get; set; } = null!;
        public string nombres { get; set; } = null!;
        public string apellido_paterno { get; set; } = null!;
        public string apellido_materno { get; set; } = null!;
        public string codigo_verificacion { get; set; } = null!;
        public string sexo { get; set; } = null!;
    }

    public class SunatConsultaRucDto
    {
        public Response response { get; set; } = null!;
        public SunatConsultaRucVo sunatVo { get; set; } = null!;
    }

    public class Response
    {
        public int? responseCode { get; set; }
        public string? responseMessage { get; set; }

        public Response()
        {
            responseCode = 0;
            responseMessage = "OK";
        }

        public Response(int? responseCode, string? responseMessage)
        {
            this.responseCode = responseCode;
            this.responseMessage = responseMessage;
        }
    }

    public class SunatConsultaRucVo
    {
        public string ruc { get; set; } = null!;
        public string razonSocial { get; set; } = null!;
        public string direccion { get; set; } = null!;
        public string departamento { get; set; } = null!;
        public string provincia { get; set; } = null!;
        public string distrito { get; set; } = null!;
        public string ubigeo { get; set; } = null!;
    }
}
