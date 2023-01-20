using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace APIClientApp;

public class Program
{
    async static Task Main(string[] args)
    {
        var restClient = new RestClient("https://api.postcodes.io/"); //RestClient handles base URL

        var restRequest = new RestRequest(); //Makes the HTTP Request

        //Building the request
        restRequest.Method = Method.Get; //Method is a enum which has options like Get, Post, Delete, Patch and Put
        restRequest.AddHeader("Content-Type", "application/json"); //These are the headers which you want to Get
        restRequest.Timeout = -1; //No timeout if the request takes too long, it will keep trying

        string postcode = "EC2Y5AS";

        //https://api.postcodes.io/postcodes/:postcode is the URI, https://api.postcodes.io/ is the URL
        //postcodes is the resource and /:postcode is the query parameter
        restRequest.Resource = $"postcodes/{postcode}";

        var singlePostCodeResponse = await restClient.ExecuteAsync(restRequest);

        //Console.WriteLine(singlePostCodeResponse.Content); //Shows the content of the API executer
        //Console.WriteLine(singlePostCodeResponse.StatusCode); //Shows the status of the request

        var headers = singlePostCodeResponse.Headers; //We can use LINQ to scrape the headers and organise the data

        var client = new RestClient("https://api.postcodes.io/postcodes");
        var bulkPostCodeRequest = new RestRequest();
        bulkPostCodeRequest.Method = Method.Post;
        bulkPostCodeRequest.AddHeader("Content-Type", "application/json");

        //var body = @"{" + "\n" + @"""postcodes"" : [""PR3 0SG"", ""M45 6GN"", ""EX165BL""]" + "\n" + @"}";

        //Anonymous object which replaces comment above and below
        bulkPostCodeRequest.AddJsonBody(new {Postcodes = new string[] { "PR3 0SG", "M45 6GN", "EX165BL" }});

        //bulkPostCodeRequest.AddStringBody(body, "application/json"); //Using JSON formatting

        bulkPostCodeRequest.Timeout = -1; //client doenst request timeout

        RestResponse bulkPostCodeResponse = await client.ExecuteAsync(bulkPostCodeRequest);
        //Console.WriteLine(bulkPostCodeResponse.Content);

        //Deserialising the JSON into a object
        var singlePostCodeResponseJObject = JObject.Parse(singlePostCodeResponse.Content); //Formats into JSON

        var bulkPostCodeResponseJObject = JObject.Parse(bulkPostCodeResponse.Content); //Formats into JSON

        #region ConsoleWritelines
        //Console.WriteLine(singlePostCodeResponseJObject);

        //Console.WriteLine(singlePostCodeResponseJObject["result"]["postcode"]); //Accessing particular Postcode

        /*Console.WriteLine(bulkPostCodeResponseJObject["result"][0]["result"]["postcode"]);
        Console.WriteLine(bulkPostCodeResponseJObject["result"][1]["result"]["postcode"]);
        Console.WriteLine(bulkPostCodeResponseJObject["result"][2]["result"]["postcode"]);*/
        #endregion

        //Deserialising the JObject into a C# model object
        var singlePostCodeResponseModelObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(singlePostCodeResponse.Content);
        var bulkPostCodeResponseModelObject = JsonConvert.DeserializeObject<BulkPostcodeResponse>(bulkPostCodeResponse.Content);

        //Console.WriteLine(singlePostCodeResponseModelObject.result.codes.parish);
    }
}