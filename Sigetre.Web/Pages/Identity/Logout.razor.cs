using Microsoft.AspNetCore.Components;
using MudBlazor;
using Sigetre.Core.Handlers;
using Sigetre.Core.Requests.Identity;
using Sigetre.Web.Security;

namespace Sigetre.Web.Pages.Identity;

public partial class LogoutPage : ComponentBase
{
    #region Injects

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public IIdentityHandler Handler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        if (await AuthenticationStateProvider.CheckAuthenticatedAsync())
        {
            await Handler.LogoutAsync();
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            AuthenticationStateProvider.NotifyAuthenticationStateChanged();
            NavigationManager.NavigateTo("/login");
        }
        
        await base.OnInitializedAsync();
    }

    #endregion
}