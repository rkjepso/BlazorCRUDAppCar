using BlazorCRUDApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCRUDApp.Client.Services;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlazorCRUDApp.Client;
static class ProgramExt
{
    static public bool IsLocalDb = false;
}

