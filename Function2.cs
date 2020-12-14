using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionsApp
{
    public static class Function2
    {
        [FunctionName("MyFirstFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Admin, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string jsonContent = await new StreamReader(req.Body).ReadToEndAsync();
            if (jsonContent != "")
            {
                /*De serailizing json data here*/
                CommonReturnType fdata = JsonConvert.DeserializeObject<CommonReturnType>(jsonContent);
                string inputMessageJSON = fdata.Employees;
                Employees msg = JsonConvert.DeserializeObject<Employees>(inputMessageJSON);
                /*De serailizing json data here*/
                if (msg.MethodName == "CheckMethod" && fdata.IsCheck == "true")
                {
                    string swin = msg.text;
                    switch (swin.ToLower())
                    {
                        case "something":
                            msg.text = "How are you today";
                            fdata.IsCheck = "true";
                            break;
                        case "something1":
                            msg.text = "Good Bye";
                            fdata.IsCheck = "false";
                            break;
                        default:
                            msg.text = "Hi. How may I help you today..!";
                            fdata.IsCheck = "true";
                            break;
                    }
                    fdata.Employees = JsonConvert.SerializeObject(msg, Formatting.Indented);
                    return new OkObjectResult(fdata);
                }
            }
            return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }

    

}
