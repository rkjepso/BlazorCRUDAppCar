using BlazorCRUDApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCRUDApp.Client.Services;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<IWebService, WebService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<IServiceLocal, LocalService>();

//ProgramExt.SetISerciceCollection(builder.Services);
//ProgramExt.IsLocalDb = true;
//ProgramExt.ChangeIWebService();

await builder.Build().RunAsync();
