using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Api;

namespace Portal.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly IConfiguration _config;
        private readonly IAPIHelper _apiHelper;
        private readonly AuthenticationState _anonymous;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage, IConfiguration config, IAPIHelper apiHelper)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _config = config;
            _apiHelper = apiHelper;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>(_config["authTokenStorageKey"]);
            if (string.IsNullOrWhiteSpace(token))
            {
                return _anonymous;
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJWT(token), "jwtAuthType")));
        }
        public async void NotifyUserAuthentication(string token)
        {
            Task<AuthenticationState> authState;
            try
            {
                await _apiHelper.GetLoggedInUserInfo(token);
                var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJWT(token), "jwtAuthType"));
                authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await _localStorage.RemoveItemAsync(_config["authTokenStorageKey"]);
                authState = Task.FromResult(_anonymous);
            }

            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            _apiHelper.LogOffUser();
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
