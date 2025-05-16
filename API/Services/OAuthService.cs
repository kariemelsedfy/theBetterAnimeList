public class OAuthService
{
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;

    public OAuthService(IConfiguration config, HttpClient httpClient)
    {
        _config = config;
        _httpClient = httpClient;
    }

    public async Task<string?> ExchangeCodeForTokenAsync(string code)
    {
        var values = new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", code },
            { "client_id", _config["MAL:ClientId"] },
            { "client_secret", _config["MAL:ClientSecret"] },
            { "redirect_uri", _config["MAL:RedirectUri"] }
        };

        var content = new FormUrlEncodedContent(values);
        var response = await _httpClient.PostAsync("https://myanimelist.net/v1/oauth2/token", content);
        return await response.Content.ReadAsStringAsync();
    }
}
