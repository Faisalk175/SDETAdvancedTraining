using Newtonsoft.Json;

namespace APIClientApp.PostcodeIOService;

public class DTO<IResponse> where IResponse : new()
{
    //The class is the model of the data returned by the API call
    public IResponse Response { get; set; }

    //Method creates the above object using the response from the API
    public void DeserializeResponse(string postcodeResponse)
    {
        Response = JsonConvert.DeserializeObject<IResponse>(postcodeResponse);
    }
}
