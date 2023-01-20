using APIClientApp.PostcodeIOService;

namespace APIClientApp.PostcodeService;

public class SinglePostcodeService
{
    #region Properties
    public CallManager CallManager { get; set; }

    //Capture the response
    public RestResponse Response { get; set; }

    //A Newtonsoft JObject to represent the json response
    public JObject ResponseContent { get; set; }

   

    //C# Object of the JSON response
    public DTO<SinglePostcodeResponse> ResponseObject { get; set; }

    //Raw string of the JSON response
    public string ResponseString { get; set; }

    public string PostcodeSelected { get; set; }

    #endregion

    public SinglePostcodeService()
    {
        CallManager = new CallManager();
        ResponseObject = new DTO<SinglePostcodeResponse>();
    }

    /// <summary>
    /// defines and makes the API request, and stores the response.
    /// </summary>
    /// <param name="postcode"></param>
    /// <returns></returns>
    public async Task MakeRequestAsync(string postcode)
    {
        //Registering the postcode used
        PostcodeSelected = postcode;

        //Make the request
        ResponseString = await CallManager.MakePostcodeRequestAsync(postcode);

        ResponseContent = JObject.Parse(ResponseString);

        ResponseObject.DeserializeResponse(ResponseString);
    }

    //Helper functions that enable ease of access to certain bits of data
    public string GetHeaderValue(string headerName)
    {
        return CallManager.RestResponse.Headers
            .Where(h => h.Name == headerName)
            .Select(h => h.Value.ToString())
            .FirstOrDefault();
    }

    public string GetResponseContentType() => CallManager.RestResponse.ContentType;
}
