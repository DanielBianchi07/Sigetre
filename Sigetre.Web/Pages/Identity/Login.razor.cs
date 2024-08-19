using System.Security.Principal;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Sigetre.Core.Handlers;
using Sigetre.Core.Requests.Identity;
using Sigetre.Web.Security;

namespace Sigetre.Web.Pages.Identity;

public partial class LoginPage : ComponentBase
{
    #region Injects

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public IIdentityHandler Handler { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    #endregion

    #region Properties

    public bool IsBusy { get; set; } = false;
    public LoginRequest InputModel { get; set; } = new();

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is { IsAuthenticated : true })
        {
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            AuthenticationStateProvider.NotifyAuthenticationStateChanged();
            NavigationManager.NavigateTo("/");
        }
    }

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.LoginAsync(InputModel);

            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/");
            }
            else
                Snackbar.Add(result.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}