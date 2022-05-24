using AcortadorApi.Data;
using AcortadorApi.ModelsLog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AcortadorApi.Middlewares
{
    public static class LoguearHTTPMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoguearHTTPMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoguearHTTPMiddleware>();
        }
    }

    public class LoguearHTTPMiddleware
    {
        private readonly RequestDelegate siguiente;



        public LoguearHTTPMiddleware(RequestDelegate siguiente)
        {
            this.siguiente = siguiente;


        }

        public async Task InvokeAsync(HttpContext contexto, UpdsLogContext contextdb)
        {
            // create a new log object
            var log = new LogApiSaad
            {
                Project = "AcortadorApi",
                Path = contexto.Request.PathBase + contexto.Request.Path,
                Method = contexto.Request.Method,
                QueryString = contexto.Request.QueryString.ToString()

            };




            // check if the Request is a POST call 
            // since we need to read from the body
            if (contexto.Request.Method == "POST")
            {
                contexto.Request.EnableBuffering();
                var body = await new StreamReader(contexto.Request.Body)
                                                    .ReadToEndAsync();
                contexto.Request.Body.Position = 0;
                log.Payload = body;
            }

            log.RequestedOn = DateTime.Now;



            using (Stream originalRequest = contexto.Response.Body)
            {
                try
                {
                    using (var memStream = new MemoryStream())
                    {
                        contexto.Response.Body = memStream;
                        // All the Request processing as described above 
                        // happens from here.
                        // Response handling starts from here
                        // set the pointer to the beginning of the 
                        // memory stream to read

                        await siguiente(contexto);

                        if (contexto.User.Identity!.IsAuthenticated)
                        {
                            long userId = long.Parse(contexto.User.Claims!.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)!.Value);
                            int sedeId = int.Parse(contexto.User.Claims!.FirstOrDefault(a => a.Type == "sedeId")!.Value);
                            log.CampusId = sedeId;
                            log.UserId = userId;
                        }
                        else
                        {
                            log.UserId = null;
                        }

                        var remoteIpAddress = contexto.Request.HttpContext.Connection.RemoteIpAddress!.ToString();
                        log.IpsClient = remoteIpAddress;



                        memStream.Seek(0, SeekOrigin.Begin);
                        // read the memory stream till the end
                        var response = new StreamReader(memStream).ReadToEnd();
                        // write the response to the log object
                        memStream.Seek(0, SeekOrigin.Begin);
                        log.Response = response;
                        log.ResponseCode = contexto.Response.StatusCode.ToString();
                        log.IsSuccessStatusCode = (
                              contexto.Response.StatusCode == 200 ||
                              contexto.Response.StatusCode == 201);
                        log.RespondedOn = DateTime.Now;

                        // add the log object to the logger stream 
                        // via the Repo instance injected
                        await AddLog(log, contextdb);
                        //repo.AddToLogs(log);

                        // since we have read till the end of the stream, 
                        // reset it onto the first position
                        // memStream.Position = 0;

                        // now copy the content of the temporary memory 
                        // stream we have passed to the actual response body 
                        // which will carry the response out.
                        await memStream.CopyToAsync(originalRequest);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    // assign the response body to the actual context
                    contexto.Response.Body = originalRequest;
                }
            }

        }


        private string getIps()
        {
            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
            var ips = heserver.AddressList.Where(x => !x.ToString().Contains(":")).ToArray();
            List<string> lip = new List<string>();

            foreach (var item in ips)
            {
                lip.Add(item.ToString());
            }

            var jsips = JsonConvert.SerializeObject(lip);

            return jsips;
        }

        private async Task AddLog(LogApiSaad log, UpdsLogContext contextdb)
        {
            try
            {
                if (!log.Path.Contains("swagger"))
                {
                    contextdb.LogApiSaads.Add(log);
                    await contextdb.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
