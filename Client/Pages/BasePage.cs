using BlazorCRUDApp.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Client;

public class BasePage : ComponentBase
{
    [Inject]
    protected  NavigationManager? NavigationManager { get;set; }

    [Inject]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected IWebService IWebService { get; set; }
    [Inject]
    protected IServiceLocal IWebServiceLocal { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected IWebService API { get =>  ProgramExt.IsLocalDb ? IWebServiceLocal : IWebService; }
    protected void OnCarList()
    {
        NavigationManager?.NavigateTo("carlist");
    }

}