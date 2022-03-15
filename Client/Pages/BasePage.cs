using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Client;

public class BasePage : ComponentBase
{
    [Inject]
    NavigationManager NavigationManager { get;set;}
    public string StrInfo { get; set; } = "";

    protected async Task MessageBeforeNavigate(string message, string url)
    {

        StrInfo = "Saved Successfully";
        StateHasChanged();
        await Task.Delay(3000);
        NavigationManager.NavigateTo("personlist");
    }

}