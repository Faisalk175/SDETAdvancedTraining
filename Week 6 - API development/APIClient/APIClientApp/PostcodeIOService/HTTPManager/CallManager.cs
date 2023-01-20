namespace APIClientApp.PostcodeIOService;

public class CallManager
{
    //Handles communication with the API
    private readonly RestClient _client;
    public RestResponse RestResponse { get; set; }

    public CallManager()
    {
        _client = new RestClient(AppConfigReader.BaseUrl);
    }

    /// <summary>
    /// defines and makes an API request, stores the response and returns the response content.
    /// </summary>
    /// <param name="postcode"></param>
    public async Task<string> MakePostcodeRequestAsync(string postcode)
    {
        //Building the request
        var request = new RestRequest(); //Makes the HTTP Request
        request.Method = Method.Get;
        request.AddHeader("Content-Type", "application/json");
        request.Timeout = -1;

        request.Resource = $"postcodes/{postcode.Replace(" ", "")}";

        RestResponse = await _client.ExecuteAsync(request);

        return RestResponse.Content;
    }
}
