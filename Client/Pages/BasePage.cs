using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Client;

public class BasePage : ComponentBase
{
    [Inject]
    private NavigationManager? NavigationManager { get;set;}
    protected string StrInfo { get; set; } = "";

    protected async Task MessageBeforeNavigate(string message, string url)
    {

        StrInfo = message;
        StateHasChanged();
        await Task.Delay(2000);
        NavigationManager?.NavigateTo("personlist");
    }

}