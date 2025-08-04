using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Project.Web.Components;
using Project.Web.Interfaces.Services;
using Project.Web.Interfaces.Services.Security;
using Project.Web.Services;
using Project.Web.Services.Security;
using ProjectAuthentication.Web.Security;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices(options => { options.PopoverOptions.CheckForPopoverProvider = false; });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<IAccessTokenService, AccessTokenService>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddScheme<CustomOption, JwtAuthenticationHandler>(
        "JWT", options => { }
    );

var baseUri = builder.Configuration["ApiSettings:BaseUri"];
builder.Services.AddHttpClient("ApiClient", opt =>
{
    opt.BaseAddress = new Uri(baseUri);
});

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
