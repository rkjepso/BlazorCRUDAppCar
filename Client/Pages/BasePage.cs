using BlazorCRUDApp.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Client;

public class BasePage : ComponentBase
{
    [Inject]
    private NavigationManager? NavigationManager { get;set; }

    [Inject]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected IWebService WebService { get; set; }
    [Inject]
    protected IServiceLocal WebServiceLocal { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected IWebService API { get =>  ProgramExt.IsLocalDb ? WebServiceLocal : WebService; }


    protected string StrInfo { get; set; } = "";
    protected bool Error = false;

    protected async Task OnOk(string message)
    {
        StrInfo = message;
        StateHasChanged();
        await Task.Delay(2500);

        //NavigationManager?.NavigateTo("carlist");
    }
    protected async Task OnError(string message)
    {
        Error = true;
        StrInfo = message;
        StateHasChanged();
        await Task.Delay(4000);
        Error = false;
        StrInfo = "";
    }

    protected void Cancel()
    {
        NavigationManager?.NavigateTo("carlist");
    }

}