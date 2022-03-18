using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Client;

public class BasePage : ComponentBase
{
    [Inject]
    private NavigationManager? NavigationManager { get;set;}
    protected string StrInfo { get; set; } = "";
    protected bool Error = false;

    protected async Task OnOk(string message)
    {
        StrInfo = message;
        StateHasChanged();
        await Task.Delay(2500);

        NavigationManager?.NavigateTo("carlist");
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