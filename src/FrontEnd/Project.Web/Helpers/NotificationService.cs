using MudBlazor;

namespace Project.Web.Helpers;

public class NotificationService
{
    private readonly ISnackbar _snackbar;

    public NotificationService(ISnackbar snackbar)
    {
        _snackbar = snackbar;
        _snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopEnd;
    }

    public void Success(string message)
    {
        _snackbar.Add(message, Severity.Success, config =>
        {
            config.ShowCloseIcon = true;
            config.VisibleStateDuration = 2500;
            config.SnackbarVariant = Variant.Filled;
        });
    }

    public void Error(string message)
    {
        _snackbar.Add(message, Severity.Error, config =>
        {
            config.ShowCloseIcon = true;
            config.VisibleStateDuration = 4000;
            config.SnackbarVariant = Variant.Filled;
        });
    }

    public void Info(string message)
    {
        _snackbar.Add(message, Severity.Info, config =>
        {
            config.ShowCloseIcon = true;
            config.VisibleStateDuration = 4000;
            config.SnackbarVariant = Variant.Filled;
        });
    }

    public void Warning(string message)
    {
        _snackbar.Add(message, Severity.Warning, config =>
        {
            config.ShowCloseIcon = true;
            config.VisibleStateDuration = 4000;
            config.SnackbarVariant = Variant.Filled;
        });
    }
}