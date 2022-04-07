using BlazorCRUDApp.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Client;

public class BasePage : ComponentBase
{
    [Inject]
    protected  NavigationManager? NavigationManager { get;set; }

    protected void OnCarList()
    {
        NavigationManager?.NavigateTo("carlist");
    }

}