namespace APIClientTest;

public class WhenTheSinglePostcodeServiceIsCalled_WithValidPostcode
{
    SinglePostcodeService _singlePostcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _singlePostcodeService = new SinglePostcodeService();
        await _singlePostcodeService.MakeRequestAsync("EC2Y 5AS");
    }
    [Test]
    public void StatusIs200_InJsonResponseBody()
    {
        Assert.That(_singlePostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
    }
    [Test]
    public void StatusIs200()
    {
        Assert.That((int)_singlePostcodeService.CallManager.RestResponse.StatusCode, Is.EqualTo(200));
    }
    [Test]
    public void StatusIs200_OnObject()
    {
        Assert.That((int)_singlePostcodeService.CallManager.RestResponse.StatusCode, Is.EqualTo(200));
    }
    [Test]
    public void ContentType_IsJson()
    {
        Assert.That(_singlePostcodeService.CallManager.RestResponse.ContentType, Is.EqualTo("application/json"));
    }
    [Test]
    public void ConnectionIsKeepAlive()
    {
        var result = _singlePostcodeService.GetHeaderValue("Connection");

        Assert.That(result, Is.EqualTo("keep-alive"));
    }
}