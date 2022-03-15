using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Client;

public class BasePage : ComponentBase
{
    [Inject]
    private NavigationManager? NavigationManager { get;set;}
    public string StrInfo { get; set; } = "";

    protected async Task MessageBeforeNavigate(string message, string url)
    {

        StrInfo = message;
        StateHasChanged();
        await Task.Delay(3000);
        NavigationManager?.NavigateTo("personlist");
    }

}