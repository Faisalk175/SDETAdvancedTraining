using RestSharp;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace APItask;

public class Program
{
    static void Main(string[] args)
    {
        var restClient = new RestClient("https://api-football-standings.azharimm.site/");

        var restRequest = new RestRequest();
        //build the requrest
        restRequest.Method = Method.Get;
        restRequest.AddHeader("Content-Type", "application/json");
        restRequest.Timeout = -1;

        string football = "leagues";

        restRequest.Resource = football;

        var Response =  restClient.Execute(restRequest);

        Console.WriteLine(Response.Content);
        

        
    }
}