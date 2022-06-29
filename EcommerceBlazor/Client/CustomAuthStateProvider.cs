using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace EcommerceBlazor.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _http;

        public CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient http)
        {
            _localStorageService = localStorageService;
            _http = http;
        }

        //grabs auth tokens from localStorage and create new claims identity
        //then notify needed components if user is authenticated or not 
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authToken = await _localStorageService.GetItemAsStringAsync("authToken");

            //empty Identity which is unauthorized yet
            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            //if authToken is in localStorage
            if(!string.IsNullOrEmpty(authToken))
            {
                try //try to Parse the token and set it to Bearer string
                {
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                    _http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
                } 
                catch //if something went wrong I remove token and unauthorize the user
                {
                    await _localStorageService.RemoveItemAsync(authToken);
                    identity = new ClaimsIdentity();
                }
            }

            //else create user and set state to this user
            //state is unauthorized
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            //notify that user is unauthorized
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch(base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

            return claims;
        }
    }
}
