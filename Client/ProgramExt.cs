using BlazorCRUDApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCRUDApp.Client.Services;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlazorCRUDApp.Client;
static class ProgramExt
{
    static public bool IsLocalDb = true;
}

//static public IServiceCollection? Services;
//static public void SetISerciceCollection(IServiceCollection _ISC) 
//{ 
//    Services = _ISC; 
//}

//static public void ChangeIWebService()
//{

//    var descriptorToLocal =
//    new ServiceDescriptor(
//        typeof(IWebService),
//        typeof(LocalService),
//        ServiceLifetime.Transient);

//    var descriptorToServer =
//    new ServiceDescriptor(
//        typeof(IWebService),
//        typeof(WebService),
//        ServiceLifetime.Transient);
//    IServiceCollection ?s = Services;
//    if (IsLocalDb)
//        s?.Replace(descriptorToLocal);
//    else
//        s?.Replace(descriptorToServer);

//}