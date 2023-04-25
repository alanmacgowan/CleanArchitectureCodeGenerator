using System.Windows;

namespace CodeGenerator
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MainToolWindowCommand : BaseCommand<MainToolWindowCommand>
    {
        protected override Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
			return MainToolWindow.ShowAsync();
        }
    }
}
